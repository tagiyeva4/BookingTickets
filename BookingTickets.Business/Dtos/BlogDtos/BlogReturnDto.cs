using BookingTickets.Core.Entities;

namespace BookingTickets.Business.Dtos.BlogDtos
{
   public class BlogReturnDto:IDto
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SecondDescription { get; set; } = null!;
        public List<string> BlogImages { get; set; } = [];
        public List<BlogComment>? BlogComments { get; set; }
    }
}
