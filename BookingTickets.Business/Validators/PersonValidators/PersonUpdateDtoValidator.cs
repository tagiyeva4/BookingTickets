using BookingTickets.Business.Dtos.PersonDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.PersonValidators;

public class PersonUpdateDtoValidator: AbstractValidator<PersonUpdateDto>
{
    public PersonUpdateDtoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName field cannot be empty.");
        RuleFor(x => x.ProfessionId).NotEmpty().WithMessage("ProfessionId field cannot be empty.");
    }
}
