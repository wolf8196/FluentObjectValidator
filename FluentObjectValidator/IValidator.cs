namespace FluentObjectValidator
{
    /// <summary>
    /// Defines a generalized method to validate an object.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates the specified target object.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="target">The target object to validate.</param>
        /// <returns>
        ///   <c>true</c> if the validation passed; otherwise, <c>false</c>.
        /// </returns>
        bool Validate<TObject>(TObject target);
    }
}