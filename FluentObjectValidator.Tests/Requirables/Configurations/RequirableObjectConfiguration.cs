using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.Requirables.DTOs;

namespace FluentObjectValidator.Tests.Requirables.Configurations
{
    public class RequirableObjectConfiguration : ValidationConfiguration<RequirableObject>
    {
        public RequirableObjectConfiguration()
        {
            Property(x => x.SByteProp)
                .IsRequired();

            Property(x => x.ShortProp)
                .IsRequired();

            Property(x => x.IntProp)
                .IsRequired();

            Property(x => x.LongProp)
                .IsRequired();

            Property(x => x.FloatProp)
                .IsRequired();

            Property(x => x.DoubleProp)
                .IsRequired();

            Property(x => x.CharProp)
                .IsRequired();

            Property(x => x.DecimalProp)
                .IsRequired();

            Property(x => x.DateTimeProp)
                .IsRequired();

            Property(x => x.SByteNullProp)
                .IsRequired();

            Property(x => x.ShortNullProp)
                .IsRequired();

            Property(x => x.IntNullProp)
                .IsRequired();

            Property(x => x.LongNullProp)
                .IsRequired();

            Property(x => x.FloatNullProp)
                .IsRequired();

            Property(x => x.DoubleNullProp)
                .IsRequired();

            Property(x => x.CharNullProp)
                .IsRequired();

            Property(x => x.DecimalNullProp)
                .IsRequired();

            Property(x => x.DateTimeNullProp)
                .IsRequired();

            Property(x => x.ClassProp)
                .IsRequired();

            Property(x => x.StructProp)
                .IsRequired();

            Property(x => x.StructNullProp)
                .IsRequired();
        }
    }
}