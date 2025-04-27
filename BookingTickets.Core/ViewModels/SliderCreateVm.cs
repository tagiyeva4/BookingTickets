using BookingTickets.Core.Attributes;
using Microsoft.AspNetCore.Http;

namespace BookingTickets.Core.ViewModels;

public class SliderCreateVm
{
    public string FestName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ButtonText { get; set; }
    public string Image { get; set; }
    [MaxSize(2 * 1024 * 1024)]
    [AllowedType("image/jpeg", "image/png")]
    public IFormFile? Photo { get; set; }
}
