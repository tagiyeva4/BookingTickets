using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.PersonDtos;

public class PersonCreateDto:IDto
{
    [Required(ErrorMessage = "FullName field cannot be empty.")]
    public string FullName { get; set; } = null!;
    [Required(ErrorMessage = "ProfessionId field cannot be empty..")]
    public int ProfessionId { get; set; }
    public ICollection<EventPeron>? EventPersons { get; set; } 
    [Required(ErrorMessage = "Photo field cannot be empty.")]
    public IFormFile Photo { get; set; } = null!;
}
