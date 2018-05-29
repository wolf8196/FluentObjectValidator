namespace FluentObjectValidator.RuleInfrastructure
{
    internal sealed class RuleChain<TObject, TError> : Chain<ValidationContext<TObject, TError>>
    {
        public override void HandleRequest(ValidationContext<TObject, TError> requestContext)
        {
            if (requestContext.IsTerminationRequested)
            {
                return;
            }

            base.HandleRequest(requestContext);
        }
    }
}