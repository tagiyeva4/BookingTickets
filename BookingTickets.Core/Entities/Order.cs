using BookingTickets.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities
{
    public class Order:BaseAuditableEntity
    {
        public string? AppUserId { get; set; } = null!;
        public AppUser? AppUser { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? PromoCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }=OrderStatus.Pending;
        public List<OrderItem> OrderItems { get; set; } = [];

        // Stripe tərəfindən yaradılan sessiya ID-si, ödənişin statusunu izləmək üçün istifadə olunur
        public string? StripeSessionId { get; set; }

        // Stripe tərəfindən yaradılan ödəniş əməliyyatının unikal ID-si
        public string? StripePaymentIntentId { get; set; }

        // Ödənişin tamamlandığı zaman
        public DateTime? PaidAt { get; set; }

        // İstifadəçi və ya admin tərəfindən sifarişə əlavə qeyd
        public string? Note { get; set; }
        public bool IsPaid { get; set; } = false;

    }
}
