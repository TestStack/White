using System;
using System.Collections.Generic;
using TestStack.White.Utility;

namespace TestStack.White.Configuration
{
    /// <summary>
    /// Base class for configurations
    /// </summary>
    public abstract class ConfigurationBase
    {
        /// <summary>
        /// Dictionary which holds the current values
        /// </summary>
        protected readonly Dictionary<string, string> ConfigurationValues = new Dictionary<string, string>();

        /// <summary>
        /// Temporarily override some configuration values
        /// </summary>
        public virtual IDisposable ApplyTemporarySetting(Action<ConfigurationBase> changes)
        {
            var existing = new Dictionary<string, string>(ConfigurationValues);
            changes(this);

            return new DelegateDisposable(() =>
            {
                foreach (var value in existing)
                {
                    SetValue(value.Key, value.Value);
                }
            });
        }

        /// <summary>
        /// Set the value for the given key
        /// </summary>
        public void SetValue(string key, object value)
        {
            ConfigurationValues[key] = value.ToString();
        }

        /// <summary>
        /// Get the value for the given key
        /// </summary>
        public string GetValue(string key)
        {
            return ConfigurationValues[key];
        }

        /// <summary>
        /// Get the value converted to int32 for the given key
        /// </summary>
        public int GetValueInt32(string key)
        {
            return Convert.ToInt32(GetValue(key));
        }

        /// <summary>
        /// Get the value converted to boolean for the given key
        /// </summary>
        public bool GetValueBoolean(string key)
        {
            return Convert.ToBoolean(GetValue(key));
        }

        /// <summary>
        /// Dictionary with the default values
        /// </summary>
        public abstract Dictionary<string, object> DefaultValues { get; }
    }
}
