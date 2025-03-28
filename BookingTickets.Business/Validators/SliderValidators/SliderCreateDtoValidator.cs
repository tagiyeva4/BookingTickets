using BookingTickets.Business.Dtos.SliderDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.SliderValidators;

public class SliderCreateDtoValidator:AbstractValidator<SliderCreateDto>
{
    public SliderCreateDtoValidator()
    {
        RuleFor(x => x.FestName).NotEmpty().WithMessage("FestName is required");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Photo).NotNull().WithMessage("Image is required");
        RuleFor(x => x.ButtonText).NotEmpty().WithMessage("Title is required");
    }
}

