using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace TestStack.White.Configuration.Readers
{
    /// <summary>
    /// Configuration reader which reads from the app.config file
    /// </summary>
    public class AppConfigReader : IConfigurationReader
    {
        private NameValueCollection nameValues;

        public AppConfigReader(string sectionGroup, string sectionName)
        {
            nameValues = (NameValueCollection)ConfigurationManager.GetSection(sectionGroup + "/" + sectionName);
            if (nameValues == null)
            {
                nameValues = new NameValueCollection();
            }
        }

        public void FillConfigurationFromReader(IConfiguration configuration)
        {
            // Overwrite the values contained in the section
            foreach (var key in nameValues.AllKeys)
            {
                var value = nameValues.Get(key);
                if (value != null)
                {
                    configuration.SetValue(key, value);
                }
            }
            // Overwrite the values from the AppSettings (if available)
            var allKeys = new List<string>(nameValues.AllKeys);
            allKeys.AddRange(configuration.DefaultValues.Keys);
            foreach (var key in allKeys)
            {
                var value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    configuration.SetValue(key, value);
                }
            }
        }
    }
}