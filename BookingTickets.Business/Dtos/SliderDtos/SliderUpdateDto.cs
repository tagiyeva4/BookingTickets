using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.SliderDtos;

public class SliderUpdateDto:IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "FestName field cannot be empty..")]
    public string FestName { get; set; } = null!;
    [Required(ErrorMessage = "Title field cannot be empty..")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "Description field cannot be empty..")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "ButtonText field cannot be empty..")]
    public string ButtonText { get; set; } = null!;
    public IFormFile? Photo { get; set; }

    public string? Image { get; set; }

}
