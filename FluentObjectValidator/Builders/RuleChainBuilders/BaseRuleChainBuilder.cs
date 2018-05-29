using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.Builders.RuleChainBuilders
{
    internal abstract class BaseRuleChainBuilder<TObject>
    {
        public BaseRuleChainBuilder(RuleChain<TObject> ruleChain)
        {
            RuleChain = ruleChain ?? new RuleChain<TObject>();
        }

        public RuleChain<TObject> RuleChain { get; }
    }
}