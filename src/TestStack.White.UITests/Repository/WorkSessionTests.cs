using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UITests.Infrastructure;

namespace TestStack.White.UITests.Repository
{
    [TestFixture]
    public class WorkSessionTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            // Set the worksession path to the current assemblys directory
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            CoreAppXmlConfiguration.Instance.WorkSessionLocation = new DirectoryInfo(currentAssemblyDirectory);
        }

        [Test]
        public void ShouldNotSaveAnyWindowInformationToFileWhenNoWindowsAreLaunched()
        {
            var numberOfFilesBeforeSessionStart = NumberOfFiles();
            using (WorkSession()) { }
            Assert.That(NumberOfFiles(), Is.EqualTo(numberOfFilesBeforeSessionStart));
        }

        [Test]
        public void ShouldSaveWindowInformationInFile()
        {
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            var fooFile = Path.Combine(currentAssemblyDirectory, "foo.xml");
            File.Delete(fooFile);
            using (var workSession = WorkSession())
            {
                var application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                var window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
            Assert.That(File.Exists(fooFile), Is.True);
        }

        [Test]
        public void ShouldFindControlBasedLocation()
        {
            File.Delete("foo.xml");
            using (var workSession = WorkSession())
            {
                var application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                var window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
            using (var workSession = WorkSession())
            {
                var application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                var window = application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("ButtonWithTooltip");
            }
        }

        private static WorkSession WorkSession()
        {
            return new WorkSession(new WorkConfiguration(), new NullWorkEnvironment());
        }

        private static int NumberOfFiles()
        {
            return Directory.GetFiles(".").Length;
        }
    }
}