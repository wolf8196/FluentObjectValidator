using FluentObjectValidator.Builders.RuleChainBuilders;

namespace FluentObjectValidator.Builders.RuleBuilders
{
    public abstract class BaseRuleBuilder<TObject, TSelectorResult, TError>
    {
        internal BaseRuleBuilder(RuleChainBuilder<TObject, TSelectorResult, TError> ruleChainBuilder)
        {
            RuleChainBuilder = ruleChainBuilder;
        }

        internal RuleChainBuilder<TObject, TSelectorResult, TError> RuleChainBuilder { get; }
    }
}