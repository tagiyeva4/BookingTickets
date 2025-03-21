using BookingTickets.Core.Entities.Common;

namespace BookingTickets.Core.Entities
{
   public class BlogImage:BaseEntity
    {
        public string ImagePath { get; set; }
        public int BlogId {  get; set; }
        public Blog Blog { get; set; }
    }
}
