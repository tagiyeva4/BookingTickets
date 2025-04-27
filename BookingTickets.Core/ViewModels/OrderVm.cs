using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels;

public class OrderVm
{
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    public string? PromoCode { get; set; }
}
