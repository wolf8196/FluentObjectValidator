using BooleanResultValidationApp.Validation.ValidationConfigurations;
using FluentObjectValidator;

namespace BooleanResultValidationApp.Validation
{
    public class BooleanResultValidator : Validator
    {
        public BooleanResultValidator()
        {
            AddConfiguration(new ProductDTOConfiguration());
            AddConfiguration(new UserDTOConfiguration());
        }
    }
}