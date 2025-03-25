namespace BookingTickets.Core.Entities;

public class EventImage:BaseEntity
{
    public string ImagePath { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
}
