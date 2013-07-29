using System.Diagnostics;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Screens;

namespace TestStack.White.UITests.Infrastructure
{
    public abstract class WindowsConfiguration : TestConfiguration
    {
        private readonly WindowsFramework framework;

        protected WindowsConfiguration(WindowsFramework framework)
        {
            this.framework = framework;
        }

        public override Application LaunchApplication()
        {
            var app = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ApplicationExePath());
            var processStartInfo = new ProcessStartInfo
            {
                FileName = app,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            return Application.Launch(processStartInfo);
        }

        public override Window GetMainWindow(Application application)
        {
            return application.GetWindow(Criteria(), InitializeOption.NoCache);
        }

        public override MainScreen GetMainScreen(ScreenRepository repository)
        {
            return repository.Get<MainScreen>(Criteria(), InitializeOption.NoCache);
        }

        SearchCriteria Criteria()
        {
            return SearchCriteria.ByFramework(framework.FrameworkId()).AndByText("MainWindow");
        }

        protected abstract string ApplicationExePath();
    }
}