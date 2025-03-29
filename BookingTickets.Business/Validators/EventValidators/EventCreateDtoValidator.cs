using BookingTickets.Business.Dtos.EventDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.EventValidators;

public class EventCreateDtoValidator: AbstractValidator<EventCreateDto>
{
    public EventCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name field cannot be empty..");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description field cannot be empty..");
        RuleFor(x => x.AgeRestriction).NotEmpty().WithMessage("AgeRestriction field cannot be empty..");
        RuleFor(x => x.MinPrice).NotNull().WithMessage("MinPrice field cannot be empty..")
             .GreaterThanOrEqualTo(0)
             .WithMessage("MinPrice must be a positive number.");

        RuleFor(x => x.MaxPrice).NotNull().WithMessage("MaxPrice field cannot be empty..")
            .GreaterThanOrEqualTo(x => x.MinPrice)
            .WithMessage("MaxPrice must be greater than or equal to MinPrice.");

        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber field cannot be empty..");
        RuleFor(x => x.EventLanguageIds).NotEmpty().WithMessage("EventLanguageIds field cannot be empty..");
        RuleFor(x => x.EventScheduleIds).NotEmpty().WithMessage("EventScheduleIds field cannot be empty..");
        RuleFor(x => x.EventPersonIds).NotEmpty().WithMessage("EventPersonIds field cannot be empty..");
        RuleFor(x => x.VenueId).NotEmpty().WithMessage("VenueId field cannot be empty..");
        RuleFor(x => x.Photos).NotEmpty().WithMessage("Photos field cannot be empty..");
        RuleFor(x => x.TotalTickets).GreaterThan(0).NotEmpty().WithMessage("TotalTickets field cannot be empty..");
    }
}
