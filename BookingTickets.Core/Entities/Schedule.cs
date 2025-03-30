namespace BookingTickets.Core.Entities;

public class Schedule:BaseEntity
{
    public DateTime Date { get; set; } 
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public ICollection<EventsSchedule> EventSchedules { get; set; } = [];
}
