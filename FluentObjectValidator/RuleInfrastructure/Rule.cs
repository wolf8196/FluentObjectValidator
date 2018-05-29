using System;

namespace FluentObjectValidator.RuleInfrastructure
{
    internal sealed class Rule<TObject, TSelectorResult> : ChainNode<ValidationContext<TObject>>
    {
        public Func<TObject, TSelectorResult> Selector { get; set; }

        public Func<TSelectorResult, bool> Predicate { get; set; }

        public override void HandleRequest(ValidationContext<TObject> requestContext)
        {
            requestContext.IsObjectValid = Predicate(Selector(requestContext.Target));

            if (!requestContext.IsObjectValid)
            {
                return;
            }

            base.HandleRequest(requestContext);
        }
    }
}