using TestStack.White.Reporting.Configuration;
using TestStack.White.Reporting.Domain;

namespace TestStack.White.ScreenObjects.Sessions
{
    public class WorkConfiguration
    {
        private string archiveLocation;
        private string name;

        public virtual string ArchiveLocation
        {
            get { return archiveLocation; }
            set { archiveLocation = value; }
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual IReport CreateSessionReport()
        {
            if (ReportingConfigurationLocator.Get().PublishTestReports)
                return new SessionReport(archiveLocation, name);
            return new NullSessionReport();
        }
    }
}