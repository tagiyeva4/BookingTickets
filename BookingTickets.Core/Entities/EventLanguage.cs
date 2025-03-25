namespace BookingTickets.Core.Entities;

public class EventLanguage : BaseEntity
{
    public Language Language { get; set; } = null!;
    public int LanguageId { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}
