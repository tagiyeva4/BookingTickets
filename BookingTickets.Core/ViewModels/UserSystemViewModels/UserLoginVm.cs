using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels.UserSystemViewModels;

public class UserLoginVm
{
    public string UserNameOrEmail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
