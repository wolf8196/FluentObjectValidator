using System.Collections.Generic;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class UserDTOTestDataGenerator : BaseTestDataGenerator<UserDTO>
    {
        public UserDTOTestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject("test", "test@test", "testTEST123"), true),
                Transform(CreateObject(null, "test@test", "testTEST123"), false),
                Transform(CreateObject("", "test@test", "testTEST123"), false),
                Transform(CreateObject("testtesttes", "test@test", "testTEST123"), false),
                Transform(CreateObject("t", "test@test", "testTEST123"), true),
                Transform(CreateObject("test", null, "testTEST123"), false),
                Transform(CreateObject("test", "", "testTEST123"), false),
                Transform(CreateObject("test", "test", "testTEST123"), false),
                Transform(CreateObject("test", "test@", "testTEST123"), false),
                Transform(CreateObject("test", "@test", "testTEST123"), false),
                Transform(CreateObject("test", "test@test", "testTEST123"), true),
                Transform(CreateObject("test", "test@test", null), false),
                Transform(CreateObject("test", "test@test", ""), false),
                Transform(CreateObject("test", "test@test", "teTe2"), false),
                Transform(CreateObject("test", "test@test", "testTe2"), false),
                Transform(CreateObject("test", "test@test", "testTes2"), true),
                Transform(CreateObject("test", "test@test", "testtest"), false),
                Transform(CreateObject("test", "test@test", "TESTTEST"), false),
                Transform(CreateObject("test", "test@test", "testTest"), false),
                Transform(CreateObject("test", "test@test", "testTest2"), true),
                Transform(CreateObject(null, null, null), false),
                Transform(CreateObject(null, "", null), false),
                Transform(CreateObject("", "", ""), false),
                Transform(CreateObject("", "test", "testtest"), false),
                Transform(CreateObject("testtesttest", "test@test", "test"), false),
            };
        }

        protected UserDTO CreateObject(string username, string email, string password)
        {
            return new UserDTO
            {
                UserName = username,
                Email = email,
                Password = password
            };
        }
    }
}