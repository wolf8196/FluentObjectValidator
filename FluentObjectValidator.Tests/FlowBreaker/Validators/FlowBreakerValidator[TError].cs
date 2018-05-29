using FluentObjectValidator.Tests.FlowBreaker.Configurations;

namespace FluentObjectValidator.Tests.FlowBreaker.Validators
{
    public class FlowBreakerValidator_TError : Validator<string>
    {
        public FlowBreakerValidator_TError()
        {
            AddConfiguration(new FlowBreakerConfiguration_TError());
        }
    }
}