using BookingTickets.Business.Dtos.EventDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.EventValidators;

public class EventUpdateDtoValidator: AbstractValidator<EventUpdateDto>
{
    public EventUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty..");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty..");
    }
}
