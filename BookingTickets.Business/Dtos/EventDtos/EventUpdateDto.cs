using BookingTickets.Business.Dtos.VenueSeatDto;
using iText.IO.Image;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventUpdateDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int AgeRestriction { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public bool IsAccess { get; set; }
    public int VenueId { get; set; }
    public int MaxPrice { get; set; }
    public int MinPrice { get; set; }
    public int TotalTickets { get; set; }
    public List<ScheduleUpdateDto> EventSchedules { get; set; } = [];
    public List<int> SelectedLanguageIds { get; set; } = [];
    public List<int> SelectedPersonIds { get; set; } = [];
    public List<IFormFile>? Photos { get; set; }
    public List<EventImageDto> ExistingImages { get; set; } = [];
    public List<VenueSeatUpdateDto>? VenueSeats { get; set; }

}

public class ScheduleUpdateDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
public class EventImageDto
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
}




//public class EventUpdateDto : IDto
//{
//    public int Id { get; set; }
//    [Required(ErrorMessage = "Name field cannot be empty..")]
//    public string Name { get; set; }=null!;
//    public string? Description { get; set; }
//    public int? AgeRestriction { get; set; }
//    public int? MaxPrice { get; set; }
//    public int? MinPrice { get; set; }
//    [DataType(DataType.PhoneNumber)]
//    public string? PhoneNumber { get; set; }
//    public List<int> EventLanguageIds { get; set; } = [];
//    public List<int> EventScheduleIds { get; set; } = [];
//    public List<int> EventPersonIds { get; set; } = [];
//    public bool? IsAccess { get; set; }
//    public int? VenueId { get; set; }
//    [Required(ErrorMessage = "Photos field cannot be empty..")]
//    public List<IFormFile> Photos { get; set; } = [];
//    public List<string>? EventImages { get; set; } = [];
//    public int? TotalTickets { get; set; }
//    public List<ScheduleDtoInEvent> EventSchedules { get; set; } = [];
//}
