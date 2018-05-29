namespace FluentObjectValidator
{
    /// <summary>
    /// Defines a generalized method to validate an object.
    /// </summary>
    /// <typeparam name="TError">The type of the validation error.</typeparam>
    public interface IValidator<TError>
    {
        /// <summary>
        /// Validates the specified target object.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="target">The target object to validate.</param>
        /// <returns>The result of the validation with errors of type <typeparamref name="TError"/></returns>
        ValidationResult<TError> Validate<TObject>(TObject target);
    }
}