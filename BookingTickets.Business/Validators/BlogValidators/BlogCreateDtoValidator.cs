using BookingTickets.Business.Dtos.BlogDtos;
using FluentValidation;

namespace BookingTickets.Business.Validators.BlogValidators;
public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
{
    public BlogCreateDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title field cannot be empty..");
        RuleFor(x => x.SubTitle).NotEmpty().WithMessage("SubTitle field cannot be empty..");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description field cannot be empty..");
        RuleFor(x => x.Photos).NotEmpty().WithMessage("Photos field cannot be empty..");
        RuleFor(x => x.SecondDescription).NotEmpty().WithMessage("SecondDescription field cannot be empty..");
    }
}

