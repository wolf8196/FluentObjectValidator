using FluentObjectValidator.Tests.Strings.DTOs;
using FluentObjectValidator.Tests.Strings.TestDataGenerators;
using FluentObjectValidator.Tests.Strings.Validators;
using Xunit;

namespace FluentObjectValidator.Tests.Strings
{
    public class StringsTest : BaseTest
    {
        [Theory(DisplayName = "String IsRequired shortcut rule tests")]
        [ClassData(typeof(RuleSet1TestDataGenerator))]
        public void IsRequiredTest(StringDTO subject, bool expected)
        {
            validator = new StringRulesValidator(1);
            var actual = validator.Validate(subject);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "String IsRequired shortcut rule tests [TError]")]
        [ClassData(typeof(RuleSet1TestDataGenerator_TError))]
        public void IsRequiredTest_TError(StringDTO subject, string[] expected)
        {
            validatorWithError = new StringRulesValidator_TError(1);
            var actual = validatorWithError.Validate(subject);

            Assert.Equal(expected, actual.Errors);
        }

        [Theory(DisplayName = "String IsRequired, HasMinLength, HasMaxLength, custom rule tests")]
        [ClassData(typeof(RuleSet23TestDataGenerator))]
        public void StringRuleSet2Test(StringDTO subject, bool expected)
        {
            validator = new StringRulesValidator(2);
            var actual = validator.Validate(subject);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "String IsRequired, HasMinLength, HasMaxLength, custom rule tests [TError]")]
        [ClassData(typeof(RuleSet2TestDataGenerator_TError))]
        public void StringRuleSet2Test_TError(StringDTO subject, string[] expected)
        {
            validatorWithError = new StringRulesValidator_TError(2);
            var actual = validatorWithError.Validate(subject);

            Assert.Equal(expected, actual.Errors);
        }

        [Theory(DisplayName = "String IsRequired, HasLengthInRange, MatchesRegex tests")]
        [ClassData(typeof(RuleSet23TestDataGenerator))]
        public void StringRuleSet3Test(StringDTO subject, bool expected)
        {
            validator = new StringRulesValidator(3);
            var actual = validator.Validate(subject);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "String IsRequired, HasLengthInRange, MatchesRegex tests [TError]")]
        [ClassData(typeof(RuleSet3TestDataGenerator_TError))]
        public void StringRuleSet3Test_TError(StringDTO subject, string[] expected)
        {
            validatorWithError = new StringRulesValidator_TError(3);
            var actual = validatorWithError.Validate(subject);

            Assert.Equal(expected, actual.Errors);
        }
    }
}