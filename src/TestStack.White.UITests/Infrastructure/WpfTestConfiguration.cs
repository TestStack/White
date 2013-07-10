using White.Core.UIItems;

namespace TestStack.White.UITests.Infrastructure
{
    public class WpfTestConfiguration : WindowsConfiguration
    {
        public WpfTestConfiguration()
            : base(WindowsFramework.Wpf)
        {
        }

        protected override string ApplicationExePath()
        {
            return "WpfTestApplication.exe";
        }
    }
}