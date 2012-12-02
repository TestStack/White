using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using log4net;

namespace White.Core.Bricks
{
    public class AssemblyConfiguration
    {
        protected readonly Dictionary<string, string> usedValues = new Dictionary<string, string>();

        protected AssemblyConfiguration() { }

        protected AssemblyConfiguration(string sectionGroup, string sectionName, Dictionary<string, object> defaultValues, ILog logger)
        {
            var nameValues = (NameValueCollection)ConfigurationManager.GetSection(sectionGroup + "/" + sectionName);
            if (logger == null) logger = LogManager.GetLogger(typeof (AssemblyConfiguration));
            if (nameValues == null)
            {
                nameValues = new NameValueCollection();
            }
            CreateConfiguration(defaultValues, nameValues);
            foreach (KeyValuePair<string, string> pair in usedValues)
                logger.InfoFormat("Using {0}={1} for {2}/{3}", pair.Key, pair.Value, sectionGroup, sectionName);
        }

        protected AssemblyConfiguration(Dictionary<string, object> defaultValues, ILog logger)
        {
            NameValueCollection nameValues = ConfigurationManager.AppSettings;
            CreateConfiguration(defaultValues, nameValues);
            foreach (KeyValuePair<string, string> pair in usedValues)
                logger.InfoFormat("Using {0}={1}", pair.Key, pair.Value);
        }

        private void CreateConfiguration(Dictionary<string, object> defaultValues, NameValueCollection nameValues)
        {
            foreach (KeyValuePair<string, object> pair in defaultValues)
                usedValues.Add(pair.Key, pair.Value.ToString());
            foreach (string key in nameValues.AllKeys)
            {
                string value = nameValues.Get(key);
                if (value != null)
                {
                    usedValues.Remove(key);
                    usedValues[key] = value;
                }
            }

            var allKeys = new List<string>(nameValues.AllKeys);
            allKeys.AddRange(defaultValues.Keys);

            foreach (string key in allKeys)
            {
                string value = ConfigurationManager.AppSettings[key];
                if (value != null)
                {
                    usedValues.Remove(key);
                    usedValues[key] = value;
                }
            }
        }
    }
}