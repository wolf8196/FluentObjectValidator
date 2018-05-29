using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class RuleSet23TestDataGenerator : StringTestDataGenerator
    {
        public RuleSet23TestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(null), false),
                Transform(CreateObject(""), false),
                Transform(CreateObject("      "), false),
                Transform(CreateObject("str"), false),
                Transform(CreateObject("verlylongstring"), false),
                Transform(CreateObject("teststring"), true)
            };
        }
    }
}