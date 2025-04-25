using BookingTickets.Business.Dtos;
using BookingTickets.Business.Dtos.PaymentDtos;

namespace BookingTickets.Business.Services.Abstractions;

public interface IPaymentService
{
    Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto);
    Task<PaymentCheckResultDto> CheckPaymentAsync(PaymentCheckDto dto);
}
