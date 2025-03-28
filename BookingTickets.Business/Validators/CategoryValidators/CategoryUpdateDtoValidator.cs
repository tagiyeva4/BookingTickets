using BookingTickets.Business.Dtos.CategoryDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.CategoryValidators;
public class CategoryUpdateDtoValidator: AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Category name cannot be empty..");
    }
}
