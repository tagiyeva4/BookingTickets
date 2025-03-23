using BookingTickets.Core.Entities;

namespace BookingTickets.Core.ViewModels;

public class BlogDetailVm
{
    public Blog Blog { get; set; }
    public bool HasCommentUser { get; set; }
    public int TotalCommentsCount { get; set; }
    public BlogComment BlogComment { get; set; }
    public List<Tag> Tags { get; set; }
    public List<Category> Categories { get; set; }
}
