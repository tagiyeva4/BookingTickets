using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.VenueDtos;

public class VenueUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Address field cannot be empty..")]
    public string Address { get; set; } = null!;
    [Required(ErrorMessage = "Capacity field cannot be empty..")]
    public int Capacity { get; set; }
}
