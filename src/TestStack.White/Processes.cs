using System.Collections.Generic;
using System.Diagnostics;

namespace TestStack.White
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