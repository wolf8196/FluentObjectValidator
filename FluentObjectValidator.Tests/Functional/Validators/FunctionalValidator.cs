using FluentObjectValidator.Tests.Functional.Configurations;

namespace FluentObjectValidator.Tests.Functional.Validators
{
    public class FunctionalValidator : Validator
    {
        public FunctionalValidator()
        {
            AddConfiguration(new UserDTOConfiguration());
            AddConfiguration(new MessageDTOConfiguration());
            AddConfiguration(new AdvertDTOConfiguration());
        }
    }
}