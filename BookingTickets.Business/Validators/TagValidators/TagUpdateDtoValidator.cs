using BookingTickets.Business.Dtos.TagDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.TagValidators;

public class TagUpdateDtoValidator: AbstractValidator<TagUpdateDto>
{
    public TagUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty..");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Tag name cannot be empty..");
    }
}
