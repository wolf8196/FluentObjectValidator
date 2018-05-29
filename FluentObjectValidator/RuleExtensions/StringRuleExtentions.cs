using System;
using System.Text.RegularExpressions;
using FluentObjectValidator.Builders.RuleBuilders;

namespace FluentObjectValidator.RuleExtensions
{
    /// <summary>
    /// Provides extension methods for defining type <see cref="string"/> specific validation rules.
    /// </summary>
    public static class StringRuleExtentions
    {
        /// <summary>
        /// Adds a new validation rule to check whether a string is not null or empty.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        /// <remarks>Does not allow empty strings.</remarks>
        public static RuleBuilder<TObject, string> IsRequired<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder)
        {
            ruleBuilder.HasRule(x => x != null && x.Trim().Length != 0);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string is not null or empty.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="allowEmptyString">Specifies whether to allow empty strings.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> IsRequired<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            bool allowEmptyString)
        {
            ruleBuilder.HasRule(x => x != null && (allowEmptyString || x.Trim().Length != 0));
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is not less that the specified <paramref name="length"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="length">Minimal length of the string.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> HasMinLength<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            int length)
        {
            ruleBuilder.HasRule(x => x.Length >= length);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is not greater that the specified <paramref name="length"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="length">Maximal length of the string.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> HasMaxLength<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            int length)
        {
            ruleBuilder.HasRule(x => x.Length <= length);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is in the specified range.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="min">Minimal length of the string.</param>
        /// <param name="max">Maximal length of the string.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> HasLengthInRange<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            int min,
            int max)
        {
            ruleBuilder.HasRule(x => x.Length >= min && x.Length <= max);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string matches the specified pattern.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> MatchesRegex<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            string pattern)
        {
            ruleBuilder.HasRule(x => Regex.Match(x, pattern).Success);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string matches the specified regular expression.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="regex">The regular expression.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string> MatchesRegex<TObject>(
            this RuleBuilder<TObject, string> ruleBuilder,
            Regex regex)
        {
            ruleBuilder.HasRule(x => regex.Match(x).Success);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string is not null or empty.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        /// <remarks>
        /// Does not allow empty strings.
        /// Stops the validation for current selector if the object does not pass this rule.
        /// </remarks>
        public static RuleBuilder<TObject, string, TError> IsRequired<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            Func<TError> errorCreator,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(
                x => x != null && x.Trim().Length != 0,
                errorCreator,
                stopValidationOnError: true,
                terminateValidationOnError: terminateValidationOnError);

            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string is not null or empty.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="allowEmptyString">Specifies whether to allow empty strings.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        /// <remarks>
        /// Stops the validation for current selector if the object does not pass this rule.
        /// </remarks>
        public static RuleBuilder<TObject, string, TError> IsRequired<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            bool allowEmptyString,
            Func<TError> errorCreator,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(
                x => x != null && (allowEmptyString || x.Trim().Length != 0),
                errorCreator,
                stopValidationOnError: true,
                terminateValidationOnError: terminateValidationOnError);

            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is not less that the specified <paramref name="length"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="length">Minimal length of the string.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string, TError> HasMinLength<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            int length,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(x => x.Length >= length, errorCreator, stopValidationOnError, terminateValidationOnError);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is not greater that the specified <paramref name="length"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="length">Maximal length of the string.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string, TError> HasMaxLength<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            int length,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(x => x.Length <= length, errorCreator, stopValidationOnError, terminateValidationOnError);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string length is in the specified range.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="min">Minimal length of the string.</param>
        /// <param name="max">Maximal length of the string.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string, TError> HasLengthInRange<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            int min,
            int max,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(x => x.Length >= min && x.Length <= max, errorCreator, stopValidationOnError, terminateValidationOnError);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string matches the specified pattern.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string, TError> MatchesRegex<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            string pattern,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(x => Regex.Match(x, pattern).Success, errorCreator, stopValidationOnError, terminateValidationOnError);
            return ruleBuilder;
        }

        /// <summary>
        /// Adds a new validation rule to check whether a string matches the specified regular expression.
        /// </summary>
        /// <typeparam name="TObject">The type of the object under validation.</typeparam>
        /// <typeparam name="TError">The type of the error.</typeparam>
        /// <param name="ruleBuilder">Current rule builder to add the rule to.</param>
        /// <param name="regex">The regular expression.</param>
        /// <param name="errorCreator">Function to create new objects of type <typeparamref name="TError"/></param>
        /// <param name="stopValidationOnError">Specifies whether to stop the validation for current selector if it does not pass the rule.</param>
        /// <param name="terminateValidationOnError">Specifies whether to stop the validation for the whole current object if it does not pass the rule.</param>
        /// <returns>The same <see cref="RuleBuilder{TObject, string, TError}"/> instance so that multiple calls can be chained.</returns>
        public static RuleBuilder<TObject, string, TError> MatchesRegex<TObject, TError>(
            this RuleBuilder<TObject, string, TError> ruleBuilder,
            Regex regex,
            Func<TError> errorCreator,
            bool stopValidationOnError = false,
            bool terminateValidationOnError = false)
        {
            ruleBuilder.HasRule(x => regex.Match(x).Success, errorCreator, stopValidationOnError, terminateValidationOnError);
            return ruleBuilder;
        }
    }
}