using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class RuleSet1TestDataGenerator : StringTestDataGenerator
    {
        public RuleSet1TestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(null), false),
                Transform(CreateObject(""), true),
                Transform(CreateObject("      "), true),
                Transform(CreateObject("verylongstring"), false),
                Transform(CreateObject("string"), true)
            };
        }
    }
}