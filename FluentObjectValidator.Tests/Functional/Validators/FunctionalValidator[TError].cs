using FluentObjectValidator.Tests.Functional.Configurations;

namespace FluentObjectValidator.Tests.Functional.Validators
{
    public class FunctionalValidator_TError : Validator<string>
    {
        public FunctionalValidator_TError()
        {
            AddConfiguration(new UserDTOConfiguration_TError());
            AddConfiguration(new MessageDTOConfiguration_TError());
            AddConfiguration(new AdvertDTOConfiguration_TError());
        }
    }
}