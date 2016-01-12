using TestStack.White.Configuration.Readers;

namespace TestStack.White.Reporting.Configuration
{
    public static class ReportingConfigurationLocator
    {
        private static ReportingConfiguration reportingConfiguration;

        public static ReportingConfiguration Get()
        {
            if (reportingConfiguration == null)
            {
                Set(new AppConfigReader("White", "Reporting"));
            }
            return reportingConfiguration;
        }

        public static void Set(IConfigurationReader configurationReader)
        {
            reportingConfiguration = new ReportingConfiguration();
            configurationReader.FillConfigurationFromReader(reportingConfiguration);
        }
    }
}
