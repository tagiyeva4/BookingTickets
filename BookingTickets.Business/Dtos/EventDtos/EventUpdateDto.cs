using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public List<DateTime>? Dates { get; set; }
    public int? AgeRestriction { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    public List<int>? EventLanguageIds { get; set; }
    public bool? IsAccess { get; set; }
    public int? VenueId { get; set; }
    [Required(ErrorMessage = "Photos field cannot be empty..")]
    public List<IFormFile>? Photos { get; set; } = [];
    public List<string>? EventImages { get; set; } = [];
}
