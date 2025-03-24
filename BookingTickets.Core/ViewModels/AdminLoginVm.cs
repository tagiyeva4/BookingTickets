using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels;

public class AdminLoginVm
{
    public string UserName { get; set; }
    [DataType(DataType.Password)]
    [MinLength(6)]
    [MaxLength(10)]
    public string Password { get; set; }
}
