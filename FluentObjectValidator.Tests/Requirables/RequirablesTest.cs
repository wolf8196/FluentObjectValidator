using FluentObjectValidator.Tests.Requirables.DTOs;
using FluentObjectValidator.Tests.Requirables.TestDataGenerators;
using FluentObjectValidator.Tests.Requirables.Validators;
using Xunit;

namespace FluentObjectValidator.Tests.Requirables
{
    public class RequirablesTest : BaseTest
    {
        public RequirablesTest()
        {
            validator = new RequirableValidator();
            validatorWithError = new RequirableValidator_TError();
        }

        [Theory(DisplayName = "IsRequired shortcut rule tests")]
        [ClassData(typeof(TestDataGenerator))]
        public void ValidationTest(RequirableObject testSubject, bool expected)
        {
            var actual = validator.Validate(testSubject);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "IsRequired shortcut rule tests [TError]")]
        [ClassData(typeof(TestDataGenerator_TError))]
        public void ValidationTest_TError(RequirableObject testSubject, params string[] expected)
        {
            var actual = validatorWithError.Validate(testSubject);

            Assert.Equal(expected, actual.Errors);
        }
    }
}