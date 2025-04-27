using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels.UserSystemViewModels;

public class PasswordResetVm
{
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string? ConfirmPassword { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }
}
