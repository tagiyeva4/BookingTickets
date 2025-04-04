using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventUpdateDto : IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; }=null!;
    public string? Description { get; set; }
    public int? AgeRestriction { get; set; }
    public int? MaxPrice { get; set; }
    public int? MinPrice { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    public List<int> EventLanguageIds { get; set; } = [];
    public List<int> EventScheduleIds { get; set; } = [];
    public List<int> EventPersonIds { get; set; } = [];
    public bool? IsAccess { get; set; }
    public int? VenueId { get; set; }
    [Required(ErrorMessage = "Photos field cannot be empty..")]
    public List<IFormFile> Photos { get; set; } = [];
    public List<string>? EventImages { get; set; } = [];
    public int? TotalTickets { get; set; }
    public List<ScheduleDtoInEvent> EventSchedules { get; set; } = [];
}
