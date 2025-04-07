using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Core.Entities
{
    public class VenueSeat : BaseEntity
    {
        public int RowNumber { get; set; }
        public string? RowName { get; set; } // A, B, C və ya 1, 2, 3
        public int SeatNumber { get; set; }
        public string? SeatLabel { get; set; } // A1, B2, C3 və ya 1-1, 2-5
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }

}
