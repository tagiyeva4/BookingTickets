using BookingTickets.Business.Dtos;

namespace BookingTickets.Business.Services.Abstractions;

public interface IPaymentService
{
    Task<PaymentResponseDto> CreateAsync(PaymentCreateDto dto);
    Task<bool> CheckPaymentAsync(PaymentCheckDto dto);
}
