using BookingTickets.Core.Enums;

namespace BookingTickets.Core.Entities;

public class Ticket : BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; }
    public string? AppUserId { get; set; } // Bilet əvvəlcə istifadəçiyə bağlı olmur
    public AppUser? AppUser { get; set; }

    public DateTime? PurchaseDate { get; set; } // 🔹 `null` ola bilər, əgər alınmayıbsa
    public TicketStatus Status { get; set; } = TicketStatus.Available; // 🔹 Default olaraq "Available"

    public string? QRCodePath { get; set; } // 🔹 Default olaraq null ola bilər
    public string ValidationToken { get; set; } = Guid.NewGuid().ToString(); // 🔐 Default token

}

