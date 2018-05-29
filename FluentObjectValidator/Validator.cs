using System;
using FluentObjectValidator.ModelConfiguration;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator
{
    /// <summary>
    /// Provides validation functionality for configured types
    /// </summary>
    /// <seealso cref="FluentObjectValidator.IValidator" />
    public abstract class Validator : IValidator
    {
        private ConfigurationRegister configurationRegister;

        /// <summary>
        /// Initializes a new instance of the <see cref="Validator"/> class.
        /// </summary>
        protected Validator()
        {
            configurationRegister = new ConfigurationRegister();
        }

        /// <summary>
        /// Validates the specified target object.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="target">The target object to validate.</param>
        /// <returns>
        ///   <c>true</c> if the validation passed; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="Exceptions.ConfigurationNotFoundException">
        /// Thrown when no configuration was found for type <typeparamref name="TObject"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when object under validation is null.
        /// </exception>
        public bool Validate<TObject>(TObject target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var context = new ValidationContext<TObject>(target);
            var chain = configurationRegister.GetRuleChain(target);

            chain.HandleRequest(context);

            return context.IsObjectValid;
        }

        /// <summary>
        /// Adds the specified validation configuration.
        /// </summary>
        /// <typeparam name="TObject">The type of the target object.</typeparam>
        /// <param name="configuration">The validation configuration.</param>
        protected void AddConfiguration<TObject>(ValidationConfiguration<TObject> configuration)
        {
            configurationRegister.Add(configuration);
        }
    }
}