using System;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator
{
    /// <summary>
    /// Provides validation functionality for configured types
    /// </summary>
    /// <typeparam name="TError">The type of the validation error.</typeparam>
    /// <seealso cref="FluentObjectValidator.IValidator{TError}" />
    public abstract class Validator<TError> : IValidator<TError>
    {
        private ConfigurationRegister<TError> configurationRegister;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator{TError}"/> class.
        /// </summary>
        protected Validator()
        {
            configurationRegister = new ConfigurationRegister<TError>();
        }

        /// <summary>
        /// Validates the specified target object.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="target">The target object to validate.</param>
        /// <returns>
        /// The result of the validation with errors of type <typeparamref name="TError" />
        /// </returns>
        /// <exception cref="Exceptions.ConfigurationNotFoundException">
        /// Thrown when no configuration was found for type <typeparamref name="TObject"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when object under validation is null.
        /// </exception>
        public ValidationResult<TError> Validate<TObject>(TObject target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var context = new ValidationContext<TObject, TError>(target);
            var chain = configurationRegister.GetRuleChain(target);

            chain.HandleRequest(context);

            var result = new ValidationResult<TError>
            {
                IsValid = context.IsObjectValid(),
                Errors = context.Errors
            };

            return result;
        }

        /// <summary>
        /// Adds the specified validation configuration.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="configuration">The validation configuration.</param>
        protected void AddConfiguration<TObject>(ValidationConfiguration<TObject, TError> configuration)
        {
            configurationRegister.Add(configuration);
        }
    }
}