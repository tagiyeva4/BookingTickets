namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public double Latitude { get; set; } 
    public double Longitude { get; set; }
}
