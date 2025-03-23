using Microsoft.AspNetCore.Identity;

namespace BookingTickets.Business.Helpers;

public class CustomErrorDescriber:IdentityErrorDescriber
{
    public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Password must be contains ('0'-'9')." }; }
    public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Password must be contains ('A'-'Z')." }; }
}
