using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.CategoryDtos;

public class CategoryCreateDto:IDto
{
    [Required(ErrorMessage = "Tag name cannot be empty..")]
    public string Name { get; set; } = null!;
}
