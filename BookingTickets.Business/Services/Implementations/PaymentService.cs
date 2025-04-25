using BookingTickets.Business.Dtos;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Core.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using BookingTickets.Business.Exceptions;
using BookingTickets.DataAccess.Repositories.Abstractions;
using BookingTickets.Core.Entities;
using BookingTickets.Business.Dtos.PaymentDtos;

namespace BookingTickets.Business.Services.Implementations;


internal class PaymentService : IPaymentService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;
    private readonly PaymentConfigurationDto _paymentConfigurationDto;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUrlHelper _urlHelper;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IPaymentRepository _repository;

    public PaymentService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, IHttpContextAccessor contextAccessor, IHttpClientFactory httpClientFactory, IPaymentRepository repository)
    {
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
        _paymentConfigurationDto = _configuration.GetSection("PaymentSettings").Get<PaymentConfigurationDto>() ?? new();
        _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext ?? new());
        _contextAccessor = contextAccessor;
        _httpClientFactory = httpClientFactory;
        _repository = repository;
    }


    public async Task<PaymentCheckResultDto> CheckPaymentAsync(PaymentCheckDto dto)
    {
        var payment = await _repository.FindOneAsync(x => x.Token == dto.Token && x.ReceptId == dto.ID, "Order");

        if (payment is null)
            throw new CustomException(404, "Not found");

        if (dto.STATUS == PaymentStatuses.FullyPaid)
        {
            payment.PaymentStatus = PaymentStatuses.FullyPaid;
            payment.Order.IsPaid = true;

            await _repository.UpdateAsync(payment);

            return new PaymentCheckResultDto
            {
                IsSuccess = true,
                OrderId = payment.OrderId
            };
        }

        await _repository.DeleteAsync(payment);

        return new PaymentCheckResultDto
        {
            IsSuccess = false,
            OrderId = payment.OrderId
        };
    }


    //public async Task<bool> CheckPaymentAsync(PaymentCheckDto dto)
    //{
    //    var payment = await _repository.FindOneAsync(x => x.Token == dto.Token && x.ReceptId == dto.ID, "Order");

    //    if (payment is null)
    //        throw new CustomException(404, "Not found");

    //    if (dto.STATUS == PaymentStatuses.FullyPaid)
    //    {
    //        payment.PaymentStatus = PaymentStatuses.FullyPaid;
    //        payment.Order.IsPaid = true;

    //        await _repository.UpdateAsync(payment);

    //        return true;
    //    }

    //    await _repository.DeleteAsync(payment);

    //    return false;
    //}

    public async Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto)
    {

        string confirmationToken = Guid.NewGuid().ToString();
        UrlActionContext context = new()
        {
            Action = "CheckPayment",
            Controller = "Order",
            Values = new { token = confirmationToken },
            Protocol = _contextAccessor.HttpContext?.Request.Scheme
        };

        var redirectUrl = _urlHelper.Action(context);


        string amount = dto.Amount.ToString().Replace(',', '.');


        string requestBody = $@"
    {{
        ""order"": {{
            ""typeRid"": ""Order_SMS"",
            ""amount"": {amount},
            ""currency"": ""AZN"",
            ""language"": ""az"",
            ""description"": ""{dto.Description}"",
            ""hppRedirectUrl"": ""{redirectUrl}"",
            ""hppCofCapturePurposes"": [""Cit""]
        }}
    }}";

        var httpClient = _httpClientFactory.CreateClient("KapitalBankClient");
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_paymentConfigurationDto.Username}:{_paymentConfigurationDto.Password}"));
        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);


        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(_paymentConfigurationDto.BaseUrl, content);

        if (!response.IsSuccessStatusCode)
            throw new Exception(response.StatusCode.ToString());

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<PaymentResponseDto>(responseContent) ?? new();

        Payment payment = new()
        {
            Amount = dto.Amount,
            Description = dto.Description,
            OrderId = dto.OrderId,
            ReceptId = result.Order.Id,
            SecretId = result.Order.Secret,
            Token = confirmationToken,

            PaymentStatus = PaymentStatuses.Pending
        };

        await _repository.AddAsync(payment);

        result.Id = payment.Id;

        return result;
    }
}