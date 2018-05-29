using System;
using FluentObjectValidator.Tests.Functional.DTOs;
using FluentObjectValidator.Tests.Functional.TestDataGenerators;
using FluentObjectValidator.Tests.Functional.Validators;
using Xunit;

namespace FluentObjectValidator.Tests.Functional
{
    public class FunctionalTest : BaseTest
    {
        public FunctionalTest()
        {
            validator = validator ?? new FunctionalValidator();
            validatorWithError = validatorWithError ?? new FunctionalValidator_TError();
        }

        [Theory(DisplayName = "Functional UserDTO validation tests")]
        [ClassData(typeof(UserDTOTestDataGenerator))]
        public void ValidateUserTest(UserDTO user, bool expected)
        {
            var actual = validator.Validate(user);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Functional UserDTO validation tests [TError]")]
        [ClassData(typeof(UserDTOTestDataGenerator_TError))]
        public void ValidateUserTest_TError(UserDTO user, string[] expected)
        {
            var actual = validatorWithError.Validate(user);

            Assert.Equal(expected, actual.Errors);
        }

        [Theory(DisplayName = "Functional MessageDTO validation tests")]
        [ClassData(typeof(MessageDTOTestDataGenerator))]
        public void ValidateMessageTest(MessageDTO message, bool expected)
        {
            var actual = validator.Validate(message);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Functional MessageDTO validation tests [TError]")]
        [ClassData(typeof(MessageDTOTestDataGenerator_TError))]
        public void ValidateMessageTest_TError(MessageDTO message, string[] expected)
        {
            var actual = validatorWithError.Validate(message);

            Assert.Equal(expected, actual.Errors);
        }

        [Theory(DisplayName = "Functional AdvertDTO validation tests")]
        [ClassData(typeof(AdvertDTOTestDataGenerator))]
        public void ValidateAdvertTest(AdvertDTO advert, bool expected)
        {
            var actual = validator.Validate(advert);

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Functional AdvertDTO validation tests [TError]")]
        [ClassData(typeof(AdvertDTOTestDataGenerator_TError))]
        public void ValidateAdvertTest_TError(AdvertDTO advert, string[] expected)
        {
            var actual = validatorWithError.Validate(advert);

            Assert.Equal(expected, actual.Errors);
        }

        [Fact(DisplayName = "Functional object null test")]
        public void ValidateNullObject()
        {
            UserDTO user = null;

            var ex = Assert.Throws<ArgumentNullException>(() => validatorWithError.Validate(user));

            Assert.Equal("target", ex.ParamName);
        }

        [Fact(DisplayName = "Functional object null test [TError]")]
        public void ValidateNullObject_TError()
        {
            UserDTO user = null;

            var ex = Assert.Throws<ArgumentNullException>(() => validatorWithError.Validate(user));

            Assert.Equal("target", ex.ParamName);
        }
    }
}