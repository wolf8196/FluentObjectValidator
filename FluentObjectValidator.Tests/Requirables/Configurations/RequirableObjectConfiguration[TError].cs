using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Requirables.DTOs;

namespace FluentObjectValidator.Tests.Requirables.Configurations
{
    public class RequirableObjectConfiguration_TError : ValidationConfiguration<RequirableObject, string>
    {
        public RequirableObjectConfiguration_TError()
        {
            Property(x => x.SByteProp)
                .IsRequired(() => "SByteProp");

            Property(x => x.ShortProp)
                .IsRequired(() => "ShortProp");

            Property(x => x.IntProp)
                .IsRequired(() => "IntProp");

            Property(x => x.LongProp)
                .IsRequired(() => "LongProp");

            Property(x => x.FloatProp)
                .IsRequired(() => "FloatProp");

            Property(x => x.DoubleProp)
                .IsRequired(() => "DoubleProp");

            Property(x => x.CharProp)
                .IsRequired(() => "CharProp");

            Property(x => x.DecimalProp)
                .IsRequired(() => "DecimalProp");

            Property(x => x.DateTimeProp)
                .IsRequired(() => "DateTimeProp");

            Property(x => x.SByteNullProp)
                .IsRequired(() => "SByteNullProp");

            Property(x => x.ShortNullProp)
                .IsRequired(() => "ShortNullProp");

            Property(x => x.IntNullProp)
                .IsRequired(() => "IntNullProp");

            Property(x => x.LongNullProp)
                .IsRequired(() => "LongNullProp");

            Property(x => x.FloatNullProp)
                .IsRequired(() => "FloatNullProp");

            Property(x => x.DoubleNullProp)
                .IsRequired(() => "DoubleNullProp");

            Property(x => x.CharNullProp)
                .IsRequired(() => "CharNullProp");

            Property(x => x.DecimalNullProp)
                .IsRequired(() => "DecimalNullProp");

            Property(x => x.DateTimeNullProp)
                .IsRequired(() => "DateTimeNullProp");

            Property(x => x.ClassProp)
                .IsRequired(() => "ClassProp");

            Property(x => x.StructProp)
                .IsRequired(() => "StructProp");

            Property(x => x.StructNullProp)
                .IsRequired(() => "StructNullProp");
        }
    }
}