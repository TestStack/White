namespace TestStack.White.UITests.Infrastructure
{
    public class WpfTestConfiguration : WindowsConfiguration
    {
        protected override string ApplicationExePath()
        {
            return "WpfTestApplication.exe";
        }

        protected override string MainWindowTitle()
        {
            return "MainWindow";
        }
    }

    
}