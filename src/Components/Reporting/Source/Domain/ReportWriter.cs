using System.IO;
using Reporting.Utility;

namespace Reporting.Domain
{
    public class ReportWriter
    {
        public static void Write(SubFlows subFlows, string location)
        {
            if (!subFlows.IsEmpty())
            {
                string fileName = string.Format(@"{0}\{1}-{2}.html", location, "Report", subFlows.FlowName);
                File.WriteAllText(fileName, HtmlGenerator.GenerateReport(subFlows));
            }
        }
    }
}