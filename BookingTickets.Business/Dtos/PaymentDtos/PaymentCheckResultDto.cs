namespace BookingTickets.Business.Dtos.PaymentDtos;

public class PaymentCheckResultDto
{
    public bool IsSuccess { get; set; }
    public int OrderId { get; set; }
}
