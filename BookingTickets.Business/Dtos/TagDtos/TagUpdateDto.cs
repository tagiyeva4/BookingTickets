using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.TagDtos;

public class TagUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Tag name cannot be empty..")]
    public string Name { get; set; } = null!;
}
