namespace BookingTickets.Business.Dtos.HubDtos;

public class ConnectionDto:IDto
{
    public string UserId { get; set; } = null!;
    public List<string> ConnectionIds { get; set; } = [];
}
