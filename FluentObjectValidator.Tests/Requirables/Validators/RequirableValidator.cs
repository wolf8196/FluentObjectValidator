using FluentObjectValidator.Tests.Requirables.Configurations;

namespace FluentObjectValidator.Tests.Requirables.Validators
{
    public class RequirableValidator : Validator
    {
        public RequirableValidator()
        {
            AddConfiguration(new RequirableObjectConfiguration());
        }
    }
}