using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Dtos.EventDtos;

public class EventUpdateDto : IDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<DateTime>? Dates { get; set; }
    public int? AgeRestriction { get; set; }
    public string? PhoneNumber { get; set; }
    public List<int>? EventLanguageIds { get; set; }
    public bool? IsAccess { get; set; }
    public int? VenueId { get; set; }
}
