using System;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.Builders.RuleChainBuilders
{
    internal sealed class RuleChainBuilder<TObject, TSelectorResult, TError> : BaseRuleChainBuilder<TObject, TError>
    {
        private Func<TObject, TSelectorResult> selector;

        public RuleChainBuilder(Func<TObject, TSelectorResult> selector)
        {
            this.selector = selector;
        }

        public RuleChainBuilder<TObject, TSelectorResult, TError> HasRule(
            Func<TSelectorResult, bool> predicate,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            RuleChain.AddNode(new Rule<TObject, TSelectorResult, TError>
            {
                Selector = selector,
                Predicate = predicate,
                ErrorCreator = errorCreator,
                StopValidationOnError = stopValidationOnError,
                TerminateValidationOnError = terminateValidationOnError
            });

            return this;
        }
    }
}