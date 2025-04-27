using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.ViewModels.UserSystemViewModels;

public class ForgotPasswordVm
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
