using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueCreateDto:IDto
{
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Address field cannot be empty..")]
    public string Address { get; set; } = null!;
    [Required(ErrorMessage = "Latitude field cannot be empty..")]
    public double Latitude { get; set; }
    [Required(ErrorMessage = "Longitude field cannot be empty..")]
    public double Longitude { get; set; }

}
