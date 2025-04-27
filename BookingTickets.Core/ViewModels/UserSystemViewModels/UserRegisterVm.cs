using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels.UserSystemViewModels;

public class UserRegisterVm
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    public bool Subscribe { get; set; }
}
