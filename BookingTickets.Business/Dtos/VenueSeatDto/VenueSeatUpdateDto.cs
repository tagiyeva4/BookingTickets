namespace BookingTickets.Business.Dtos.VenueSeatDto;

public class VenueSeatUpdateDto:IDto
{
    public int Id { get; set; }
    public string SeatLabel { get; set; } = null!;
    public decimal? Price { get; set; } 
}
