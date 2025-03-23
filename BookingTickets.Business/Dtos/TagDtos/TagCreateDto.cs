using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.TagDtos;

public class TagCreateDto:IDto
{
    [Required(ErrorMessage = "Tag name cannot be empty..")]
    public string Name { get; set; } = null!;
}
