using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities
{
  public class OrderItem:BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Count { get; set; } = 1;
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        public string? SeatDescription { get; set; }
    }
}
