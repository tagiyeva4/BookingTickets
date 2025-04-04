using BookingTickets.Business.Dtos.CategoryDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.CategoryValidators;
public class CategoryUpdateDtoValidator: AbstractValidator<CategoryUpdateDto>
{
    public CategoryUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty..");
        RuleFor(x => x.Name).NotEqual("<p><br></p>").WithMessage("Category name cannot be empty..");
    }
}
