using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Automation;
using White.Core;

namespace Recorder.Domain
{
    public class Applications : List<Application>
    {
        public Applications(AutomationElementCollection automationElementCollection)
        {
            Processes processes = new Processes(Process.GetProcesses());
            foreach (AutomationElement element in automationElementCollection)
            {
                Process dotnetProcess = processes.Find(delegate(Process process) { return process.Id.Equals(element.Current.ProcessId); });
                Application application = Application.Attach(dotnetProcess);
                if (!Contains(application)) Add(application);
            }
        }
    }
}