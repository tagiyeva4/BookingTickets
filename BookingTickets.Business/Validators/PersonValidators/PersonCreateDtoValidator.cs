

using BookingTickets.Business.Dtos.PersonDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.PersonValidators;

public class PersonCreateDtoValidator: AbstractValidator<PersonCreateDto>
{
    public PersonCreateDtoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName field cannot be empty.");
        RuleFor(x => x.ProfessionId).NotEmpty().WithMessage("ProfessionId field cannot be empty.");
        RuleFor(x => x.Photo).NotEmpty().WithMessage("Photo field cannot be empty.");
    }
}
