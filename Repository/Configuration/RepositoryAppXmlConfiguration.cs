using System.Collections.Generic;
using System.IO;
using Bricks;
using Bricks.Core;
using White.Core.Logging;

namespace Repository.Configuration
{
    public class RepositoryAppXmlConfiguration : AssemblyConfiguration, RepositoryConfiguration
    {
        public static RepositoryConfiguration instance;

        private static readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();
        private const string useHistoryKey = "UseHistory";
        private const string serviceCallHistoryLocationKey = "ServiceCallHistoryLocation";
        private const string recordFlowKey = "RecordFlow";

        static RepositoryAppXmlConfiguration()
        {
            defaultValues[recordFlowKey] = false;
            defaultValues[serviceCallHistoryLocationKey] = ".";
            defaultValues[useHistoryKey] = false;
        }

        public static RepositoryConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new RepositoryAppXmlConfiguration();
                return instance;
            }
        }

        private RepositoryAppXmlConfiguration() : base("White", "Repository", defaultValues, WhiteLogger.Instance) {}

        public virtual bool RecordFlow
        {
            get { return S.ToBool(usedValues[recordFlowKey]); }
        }

        public virtual DirectoryInfo ServiceCallHistoryLocation
        {
            get { return new DirectoryInfo(usedValues[serviceCallHistoryLocationKey]); }
        }

        public virtual bool UseHistory
        {
            get { return S.ToBool(usedValues[useHistoryKey]); }
        }
    }
}