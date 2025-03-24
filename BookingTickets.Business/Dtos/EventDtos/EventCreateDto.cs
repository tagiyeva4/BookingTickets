namespace BookingTickets.Business.Dtos.EventDtos;

public class EventCreateDto:IDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<DateTime> Dates { get; set; } = [];
    public int AgeRestriction { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public List<int> EventLanguageIds { get; set; } = [];
    public bool IsAccess { get; set; } = false;
    public int VenueId { get; set; }

}
