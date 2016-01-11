using System;
using System.Collections.Generic;
using System.IO;
using TestStack.White.Bricks;
using TestStack.White.Configuration;

namespace TestStack.White.ScreenObjects.Configuration
{
    public class RepositoryAppXmlConfiguration : AssemblyConfiguration, IRepositoryConfiguration
    {
        public static IRepositoryConfiguration instance;

        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();
        private const string UseHistoryKey = "UseHistory";
        private const string ServiceCallHistoryLocationKey = "ServiceCallHistoryLocation";
        private const string RecordFlowKey = "RecordFlow";

        static RepositoryAppXmlConfiguration()
        {
            DefaultValues[RecordFlowKey] = false;
            DefaultValues[ServiceCallHistoryLocationKey] = ".";
            DefaultValues[UseHistoryKey] = false;
        }

        public static IRepositoryConfiguration Instance
        {
            get { return instance ?? (instance = new RepositoryAppXmlConfiguration()); }
        }

        private RepositoryAppXmlConfiguration() : base("White", "Repository", DefaultValues, 
            CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(RepositoryAppXmlConfiguration))) {}

        public virtual bool RecordFlow
        {
            get { return Convert.ToBoolean(UsedValues[RecordFlowKey]); }
        }

        public virtual DirectoryInfo ServiceCallHistoryLocation
        {
            get { return new DirectoryInfo(UsedValues[ServiceCallHistoryLocationKey]); }
        }

        public virtual bool UseHistory
        {
            get { return Convert.ToBoolean(UsedValues[UseHistoryKey]); }
        }
    }
}