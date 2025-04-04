using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventCreateDto : IDto
{
    [Required(ErrorMessage = "Name field cannot be empty..")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Description field cannot be empty..")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "AgeRestriction field cannot be empty..")]
    public int AgeRestriction { get; set; }
    [Required(ErrorMessage = "MaxPrice field cannot be empty..")]
    public int MaxPrice { get; set; }
    [Required(ErrorMessage = "MinPrice field cannot be empty..")]
    public int MinPrice { get; set; }
    [Required(ErrorMessage = "PhoneNumber field cannot be empty..")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = null!;
    [Required(ErrorMessage = "EventLanguageIds field cannot be empty..")]
    public List<int> EventLanguageIds { get; set; } = [];
    [Required(ErrorMessage = "EventPersonIds field cannot be empty..")]
    public List<int> EventPersonIds { get; set; } = [];
    public bool IsAccess { get; set; } = false;
    [Required(ErrorMessage = "VenueId field cannot be empty..")]
    public int VenueId { get; set; }
    [Required(ErrorMessage = "Photos field cannot be empty..")]
    public List<IFormFile> Photos { get; set; } = [];
    [Required(ErrorMessage = "TotalTickets field cannot be empty..")]
    public int TotalTickets { get; set; }
    [Required(ErrorMessage = "Schedules field cannot be empty..")]
    public List<ScheduleDto> Schedules { get; set; } = [];

}
public class ScheduleDto
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }
}