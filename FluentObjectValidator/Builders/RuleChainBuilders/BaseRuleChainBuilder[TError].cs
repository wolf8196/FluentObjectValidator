using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.Builders.RuleChainBuilders
{
    internal abstract class BaseRuleChainBuilder<TObject, TError>
    {
        public BaseRuleChainBuilder()
        {
            RuleChain = new RuleChain<TObject, TError>();
        }

        public RuleChain<TObject, TError> RuleChain { get; }
    }
}