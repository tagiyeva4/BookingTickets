using BookingTickets.Business.Dtos.VenueDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.VenueValidators;

public class VenueUpdateDtoValidator:AbstractValidator<VenueUpdateDto>  
{
    public VenueUpdateDtoValidator()
    {
        RuleFor(x=>x.Name).NotNull().WithMessage("Name is required");

    }
}
