using FluentObjectValidator.Tests.FlowBreaker.DTOs;
using FluentObjectValidator.Tests.FlowBreaker.TestDataGenerators;
using FluentObjectValidator.Tests.FlowBreaker.Validators;
using Xunit;

namespace FluentObjectValidator.Tests.FlowBreaker
{
    public class FlowTest : BaseTest
    {
        public FlowTest()
        {
            validatorWithError = new FlowBreakerValidator_TError();
        }

        [Theory(DisplayName = "Flow breaking functionality tests")]
        [ClassData(typeof(FlowBreakerTestDataGenerator_TError))]
        public void FlowBreakerTest(FlowDTO subject, string[] expected)
        {
            var actual = validatorWithError.Validate(subject);

            Assert.Equal(expected, actual.Errors);
        }
    }
}