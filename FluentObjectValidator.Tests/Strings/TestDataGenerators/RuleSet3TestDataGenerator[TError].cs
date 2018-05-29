using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Strings.TestDataGenerators
{
    public class RuleSet3TestDataGenerator_TError : StringTestDataGenerator
    {
        public RuleSet3TestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(null), "IsRequired"),
                Transform(CreateObject(""), "IsRequired"),
                Transform(CreateObject("str"), "HasLengthInRange", "MatchesRegex"),
                Transform(CreateObject("verlylongstring"), "HasLengthInRange", "MatchesRegex"),
                Transform(CreateObject("string"), "MatchesRegex"),
                Transform(CreateObject("teststring"))
            };
        }
    }
}