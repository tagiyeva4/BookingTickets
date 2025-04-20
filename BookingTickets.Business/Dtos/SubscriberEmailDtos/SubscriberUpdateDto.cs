namespace BookingTickets.Business.Dtos.SubscriberEmailDtos;

public class SubscriberUpdateDto:IDto
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
}
