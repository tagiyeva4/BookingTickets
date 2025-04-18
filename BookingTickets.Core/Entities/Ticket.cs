using BookingTickets.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities;

public class Ticket : BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; }

    public string? AppUserId { get; set; } 
    public AppUser? AppUser { get; set; }

    public int VenueSeatId { get; set; } 
    public VenueSeat VenueSeat { get; set; }

    public DateTime? PurchaseDate { get; set; } 

    public TicketStatus Status { get; set; }

    public string? QRCodePath { get; set; } 

    public string ValidationToken { get; set; } = Guid.NewGuid().ToString(); 

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public DateTime ReservedAt { get; set; } = DateTime.Now;
    public DateTime ExpiresAt { get; set; } = DateTime.Now.AddMinutes(15);
    public int? OrderId { get; set; }
    public Order? Order { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; } = null!;
}

