namespace BookingTickets.Core.Entities;

public class EventsSchedule: BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

}

