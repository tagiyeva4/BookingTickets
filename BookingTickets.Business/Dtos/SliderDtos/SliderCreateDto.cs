using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.SliderDtos;

public class SliderCreateDto:IDto
{
    [Required(ErrorMessage = "FestName field cannot be empty..")]
    public string FestName { get; set; } = null!;
    [Required(ErrorMessage = "Title field cannot be empty..")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "Description field cannot be empty..")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "ButtonText field cannot be empty..")]
    public string ButtonText { get; set; } = null!;
    [Required(ErrorMessage = "Photo field cannot be empty.")]
    public IFormFile Photo { get; set; } = null!;
}
