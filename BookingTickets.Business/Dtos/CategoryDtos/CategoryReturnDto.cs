using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.CategoryDtos;

public class CategoryReturnDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Category name cannot be empty..")]
    public string Name { get; set; } = null!;
}
