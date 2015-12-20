using TestStack.White.UIItems;

namespace TestStack.White.UITests.Infrastructure
{
    public class WpfTestConfiguration : WindowsConfiguration
    {
        public WpfTestConfiguration()
            : base(WindowsFramework.Wpf)
        {
        }

        protected override string ApplicationExePath
        {
            get { return "WpfTestApplication.exe"; }
        }
    }
}