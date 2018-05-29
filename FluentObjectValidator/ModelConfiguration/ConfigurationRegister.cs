using System;
using System.Collections.Generic;
using FluentObjectValidator.Exceptions;
using FluentObjectValidator.RuleInfrastructure;

namespace FluentObjectValidator.ModelConfiguration
{
    internal sealed class ConfigurationRegister
    {
        private Dictionary<Type, object> typeConfigurationDictionary;

        public ConfigurationRegister()
        {
            typeConfigurationDictionary = new Dictionary<Type, object>();
        }

        public ConfigurationRegister Add<TObject>(ValidationConfiguration<TObject> validationConfiguration)
        {
            typeConfigurationDictionary[typeof(TObject)] = validationConfiguration.RuleChain;
            return this;
        }

        public RuleChain<TObject> GetRuleChain<TObject>(TObject target)
        {
            return GetRuleChain<TObject>();
        }

        public RuleChain<TObject> GetRuleChain<TObject>()
        {
            if (!typeConfigurationDictionary.TryGetValue(typeof(TObject), out object chain))
            {
                throw new ConfigurationNotFoundException(typeof(TObject));
            }

            return (RuleChain<TObject>)chain;
        }
    }
}