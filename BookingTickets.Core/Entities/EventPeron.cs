namespace BookingTickets.Core.Entities;

public class EventPeron: BaseEntity
{
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}
