using BookingTickets.Business.Dtos.VenueDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.VenueValidators;

public class VenueCreateDtoValidator:AbstractValidator<VenueCreateDto>
{
    public VenueCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
        RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Capacity must be greater than 0");
    }
}

