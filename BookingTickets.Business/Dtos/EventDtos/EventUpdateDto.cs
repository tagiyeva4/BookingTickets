using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name cannot be empty..")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Description cannot be empty..")]
    public string Description { get; set; } = null!;
    public IFormFile? NewImage { get; set; } 
}

