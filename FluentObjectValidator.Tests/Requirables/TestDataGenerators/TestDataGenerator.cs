using System;
using System.Collections.Generic;
using FluentObjectValidator.Tests.Requirables.DTOs;

namespace FluentObjectValidator.Tests.Requirables.TestDataGenerators
{
    public class TestDataGenerator : BaseTestDataGenerator<RequirableObject>
    {
        public TestDataGenerator()
        {
            Data = new List<object[]>
            {
                Transform(new RequirableObject(), false),
                Transform(CreateObject(x => x.CharNullProp = null), false),
                Transform(CreateObject(x => x.DateTimeNullProp = null), false),
                Transform(CreateObject(x => x.DecimalNullProp = null), false),
                Transform(CreateObject(x => x.DoubleNullProp = null), false),
                Transform(CreateObject(x => x.FloatNullProp = null), false),
                Transform(CreateObject(x => x.IntNullProp = null), false),
                Transform(CreateObject(x => x.LongNullProp = null), false),
                Transform(CreateObject(x => x.SByteNullProp = null), false),
                Transform(CreateObject(x => x.ShortNullProp = null), false),
                Transform(CreateObject(x => x.StructNullProp = null), false),
                Transform(CreateObject(x => x.ClassProp = null), false),

                Transform(CreateObject(x => x.CharProp = '\0'), false),
                Transform(CreateObject(x => x.DateTimeProp = new DateTime()), false),
                Transform(CreateObject(x => x.DecimalProp = 0m), false),
                Transform(CreateObject(x => x.DoubleProp = 0d), false),
                Transform(CreateObject(x => x.FloatProp = 0f), false),
                Transform(CreateObject(x => x.IntProp = 0), false),
                Transform(CreateObject(x => x.LongProp = 0L), false),
                Transform(CreateObject(x => x.SByteProp = 0), false),
                Transform(CreateObject(x => x.ShortProp = 0), false),
                Transform(CreateObject(x => x.StructProp = new NestedStructObject()), false),
                Transform(CreateObject(x => x.StructProp = new NestedStructObject
                {
                    StructIntProp = 0
                }),
                false),

                Transform(CreateObject(x => x.IntNullProp = null, x => x.IntProp = 0), false),

                Transform(CreateObject(
                    x => x.ClassProp = null,
                    x => x.DecimalProp = 0,
                    x => x.DoubleNullProp = null),
                    false),

                Transform(CreateObject(), true)
            };
        }

        protected RequirableObject CreateObject()
        {
            return new RequirableObject
            {
                CharNullProp = 'a',
                CharProp = 'a',
                ClassProp = new NestedClassObject(),
                DateTimeNullProp = new DateTime(1980, 1, 1),
                DateTimeProp = new DateTime(1980, 1, 1),
                DecimalNullProp = 1,
                DecimalProp = 1,
                DoubleNullProp = 1,
                DoubleProp = 1,
                FloatNullProp = 1,
                FloatProp = 1,
                IntNullProp = 1,
                IntProp = 1,
                LongNullProp = 1,
                LongProp = 1,
                SByteNullProp = 1,
                SByteProp = 1,
                ShortNullProp = 1,
                ShortProp = 1,
                StructNullProp = new NestedStructObject
                {
                    StructIntProp = 1
                },
                StructProp = new NestedStructObject
                {
                    StructIntProp = 1
                }
            };
        }

        protected RequirableObject CreateObject(params Action<RequirableObject>[] actions)
        {
            var obj = CreateObject();

            foreach (var action in actions)
            {
                action(obj);
            }

            return obj;
        }
    }
}