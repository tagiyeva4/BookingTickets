using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities;

public class Venue : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    [Column(TypeName = "decimal(9,6)")]
    public double Latitude { get; set; }
    [Column(TypeName = "decimal(9,6)")]
    public double Longitude { get; set; }
    public int Capacity { get; set; }

    // Navigation properties
    public ICollection<VenueSeat>? Seats { get; set; }
    public ICollection<Event>? Events { get; set; }
}



