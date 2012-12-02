using System.Collections.Generic;
using System.Diagnostics;

namespace White.Core
{
    public class Processes : List<Process>
    {
        public Processes(Process[] processes)
        {
            foreach (Process process in processes)
                Add(process);
        }
    }
}