using System.IO;
using TestStack.White.Factory;
using TestStack.White.Repository.Services;
using TestStack.White.Repository.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Infrastructure;
using Xunit;

namespace TestStack.White.Repository.UITests.Sessions
{
    public class WorkSessionTest
    {
        [Fact]
        public void ShouldNotSaveAnyWindowInformationToFileWhenNoWindowsAreLaunched()
        {
            int numberOfFilesBeforeSessionStart = NumberOfFiles();
            using (WorkSession()){}
            Assert.Equal(numberOfFilesBeforeSessionStart, NumberOfFiles());
        }

        [Fact]
        public void ShouldSaveWindowInformationInFile()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
            }
            Assert.Equal(true, File.Exists("foo.xml"));
        }

        private static WorkSession WorkSession()
        {
            return new WorkSession(new WorkConfiguration(), new NullWorkEnvironment());
        }

        [Fact]
        public void ShouldFindControlBasedLocation()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
                window.Get<Button>("addNode");
            }
            using (WorkSession workSession = WorkSession())
            {
                Application application = new WinformsTestConfiguration().LaunchApplication();
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
                window.Get<Button>("addNode");
            }
        }

        private static int NumberOfFiles()
        {
            return Directory.GetFiles(".").Length;
        }
    }
}