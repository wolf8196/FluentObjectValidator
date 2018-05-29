using System;
using System.Collections.Generic;
using FluentObjectValidator.Tests.Functional.DTOs;

namespace FluentObjectValidator.Tests.Functional.TestDataGenerators
{
    public class MessageDTOTestDataGenerator : BaseTestDataGenerator<MessageDTO>
    {
        public MessageDTOTestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "test"), true),
                Transform(CreateObject(null, 1, new DateTime(2018, 1, 1), "test"), false),
                Transform(CreateObject(0, 1, new DateTime(2018, 1, 1), "test"), true),
                Transform(CreateObject(1, null, new DateTime(2018, 1, 1), "test"), false),
                Transform(CreateObject(1, 0, new DateTime(2018, 1, 1), "test"), true),
                Transform(CreateObject(1, 1, new DateTime(), "test"), false),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), null), false),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), ""), false),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "     "), false),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "t"), true),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "testtestte"), true),
                Transform(CreateObject(1, 1, new DateTime(2018, 1, 1), "testtesttest"), false),
                Transform(CreateObject(null, null, new DateTime(), null), false),
                Transform(CreateObject(null, 1, new DateTime(), "testtesttest"), false)
            };
        }

        protected MessageDTO CreateObject(long? senderId, long? receiverId, DateTime date, string text)
        {
            return new MessageDTO
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Date = date,
                Text = text
            };
        }
    }
}