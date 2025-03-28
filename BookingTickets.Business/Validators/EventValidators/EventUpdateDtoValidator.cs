using BookingTickets.Business.Dtos.EventDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.EventValidators;

public class EventUpdateDtoValidator: AbstractValidator<EventUpdateDto>
{
    public EventUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name field cannot be empty..");
        
        RuleFor(x => x.Photos).NotEmpty().WithMessage("Photos field cannot be empty..");
    }
}
