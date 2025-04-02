namespace BookingTickets.Core.Entities
{
    public class BasketItem:BaseAuditableEntity
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int Count { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
