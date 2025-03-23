using BookingTickets.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Business.Dtos.BlogDtos;

public class BlogUpdateDto:IDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title field cannot be empty..")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "SubTitle field cannot be empty..")]
    public string SubTitle { get; set; } = null!;
    [Required(ErrorMessage = "Description field cannot be empty..")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "SecondDescription field cannot be empty..")]
    public string SecondDescription { get; set; } = null!;
    [Required(ErrorMessage = "Photos field cannot be empty..")]
    public List<IFormFile>? Photos { get; set; } = [];
    public List<string>? BlogImages { get; set; } = [];
    public List<BlogComment>? BlogComments { get; set; }
}
