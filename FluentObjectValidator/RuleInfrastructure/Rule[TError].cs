using System;

namespace FluentObjectValidator.RuleInfrastructure
{
    internal sealed class Rule<TObject, TSelectorResult, TError> : ChainNode<ValidationContext<TObject, TError>>
    {
        public Func<TObject, TSelectorResult> Selector { get; set; }

        public Func<TSelectorResult, bool> Predicate { get; set; }

        public Func<TError> ErrorCreator { get; set; }

        public bool StopValidationOnError { get; set; }

        public bool TerminateValidationOnError { get; set; }

        public override void HandleRequest(ValidationContext<TObject, TError> requestContext)
        {
            var isValid = Predicate(Selector(requestContext.Target));

            if (!isValid)
            {
                requestContext.AddError(ErrorCreator());

                if (TerminateValidationOnError)
                {
                    requestContext.IsTerminationRequested = true;
                    return;
                }

                if (StopValidationOnError)
                {
                    return;
                }
            }

            base.HandleRequest(requestContext);
        }
    }
}