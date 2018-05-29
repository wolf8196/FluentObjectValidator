using System.Collections.Generic;

namespace FluentObjectValidator
{
    /// <summary>
    /// Represents the result of the validation.
    /// </summary>
    /// <typeparam name="TError">The type of the validation error.</typeparam>
    public sealed class ValidationResult<TError>
    {
        /// <summary>
        /// Gets a value indicating whether the validation passed.
        /// </summary>
        public bool IsValid { get; internal set; }

        /// <summary>
        /// Gets a collection containing the errors of the validation.
        /// </summary>
        public IEnumerable<TError> Errors { get; internal set; }
    }
}