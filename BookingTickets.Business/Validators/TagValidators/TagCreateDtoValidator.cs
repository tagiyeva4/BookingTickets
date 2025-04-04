using BookingTickets.Business.Dtos.TagDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.TagValidators;

public class TagCreateDtoValidator:AbstractValidator<TagCreateDto>
{
    public TagCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEqual("<p><br></p>").WithMessage("Tag name cannot be empty..");
    }
}
