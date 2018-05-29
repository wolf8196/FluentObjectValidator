using System;
using FluentObjectValidator.Builders.RuleChainBuilders;

namespace FluentObjectValidator.Builders.RuleBuilders
{
    /// <summary>
    /// Provides functionality for adding validation rules.
    /// </summary>
    /// <typeparam name="TObject">The type of the object under validation.</typeparam>
    /// <typeparam name="TSelectorResult">The type of the selector result.</typeparam>
    /// <typeparam name="TError">The type of the validation error.</typeparam>
    public class RuleBuilder<TObject, TSelectorResult, TError> : BaseRuleBuilder<TObject, TSelectorResult, TError>
    {
        internal RuleBuilder(RuleChainBuilder<TObject, TSelectorResult, TError> ruleChainBuilder)
            : base(ruleChainBuilder)
        {
        }

        /// <summary>
        /// Adds a new validation rule.
        /// </summary>
        /// <param name="predicate">Predicate that defines the validation rule.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/>.</param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, TSelectorResult, TError}"/> instance so that multiple calls can be chained.</returns>
        public RuleBuilder<TObject, TSelectorResult, TError> HasRule(
            Func<TSelectorResult, bool> predicate,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            RuleChainBuilder.HasRule(predicate, errorCreator, stopValidationOnError, terminateValidationOnError);
            return this;
        }
    }
}