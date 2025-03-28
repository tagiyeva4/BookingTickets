using BookingTickets.Business.Dtos.SliderDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.SliderValidators;

public class SliderUpdateDtoValidator: AbstractValidator<SliderUpdateDto>
{
    public SliderUpdateDtoValidator()
    {
        RuleFor(x=>x.Title).NotNull().WithMessage("Title field cannot be empty..");
    }
}
