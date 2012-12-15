using System.IO;
using System.Reflection;

namespace TestStack.White.UITests.Infrastructure
{
    public class WpfTestConfiguration : TestConfiguration
    {
        protected override string ApplicationExe
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WpfTestApplication.exe");
            }
        }

        public override string MainWindowTitle
        {
            get { return "MainWindow"; }
        }
    }
}