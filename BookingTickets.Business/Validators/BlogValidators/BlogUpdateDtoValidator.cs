using BookingTickets.Business.Dtos.BlogDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.BlogValidators;

public class BlogUpdateDtoValidator: AbstractValidator<BlogUpdateDto>
{
    public BlogUpdateDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title field cannot be empty..");
        RuleFor(x => x.SecondDescription).NotEmpty().WithMessage("SecondDescription field cannot be empty..");
        RuleFor(x => x.Photos).NotEmpty().WithMessage("Photos field cannot be empty..");
    }
}
