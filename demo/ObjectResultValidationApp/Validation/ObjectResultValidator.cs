using FluentObjectValidator;
using ObjectResultValidationApp.Validation.ValidationConfigurations;

namespace ObjectResultValidationApp.Validation
{
    public class ObjectResultValidator : Validator<ValidationError>
    {
        public ObjectResultValidator()
        {
            AddConfiguration(new ProductDTOConfiguration());
            AddConfiguration(new UserDTOConfiguration());
        }
    }
}