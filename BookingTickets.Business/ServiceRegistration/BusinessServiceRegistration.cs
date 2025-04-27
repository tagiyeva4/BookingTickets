
using BookingTickets.Business.AutoMappers;
using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Business.Services.Implementations;
using BookingTickets.Business.Validators.BlogValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookingTickets.Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
     
        services.AddHttpClient();

        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddHttpContextAccessor();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(BlogCreateDtoValidator));
        AddServices(services);
        services.AddSignalR();
        return services; 
    }
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<IBlogService, BlogService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IVenueService, VenueService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ISubscriberService, SubscriberService>();
       services.AddScoped<ITicketPdfService, TicketPdfService>();
        services.AddScoped<IQRCodeService, QRCodeService>();
        services.AddScoped<LayoutServices>();
        services.AddScoped<IEmailService,EmailService>();
        services.AddScoped<TicketPdfService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
    }
 }
