using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.ErrorDtos;

public class ErrorDto
{
    public int StatusCode { get; set; }
    [Required(ErrorMessage = "Message cannot be empty..")]
    public string Message { get; set; } = null!;
    [Required(ErrorMessage = "Name cannot be empty..")]
    public string Name { get; set; } = null!;
}
