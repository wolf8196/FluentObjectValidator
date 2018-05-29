using FluentObjectValidator.Tests.Requirables.Configurations;

namespace FluentObjectValidator.Tests.Requirables.Validators
{
    public class RequirableValidator_TError : Validator<string>
    {
        public RequirableValidator_TError()
        {
            AddConfiguration(new RequirableObjectConfiguration_TError());
        }
    }
}