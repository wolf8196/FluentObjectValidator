using System;
using System.Collections.Generic;
using FluentObjectValidator.Builders.RuleBuilders;

namespace FluentObjectValidator.RuleExtensions
{
    /// <summary>
    /// Provides extension methods for defining a rule to check whether a selected property does not equal to its default value.
    /// </summary>
    public static class RequirableExtentions
    {
        /// <summary>
        /// Provides functionality for defining a rule to check whether a selected property of type <typeparamref name="TSelectorResult"/> does not equal to its default value.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TSelectorResult">The type of the selector result.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, TSelectorResult}"/> instance so that multiple calls can be chained.</returns>
        /// <remarks>Rule uses default <see cref="EqualityComparer{T}"/> to check for equality with the default value of type <typeparamref name="TSelectorResult"/>.</remarks>
        public static RuleBuilder<TObject, TSelectorResult> IsRequired<TObject, TSelectorResult>(
            this RuleBuilder<TObject, TSelectorResult> ruleBuilder)
        {
            ruleBuilder.HasRule(x => !EqualityComparer<TSelectorResult>.Default.Equals(x, default));
            return ruleBuilder;
        }

        /// <summary>
        /// Provides functionality for defining a rule to check whether a selected property of type <typeparamref name="TSelectorResult"/> does not equal to its default value.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <typeparam name="TSelectorResult">The type of the selector result.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, TSelectorResult, TError}"/> instance so that multiple calls can be chained.</returns>
        /// <remarks>
        /// Rule uses default <see cref="EqualityComparer{T}"/> to check for equality with the default value of type <typeparamref name="TSelectorResult"/>.
        /// Stops the validation for current selector if the object does not pass this rule.
        /// </remarks>
        public static RuleBuilder<TObject, TSelectorResult, TError> IsRequired<TObject, TSelectorResult, TError>(
                            this RuleBuilder<TObject, TSelectorResult, TError> ruleBuilder,
                            Func<TError> errorCreator,
                            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(
                x => !EqualityComparer<TSelectorResult>.Default.Equals(x, default),
                errorCreator,
                stopValidationOnError: true,
                terminateValidationOnError: terminateValidationOnError);

            return ruleBuilder;
        }
    }
}