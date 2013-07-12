using TestStack.White.UIItems;

namespace TestStack.White.UITests.Infrastructure
{
    public class WinformsTestConfiguration : WindowsConfiguration
    {
        public WinformsTestConfiguration()
            : base(WindowsFramework.WinForms)
        {
        }

        protected override string ApplicationExePath()
        {
            return "WindowsFormsTestApplication.exe";
        }
    }
}