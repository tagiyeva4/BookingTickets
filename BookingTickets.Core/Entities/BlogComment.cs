using BookingTickets.Core.Entities.Common;
using BookingTickets.Core.Enums;

namespace BookingTickets.Core.Entities
{
    public class BlogComment : BaseEntity
    {
        public string Message { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public CommentStatus CommentStatus { get; set; } = CommentStatus.Pending;
        public DateTime DateTime { get; set; }

    }
}
