using System.Collections.Generic;
using TestStack.White.Configuration;

namespace TestStack.White.Reporting.Configuration
{
    public class ReportingConfiguration : ConfigurationBase<ReportingConfiguration>
    {
        private const string PublishTestReportsKey = "PublishTestReports";

        public override Dictionary<string, object> DefaultValues
        {
            get
            {
                return new Dictionary<string, object>
                {
                    {PublishTestReportsKey, true}
                };
            }
        }

        public virtual bool PublishTestReports
        {
            get { return GetValueBoolean(PublishTestReportsKey); }
            set { SetValue(PublishTestReportsKey, value); }
        }
    }
}