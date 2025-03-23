using BookingTickets.Core.Entities.Common;

namespace BookingTickets.Core.Entities;

public class Service:BaseEntity
{
    public string Icon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
}
