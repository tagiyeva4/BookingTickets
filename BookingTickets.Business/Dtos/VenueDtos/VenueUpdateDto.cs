using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
