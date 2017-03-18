using System;

namespace TestStack.White.Configuration
{
    /// <summary>
    /// Base class for a configuration reader
    /// </summary>
    public abstract class ConfigurationReaderBase
    {
        public void FillConfigurationFromReader(ConfigurationBase configuration)
        {
            // Initialize with default Values
            foreach (var kvp in configuration.DefaultValues)
            {
                configuration.SetValue(kvp.Key, kvp.Value);
            }
            // Custom initialization
            FillConfigurationFromReaderInternal(configuration);
        }

        protected abstract void FillConfigurationFromReaderInternal(ConfigurationBase configuration);
    }
}
