using System.Diagnostics;
using System.IO;
using System.Reflection;
using Castle.DynamicProxy;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

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

        public override IMainWindow GetMainWindow(Application application)
        {
            var window = application.GetWindow(SearchCriteria.ByFramework(framework.FrameworkId()).AndByText("MainWindow"), InitializeOption.NoCache);
            var mainWindowAdapter = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IMainWindow>(new ForwardIfExistsInterceptor(window));
            return mainWindowAdapter;
        }

        protected abstract string ApplicationExePath();
    }
}