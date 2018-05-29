using System;
using System.Collections.Generic;
using FluentObjectValidator.Tests.Requirables.DTOs;

namespace FluentObjectValidator.Tests.Requirables.TestDataGenerators
{
    public class TestDataGenerator_TError : TestDataGenerator
    {
        public TestDataGenerator_TError()
        {
            Data = new List<object[]>
            {
                Transform(new RequirableObject(),
                    "SByteProp", "ShortProp", "IntProp",
                    "LongProp", "FloatProp", "DoubleProp",
                    "CharProp", "DecimalProp", "DateTimeProp",
                    "SByteNullProp", "ShortNullProp", "IntNullProp",
                    "LongNullProp", "FloatNullProp", "DoubleNullProp",
                    "CharNullProp", "DecimalNullProp", "DateTimeNullProp",
                    "ClassProp", "StructProp", "StructNullProp"),
                Transform(CreateObject(x => x.CharNullProp = null), "CharNullProp"),
                Transform(CreateObject(x => x.DateTimeNullProp = null), "DateTimeNullProp"),
                Transform(CreateObject(x => x.DecimalNullProp = null), "DecimalNullProp"),
                Transform(CreateObject(x => x.DoubleNullProp = null), "DoubleNullProp"),
                Transform(CreateObject(x => x.FloatNullProp = null), "FloatNullProp"),
                Transform(CreateObject(x => x.IntNullProp = null), "IntNullProp"),
                Transform(CreateObject(x => x.LongNullProp = null), "LongNullProp"),
                Transform(CreateObject(x => x.SByteNullProp = null), "SByteNullProp"),
                Transform(CreateObject(x => x.ShortNullProp = null), "ShortNullProp"),
                Transform(CreateObject(x => x.StructNullProp = null), "StructNullProp"),
                Transform(CreateObject(x => x.ClassProp = null), "ClassProp"),

                Transform(CreateObject(x => x.CharProp = '\0'), "CharProp"),
                Transform(CreateObject(x => x.DateTimeProp = new DateTime()), "DateTimeProp"),
                Transform(CreateObject(x => x.DecimalProp = 0m), "DecimalProp"),
                Transform(CreateObject(x => x.DoubleProp = 0d), "DoubleProp"),
                Transform(CreateObject(x => x.FloatProp = 0f), "FloatProp"),
                Transform(CreateObject(x => x.IntProp = 0), "IntProp"),
                Transform(CreateObject(x => x.LongProp = 0L), "LongProp"),
                Transform(CreateObject(x => x.SByteProp = 0), "SByteProp"),
                Transform(CreateObject(x => x.ShortProp = 0), "ShortProp"),
                Transform(CreateObject(x => x.StructProp = new NestedStructObject()), "StructProp"),
                Transform(CreateObject(x => x.StructProp = new NestedStructObject
                {
                    StructIntProp = 0
                }), "StructProp"),

                Transform(CreateObject(x => x.IntNullProp = null, x => x.IntProp = 0), "IntProp", "IntNullProp"),

                Transform(CreateObject(
                    x => x.ClassProp = null,
                    x => x.DecimalProp = 0,
                    x => x.DoubleNullProp = null),
                    "DecimalProp", "DoubleNullProp", "ClassProp"),

                Transform(CreateObject())
            };
        }
    }
}