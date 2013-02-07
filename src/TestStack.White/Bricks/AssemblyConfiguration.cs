using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using Castle.Core.Logging;

namespace White.Core.Bricks
{
    public class AssemblyConfiguration
    {
        protected readonly Dictionary<string, string> UsedValues = new Dictionary<string, string>();

        protected AssemblyConfiguration() { }

        protected AssemblyConfiguration(string sectionGroup, string sectionName, Dictionary<string, object> defaultValues, ILogger logger)
        {
            var nameValues = (NameValueCollection)ConfigurationManager.GetSection(sectionGroup + "/" + sectionName);
            if (logger == null) logger = new TraceLogger(typeof (AssemblyConfiguration).Name);
            if (nameValues == null)
            {
                nameValues = new NameValueCollection();
            }
            CreateConfiguration(defaultValues, nameValues);
            foreach (KeyValuePair<string, string> pair in UsedValues)
                logger.InfoFormat("Using {0}={1} for {2}/{3}", pair.Key, pair.Value, sectionGroup, sectionName);
        }

        protected AssemblyConfiguration(Dictionary<string, object> defaultValues, ILogger logger)
        {
            NameValueCollection nameValues = ConfigurationManager.AppSettings;
            CreateConfiguration(defaultValues, nameValues);
            foreach (KeyValuePair<string, string> pair in UsedValues)
                logger.InfoFormat("Using {0}={1}", pair.Key, pair.Value);
        }

        private void CreateConfiguration(Dictionary<string, object> defaultValues, NameValueCollection nameValues)
        {
            foreach (KeyValuePair<string, object> pair in defaultValues)
                UsedValues.Add(pair.Key, pair.Value.ToString());
            foreach (string key in nameValues.AllKeys)
            {
                string value = nameValues.Get(key);
                if (value != null)
                {
                    UsedValues.Remove(key);
                    UsedValues[key] = value;
                }
            }

            var allKeys = new List<string>(nameValues.AllKeys);
            allKeys.AddRange(defaultValues.Keys);

            foreach (string key in allKeys)
            {
                string value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    UsedValues.Remove(key);
                    UsedValues[key] = value;
                }
            }
        }
    }
}