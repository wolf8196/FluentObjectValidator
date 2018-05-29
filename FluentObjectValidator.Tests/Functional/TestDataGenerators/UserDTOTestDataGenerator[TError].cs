using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class UserDTOTestDataGenerator_TError : UserDTOTestDataGenerator
    {
        public UserDTOTestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject("test", "test@test", "testTEST123")),
                Transform(CreateObject(null, "test@test", "testTEST123"), "UserName IsRequired"),
                Transform(CreateObject("", "test@test", "testTEST123"), "UserName IsRequired"),
                Transform(CreateObject("testtesttes", "test@test", "testTEST123"), "UserName HasMaxLength"),
                Transform(CreateObject("t", "test@test", "testTEST123")),
                Transform(CreateObject("test", null, "testTEST123"), "Email IsRequired"),
                Transform(CreateObject("test", "", "testTEST123"), "Email IsRequired"),
                Transform(CreateObject("test", "test", "testTEST123"), "Email MatchesRegex"),
                Transform(CreateObject("test", "test@", "testTEST123"), "Email MatchesRegex"),
                Transform(CreateObject("test", "@test", "testTEST123"), "Email MatchesRegex"),
                Transform(CreateObject("test", "test@test", "testTEST123")),
                Transform(CreateObject("test", "test@test", null), "Password IsRequired"),
                Transform(CreateObject("test", "test@test", ""), "Password IsRequired"),
                Transform(CreateObject("test", "test@test", "teTe2"), "Password HasMinLength"),
                Transform(CreateObject("test", "test@test", "testTe2"), "Password HasMinLength"),
                Transform(CreateObject("test", "test@test", "testTes2")),
                Transform(CreateObject("test", "test@test", "testtest"), "Password HasUpper", "Password HasNumber"),
                Transform(CreateObject("test", "test@test", "testTest"), "Password HasNumber"),
                Transform(CreateObject("test", "test@test", "TESTTEST2"), "Password HasLower"),
                Transform(CreateObject("test", "test@test", "testTest2")),
                Transform(CreateObject(null, null, null), "UserName IsRequired", "Email IsRequired", "Password IsRequired"),
                Transform(CreateObject(null, "", null), "UserName IsRequired", "Email IsRequired", "Password IsRequired"),
                Transform(CreateObject("", "", ""), "UserName IsRequired", "Email IsRequired", "Password IsRequired"),
                Transform(CreateObject("", "test", "testtest"), "UserName IsRequired",
                                                                "Email MatchesRegex",
                                                                "Password HasUpper",
                                                                "Password HasNumber"),
                Transform(CreateObject("testtesttest", "test@test", "test"), "UserName HasMaxLength",
                                                                             "Password HasMinLength"),
            };
        }
    }
}