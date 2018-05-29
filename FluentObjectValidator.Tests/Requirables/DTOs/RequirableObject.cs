using System;

namespace FluentObjectValidator.Tests.Requirables.DTOs
{
    public class RequirableObject
    {
        public sbyte SByteProp { get; set; }

        public short ShortProp { get; set; }

        public int IntProp { get; set; }

        public long LongProp { get; set; }

        public float FloatProp { get; set; }

        public double DoubleProp { get; set; }

        public char CharProp { get; set; }

        public decimal DecimalProp { get; set; }

        public DateTime DateTimeProp { get; set; }

        public sbyte? SByteNullProp { get; set; }

        public short? ShortNullProp { get; set; }

        public int? IntNullProp { get; set; }

        public long? LongNullProp { get; set; }

        public float? FloatNullProp { get; set; }

        public double? DoubleNullProp { get; set; }

        public char? CharNullProp { get; set; }

        public decimal? DecimalNullProp { get; set; }

        public DateTime? DateTimeNullProp { get; set; }

        public NestedClassObject ClassProp { get; set; }

        public NestedStructObject StructProp { get; set; }

        public NestedStructObject? StructNullProp { get; set; }
    }
}