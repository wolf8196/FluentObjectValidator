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
    /// <typeparam name="TError">The type of the validation error.</typeparam>
    public abstract class ValidationConfiguration<TObject, TError>
    {
        private BaseRuleChainBuilder<TObject, TError> ruleChainBuilder;
        private RuleChain<TObject, TError> chainOfChains;

        internal RuleChain<TObject, TError> RuleChain => chainOfChains;

        /// <summary>
        /// Starts a process of adding rules to the object under validation.
        /// </summary>
        /// <returns>Rule builder for the object under validation.</returns>
        /// <remarks>Shortcut for the <c>Property(x => x)</c> call.</remarks>
        protected RuleBuilder<TObject, TObject, TError> Object()
        {
            var builder = CreateChainBuilder(x => x);

            return new RuleBuilder<TObject, TObject, TError>(builder);
        }

        /// <summary>
        /// Starts a process of adding rules to the specified property.
        /// </summary>
        /// <typeparam name="TSelectorResult">The type of the selected property.</typeparam>
        /// <param name="selector">The property selector.</param>
        /// <returns>Rule builder for the selected property.</returns>
        protected RuleBuilder<TObject, TSelectorResult, TError> Property<TSelectorResult>(Func<TObject, TSelectorResult> selector)
        {
            var builder = CreateChainBuilder(selector);

            return new RuleBuilder<TObject, TSelectorResult, TError>(builder);
        }

        private RuleChainBuilder<TObject, TSelectorResult, TError> CreateChainBuilder<TSelectorResult>(
            Func<TObject, TSelectorResult> selector)
        {
            var builder = new RuleChainBuilder<TObject, TSelectorResult, TError>(selector);

            if (chainOfChains == null)
            {
                chainOfChains = new RuleChain<TObject, TError>();
            }

            chainOfChains.AddNode(builder.RuleChain);

            ruleChainBuilder = builder;

            return builder;
        }
    }
}