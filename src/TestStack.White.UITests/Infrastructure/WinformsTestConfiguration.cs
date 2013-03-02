namespace TestStack.White.UITests.Infrastructure
{
    public class WinformsTestConfiguration : WindowsConfiguration
    {
        protected override string ApplicationExePath()
        {
            return "WindowsFormsTestApplication.exe";
        }

        protected override string MainWindowTitle()
        {
            return "Form1";
        }
    }
}