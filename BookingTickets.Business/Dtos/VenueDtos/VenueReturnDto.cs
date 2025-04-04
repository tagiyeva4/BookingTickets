namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueReturnDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public double Latitude { get; set; } 
    public double Longitude { get; set; }
    public int Capacity { get; set; }
    public List<VenueSeatDto> Seats { get; set; } = new List<VenueSeatDto>();

}
public class VenueSeatDto : IDto
{
    public int Id { get; set; }
    public string RowName { get; set; } = null!;
    public int SeatNumber { get; set; }
    public string SeatLabel { get; set; } = null!;
}