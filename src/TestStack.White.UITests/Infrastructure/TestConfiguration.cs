using System.Diagnostics;
using White.Core;

namespace TestStack.White.UITests.Infrastructure
{
    public abstract class TestConfiguration
    {
        public virtual Application LaunchApplication()
        {
            var processStartInfo = new ProcessStartInfo
                                       {
                                           FileName = ApplicationExe,
                                           UseShellExecute = false,
                                           CreateNoWindow = true,
                                           RedirectStandardOutput = true,
                                           RedirectStandardError = true
                                       };
            return Application.Launch(processStartInfo);
        }

        protected abstract string ApplicationExe { get; }

        public abstract string MainWindowTitle { get; }
    }
}