using System;

namespace FluentObjectValidator.Exceptions
{
    /// <summary>
    /// The exception that is thrown when there is not configuration for an object under validation.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public sealed class ConfigurationNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationNotFoundException"/> class.
        /// </summary>
        /// <param name="type">The type of the object under validation.</param>
        public ConfigurationNotFoundException(Type type)
            : base($"No configuration found for type '{type.FullName}'")
        {
        }
    }
}