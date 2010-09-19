using Reporting.Configuration;
using Reporting.Domain;

namespace Repository.Sessions
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
            if (ReportingAppXmlConfiguration.Instance.PublishTestReports)
                return new SessionReport(archiveLocation, name);
            return new NullSessionReport();
        }
    }
}