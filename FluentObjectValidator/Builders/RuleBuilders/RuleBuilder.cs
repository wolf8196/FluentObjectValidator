using System;
using FluentObjectValidator.Builders.RuleChainBuilders;

namespace FluentObjectValidator.Builders.RuleBuilders
{
    /// <summary>
    /// Provides functionality for adding validation rules.
    /// </summary>
    /// <typeparam name="TObject">The type of the object under validation.</typeparam>
    /// <typeparam name="TSelectorResult">The type of the selector result.</typeparam>
    public class RuleBuilder<TObject, TSelectorResult> : BaseRuleBuilder<TObject, TSelectorResult>
    {
        internal RuleBuilder(RuleChainBuilder<TObject, TSelectorResult> ruleChainBuilder)
            : base(ruleChainBuilder)
        {
        }

        /// <summary>
        /// Adds a new validation rule defined by <paramref name="predicate"/>.
        /// </summary>
        /// <param name="predicate">Predicate that defines the validation rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, TSelectorResult}"/> instance so that multiple calls can be chained.</returns>
        public RuleBuilder<TObject, TSelectorResult> HasRule(Func<TSelectorResult, bool> predicate)
        {
            RuleChainBuilder.HasRule(predicate);
            return this;
        }
    }
}