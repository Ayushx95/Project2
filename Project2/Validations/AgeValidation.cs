using System.ComponentModel.DataAnnotations;

namespace Project2.Validations
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int Age = Convert.ToInt32(value);
            if (Age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Age must be Greater than 18");
        }
    }
}
