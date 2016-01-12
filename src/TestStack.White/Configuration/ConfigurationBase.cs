using System;
using System.Collections.Generic;
using TestStack.White.Utility;

namespace TestStack.White.Configuration
{
    /// <summary>
    /// Base class for configurations
    /// </summary>
    public abstract class ConfigurationBase<T> : IConfiguration where T : ConfigurationBase<T>
    {
        /// <summary>
        /// Dictionary which holds the current values
        /// </summary>
        protected readonly Dictionary<string, string> ConfigurationValues = new Dictionary<string, string>();

        protected ConfigurationBase()
        {
            // Initialize with default values
            foreach (var kvp in DefaultValues)
            {
                SetValue(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Temporarily override some configuration values
        /// </summary>
        public virtual IDisposable ApplyTemporarySettings(Action<T> changes)
        {
            var existing = new Dictionary<string, string>(ConfigurationValues);
            changes((T)this);

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
        public virtual void SetValue(string key, object value)
        {
            ConfigurationValues[key] = value.ToString();
        }

        /// <summary>
        /// Get the value for the given key
        /// </summary>
        public virtual string GetValue(string key)
        {
            return ConfigurationValues[key];
        }

        /// <summary>
        /// Get the value converted to int32 for the given key
        /// </summary>
        protected virtual int GetValueInt32(string key)
        {
            return Convert.ToInt32(GetValue(key));
        }

        /// <summary>
        /// Get the value converted to boolean for the given key
        /// </summary>
        protected virtual bool GetValueBoolean(string key)
        {
            return Convert.ToBoolean(GetValue(key));
        }

        /// <summary>
        /// Dictionary with the default values
        /// </summary>
        public abstract Dictionary<string, object> DefaultValues { get; }
    }
}