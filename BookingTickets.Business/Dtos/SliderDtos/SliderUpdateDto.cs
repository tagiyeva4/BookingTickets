using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.SliderDtos;

public class SliderUpdateDto:IDto
{
    public int Id { get; set; }
    public string? FestName { get; set; }
    [Required(ErrorMessage = "Title field cannot be empty..")]
    public string Title { get; set; } = null!;
    public string? Description { get; set; } 
    public string? ButtonText { get; set; } 
    public IFormFile? Photo { get; set; }

    public string? Image { get; set; }

}
