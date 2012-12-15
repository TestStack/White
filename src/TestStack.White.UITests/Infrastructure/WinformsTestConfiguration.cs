using System.IO;
using System.Reflection;

namespace TestStack.White.UITests.Infrastructure
{
    public class WinformsTestConfiguration : TestConfiguration
    {
        protected override string ApplicationExe
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WindowsFormsTestApplication.exe");
            }
        }

        public override string MainWindowTitle
        {
            get { return "Form1"; }
        }
    }
}