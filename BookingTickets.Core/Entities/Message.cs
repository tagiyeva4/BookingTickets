namespace BookingTickets.Core.Entities;

public class Message:BaseAuditableEntity
{
    public string Text { get; set; } = null!;
    public AppUser? Sender { get; set; } 
    public string? SenderId { get; set; } 
    public Chat Chat { get; set; } = null!;
    public int ChatId { get; set; }
}
