using System.Collections.Generic;
using Bricks;
using Bricks.Core;
using White.Core.Logging;

namespace Reporting.Configuration
{
    public class ReportingAppXmlConfiguration : AssemblyConfiguration, ReportingConfiguration
    {
        private static ReportingConfiguration instance;

        private static readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();

        static ReportingAppXmlConfiguration()
        {
            defaultValues.Add("PublishTestReports", true);
        }

        private ReportingAppXmlConfiguration() : base("White", "Reporting", defaultValues, WhiteLogger.Instance) {}

        public static ReportingConfiguration Instance
        {
            get
            {
                if (instance == null) instance = new ReportingAppXmlConfiguration();
                return instance;
            }
        }

        public virtual bool PublishTestReports
        {
            get { return S.ToBool(usedValues["PublishTestReports"]); }
        }
    }
}