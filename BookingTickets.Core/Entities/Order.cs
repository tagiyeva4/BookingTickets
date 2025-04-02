using BookingTickets.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities
{
    public class Order:BaseAuditableEntity
    {
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? PromoCode { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }=OrderStatus.Pending;
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}
