namespace BookingTickets.Core.Entities;

public class EventsSchedule: BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; } 
    public TimeSpan EndTime { get; set; } 
 
}

