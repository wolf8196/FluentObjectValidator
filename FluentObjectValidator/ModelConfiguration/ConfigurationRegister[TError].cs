using System;
using System.Collections.Generic;
using FluentObjectValidator.Exceptions;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.ModelConfiguration
{
    internal sealed class ConfigurationRegister<TError>
    {
        private Dictionary<Type, object> typeConfigurationDictionary;

        public ConfigurationRegister()
        {
            typeConfigurationDictionary = new Dictionary<Type, object>();
        }

        public ConfigurationRegister<TError> Add<TObject>(ValidationConfiguration<TObject, TError> validationConfiguration)
        {
            typeConfigurationDictionary[typeof(TObject)] = validationConfiguration.RuleChain;
            return this;
        }

        public RuleChain<TObject, TError> GetRuleChain<TObject>(TObject target)
        {
            return GetRuleChain<TObject>();
        }

        public RuleChain<TObject, TError> GetRuleChain<TObject>()
        {
            if (!typeConfigurationDictionary.TryGetValue(typeof(TObject), out object chain))
            {
                throw new ConfigurationNotFoundException(typeof(TObject));
            }

            return (RuleChain<TObject, TError>)chain;
        }
    }
}