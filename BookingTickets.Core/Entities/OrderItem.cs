namespace BookingTickets.Core.Entities
{
  public class OrderItem:BaseEntity
    {
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
