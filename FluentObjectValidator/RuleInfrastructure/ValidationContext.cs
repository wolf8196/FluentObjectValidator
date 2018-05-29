namespace FluentObjectValidator.RuleInfrastructure
{
    internal sealed class ValidationContext<TObject>
    {
        public ValidationContext(TObject target)
        {
            Target = target;
            IsObjectValid = true;
        }

        public TObject Target { get; }

        public bool IsObjectValid { get; set; }
    }
}