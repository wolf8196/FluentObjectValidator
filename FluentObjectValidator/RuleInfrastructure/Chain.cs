namespace FluentObjectValidator.RuleInfrastructure
{
    internal class Chain<TRequestContext> : ChainNode<TRequestContext>
    {
        private ChainNode<TRequestContext> firstChainNode;
        private ChainNode<TRequestContext> lastChainNode;

        public Chain()
        {
            firstChainNode = null;
            lastChainNode = null;
            Count = 0;
        }

        public int Count { get; set; }

        public void AddNode(ChainNode<TRequestContext> node)
        {
            if (firstChainNode == null)
            {
                firstChainNode = node;
                lastChainNode = node;
            }
            else
            {
                lastChainNode.Successor = node;
                lastChainNode = lastChainNode.Successor;
            }

            ++Count;
        }

        public override void HandleRequest(TRequestContext requestContext)
        {
            if (firstChainNode != null)
            {
                firstChainNode.HandleRequest(requestContext);
            }

            base.HandleRequest(requestContext);
        }
    }
}