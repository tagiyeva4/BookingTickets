using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Core.Attributes;

public class MinMaxPriceValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = (dynamic)validationContext.ObjectInstance;

        if (model.MinPrice > model.MaxPrice)
        {
            return new ValidationResult("MinPrice cannot be greater than MaxPrice.");
        }

        return ValidationResult.Success;
    }
}