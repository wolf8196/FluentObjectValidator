using FluentObjectValidator.Builders.RuleChainBuilders;

namespace FluentObjectValidator.Builders.RuleBuilders
{
    public abstract class BaseRuleBuilder<TObject, TSelectorResult>
    {
        internal BaseRuleBuilder(RuleChainBuilder<TObject, TSelectorResult> ruleChainBuilder)
        {
            RuleChainBuilder = ruleChainBuilder;
        }

        internal RuleChainBuilder<TObject, TSelectorResult> RuleChainBuilder { get; }
    }
}