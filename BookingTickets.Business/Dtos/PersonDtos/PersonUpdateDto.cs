using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.PersonDtos;

public class PersonUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "FullName field cannot be empty.")]
    public string FullName { get; set; } = null!;
    [Required(ErrorMessage = "ProfessionId field cannot be empty..")]
    public int ProfessionId { get; set; }
    public ICollection<EventPeron>? EventPersons { get; set; }
    public IFormFile? Photo { get; set; }
    public string? ImageUrl { get; set; }
}
