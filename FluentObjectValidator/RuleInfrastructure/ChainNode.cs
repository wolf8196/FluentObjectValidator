namespace FluentObjectValidator.RuleInfrastructure
{
    internal class ChainNode<TRequestContext>
    {
        public ChainNode<TRequestContext> Successor { get; set; }

        public virtual void HandleRequest(TRequestContext requestContext)
        {
            if (Successor != null)
            {
                Successor.HandleRequest(requestContext);
            }
        }
    }
}