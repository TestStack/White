using System.Collections.Generic;
using Bricks;
using Bricks.Core;
using log4net;

namespace Reporting.Configuration
{
    public class ReportingAppXmlConfiguration : AssemblyConfiguration, ReportingConfiguration
    {
        private static ReportingConfiguration _instance;

        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static ReportingAppXmlConfiguration()
        {
            DefaultValues.Add("PublishTestReports", true);
        }

        private ReportingAppXmlConfiguration() : base("White", "Reporting", DefaultValues, LogManager.GetLogger(typeof(ReportingAppXmlConfiguration))) {}

        public static ReportingConfiguration Instance
        {
            get
            {
                if (_instance == null) _instance = new ReportingAppXmlConfiguration();
                return _instance;
            }
        }

        public virtual bool PublishTestReports
        {
            get { return S.ToBool(usedValues["PublishTestReports"]); }
        }
    }
}