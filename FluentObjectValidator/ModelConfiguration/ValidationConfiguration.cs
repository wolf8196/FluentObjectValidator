using System;
using FluentObjectValidator.Builders.RuleBuilders;
using FluentObjectValidator.Builders.RuleChainBuilders;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.ModelConfiguration
{
    /// <summary>
    /// Provides functionality for configuring validation rules for objects of type <typeparamref name="TObject"/>.
    /// </summary>
    /// <typeparam name="TObject">The type of objects the configuration is responsible for.</typeparam>
    public abstract class ValidationConfiguration<TObject>
    {
        private BaseRuleChainBuilder<TObject> ruleChainBuilder;

        internal RuleChain<TObject> RuleChain { get; private set; }

        /// <summary>
        /// Starts a process of adding rules to the object under validation.
        /// </summary>
        /// <returns>Rule builder for the object under validation.</returns>
        /// <remarks>Shortcut for the <c>Property(x => x)</c> call.</remarks>
        protected RuleBuilder<TObject, TObject> Object()
        {
            var builder = CreateChainBuilder(x => x);

            return new RuleBuilder<TObject, TObject>(builder);
        }

        /// <summary>
        /// Starts a process of adding rules to the specified property.
        /// </summary>
        /// <typeparam name="TSelectorResult">The type of the selected property.</typeparam>
        /// <param name="selector">The property selector.</param>
        /// <returns>Rule builder for the selected property.</returns>
        protected RuleBuilder<TObject, TSelectorResult> Property<TSelectorResult>(Func<TObject, TSelectorResult> selector)
        {
            var builder = CreateChainBuilder(selector);

            return new RuleBuilder<TObject, TSelectorResult>(builder);
        }

        private RuleChainBuilder<TObject, TSelectorResult> CreateChainBuilder<TSelectorResult>(
            Func<TObject, TSelectorResult> selector)
        {
            ruleChainBuilder = new RuleChainBuilder<TObject, TSelectorResult>(selector, ruleChainBuilder?.RuleChain);
            RuleChain = ruleChainBuilder.RuleChain;

            return (RuleChainBuilder<TObject, TSelectorResult>)ruleChainBuilder;
        }
    }
}