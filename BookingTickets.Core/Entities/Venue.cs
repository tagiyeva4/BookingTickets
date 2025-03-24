using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Core.Entities;

public class Venue : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int Capacity { get; set; }
}


