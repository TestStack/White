using System.Collections.Generic;
using System.IO;
using Bricks;
using Bricks.Core;
using log4net;

namespace Repository.Configuration
{
    public class RepositoryAppXmlConfiguration : AssemblyConfiguration, RepositoryConfiguration
    {
        public static RepositoryConfiguration instance;

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

        public static RepositoryConfiguration Instance
        {
            get { return instance ?? (instance = new RepositoryAppXmlConfiguration()); }
        }

        private RepositoryAppXmlConfiguration() : base("White", "Repository", DefaultValues, LogManager.GetLogger(typeof(RepositoryAppXmlConfiguration))) {}

        public virtual bool RecordFlow
        {
            get { return S.ToBool(usedValues[RecordFlowKey]); }
        }

        public virtual DirectoryInfo ServiceCallHistoryLocation
        {
            get { return new DirectoryInfo(usedValues[ServiceCallHistoryLocationKey]); }
        }

        public virtual bool UseHistory
        {
            get { return S.ToBool(usedValues[UseHistoryKey]); }
        }
    }
}