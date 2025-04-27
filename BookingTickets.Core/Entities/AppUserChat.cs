namespace BookingTickets.Core.Entities;

public class AppUserChat : BaseEntity
{
    public int ChatId { get; set; }
    public string AppUserId { get; set; } = null!;
    public Chat Chat { get; set; } = null!;
    public AppUser AppUser { get; set; } = null!;
}
