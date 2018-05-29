using System.Collections.Generic;

namespace FluentObjectValidator.RuleInfrastructure
{
    internal sealed class ValidationContext<TObject, TError>
    {
        private List<TError> errors;

        public ValidationContext(TObject target)
        {
            Target = target;
            errors = new List<TError>();
        }

        public TObject Target { get; }

        public IEnumerable<TError> Errors => errors;

        public bool IsTerminationRequested { get; set; }

        public void AddError(TError error)
        {
            errors.Add(error);
        }

        public bool IsObjectValid()
        {
            return errors.Count == 0;
        }
    }
}