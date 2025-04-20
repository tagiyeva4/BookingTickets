namespace BookingTickets.Business.Dtos.SubscriberEmailDtos;

public class SubscriberCreateDto:IDto
{
    public string Email { get; set; } = null!;
}
