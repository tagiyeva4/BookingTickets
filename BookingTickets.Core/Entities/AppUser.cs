using Microsoft.AspNetCore.Identity;

namespace BookingTickets.Core.Entities;

public class AppUser:IdentityUser
{
    public string? FullName { get; set; }
    public List<BasketItem>? BasketItems { get; set; }
}
