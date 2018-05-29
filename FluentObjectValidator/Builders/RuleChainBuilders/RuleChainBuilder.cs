using System;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.Builders.RuleChainBuilders
{
    internal sealed class RuleChainBuilder<TObject, TSelectorResult> : BaseRuleChainBuilder<TObject>
    {
        private Func<TObject, TSelectorResult> selector;

        public RuleChainBuilder(Func<TObject, TSelectorResult> selector)
            : this(selector, null)
        {
        }

        public RuleChainBuilder(Func<TObject, TSelectorResult> selector, RuleChain<TObject> ruleChain)
            : base(ruleChain)
        {
            this.selector = selector;
        }

        public RuleChainBuilder<TObject, TSelectorResult> HasRule(Func<TSelectorResult, bool> predicate)
        {
            RuleChain.AddNode(new Rule<TObject, TSelectorResult>
            {
                Selector = selector,
                Predicate = predicate
            });

            return this;
        }
    }
}