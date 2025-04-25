namespace BookingTickets.Core.Entities;

public class Service:BaseEntity
{
    public string Icon { get; set; }=null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ButtonText { get; set; } = null!;
    public string Info { get; set; } = null!;
    public string Image { get; set; } = null!;
}
