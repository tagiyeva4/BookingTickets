namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Capacity { get; set; }
}
