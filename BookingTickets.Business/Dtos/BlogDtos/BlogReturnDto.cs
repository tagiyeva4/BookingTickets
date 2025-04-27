using BookingTickets.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.BlogDtos;

public class BlogReturnDto:IDto
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
    [Required(ErrorMessage = "Title cannot be empty..")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "SubTitle cannot be empty..")]
    public string SubTitle { get; set; } = null!;
    [Required(ErrorMessage = "Description cannot be empty..")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "SecondDescription cannot be empty..")]
    public string SecondDescription { get; set; } = null!;
    public List<string> BlogImages { get; set; } = [];
    public List<BlogComment>? BlogComments { get; set; }
}
