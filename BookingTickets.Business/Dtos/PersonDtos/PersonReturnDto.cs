using BookingTickets.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.PersonDtos;

public class PersonReturnDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "FullName cannot be empty..")]
    public string FullName { get; set; } = null!;
    public int ProfessionId { get; set; }
    public Profession Profession { get; set; } = null!;
    public ICollection<EventPeron> EventPersons { get; set; } = [];
    [Required(ErrorMessage = "ImageUrl cannot be empty..")]
    public string ImageUrl { get; set; } = null!;
}
