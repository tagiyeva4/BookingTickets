using BookingTickets.Business.Dtos.CategoryDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
