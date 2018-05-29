using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleExtensions;
using FluentObjectValidator.Tests.FlowBreaker.DTOs;

namespace FluentObjectValidator.Tests.FlowBreaker.Configurations
{
    public class FlowBreakerConfiguration_TError : ValidationConfiguration<FlowDTO, string>
    {
        public FlowBreakerConfiguration_TError()
        {
            Property(x => x.IntProp1)
                .IsRequired(() => "IntProp1 IsRequired");

            Property(x => x.IntProp2)
                .IsRequired(() => "IntProp2 IsRequired")
                .HasRule(x => x > 10, () => "IntProp2 HasRule More 10", stopValidationOnError: true)
                .HasRule(x => x > 20, () => "IntProp2 HasRule More 20");

            Property(x => x.IntProp3)
                .IsRequired(() => "IntProp3 IsRequired")
                .HasRule(x => x > 10, () => "IntProp3 HasRule More 10", terminateValidationOnError: true);

            Property(x => x.IntProp4)
                .IsRequired(() => "IntProp4 IsRequired")
                .HasRule(x => x > 10, () => "IntProp4 HasRule More 10")
                .HasRule(x => x > 20, () => "IntProp4 HasRule More 20");
        }
    }
}