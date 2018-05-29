using System;
using System.Collections.Generic;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class MessageDTOTestDataGenerator_TError : MessageDTOTestDataGenerator
    {
        public MessageDTOTestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "test")),
                Transform(CreateObject(null, 1, new DateTime(2018, 1, 1), "test"), "SenderId IsRequired"),
                Transform(CreateObject(0, 1, new DateTime(2018, 1, 1), "test")),
                Transform(CreateObject(1, null, new DateTime(2018, 1, 1), "test"), "ReceiverId IsRequired"),
                Transform(CreateObject(1, 0, new DateTime(2018, 1, 1), "test")),
                Transform(CreateObject(1, 1, new DateTime(), "test"), "Date IsRequired"),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), null), "Text IsRequired"),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), ""), "Text IsRequired"),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "     "), "Text IsRequired"),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "t")),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "testtestte")),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "testtesttest"), "Text HasLengthInRange"),
                Transform(CreateObject(null, null, new DateTime(), null), "SenderId IsRequired",
                                                                          "ReceiverId IsRequired",
                                                                          "Date IsRequired",
                                                                          "Text IsRequired"),
                Transform(CreateObject(null, 1, new DateTime(), "testtesttest"), "SenderId IsRequired",
                                                                                 "Date IsRequired",
                                                                                 "Text HasLengthInRange")
            };
        }
    }
}