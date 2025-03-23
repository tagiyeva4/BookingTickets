using BookingTickets.Core.Entities.Common;

namespace BookingTickets.Core.Entities;

public class Blog:BaseAuditableEntity
{
    public string Title {  get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string SecondDescription {  get; set; }
    public List<BlogImage> BlogImages { get; set; }
    public List<BlogComment> BlogComments { get; set; }
}
