using BookingTickets.Business.Dtos.CategoryDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.CategoryValidators;

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEqual("<p><br></p>").WithMessage("Name is required");
    }
}
