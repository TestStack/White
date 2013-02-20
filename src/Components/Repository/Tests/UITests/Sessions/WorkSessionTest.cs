using System.IO;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using White.Core.UITests;
using White.Repository.Services;
using White.Repository.Sessions;

namespace White.Repository.UITests.Sessions
{
    [TestFixture]
    public class WorkSessionTest
    {
        [Test]
        public void ShouldNotSaveAnyWindowInformationToFileWhenNoWindowsAreLaunched()
        {
            int numberOfFilesBeforeSessionStart = NumberOfFiles();
            using (WorkSession()){}
            Assert.AreEqual(numberOfFilesBeforeSessionStart, NumberOfFiles());
        }

        [Test]
        public void ShouldSaveWindowInformationInFile()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(TestConfiguration.WinFormsTestAppLocation);
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
            }
            Assert.AreEqual(true, File.Exists("foo.xml"));
        }

        private static WorkSession WorkSession()
        {
            return new WorkSession(new WorkConfiguration(), new NullWorkEnvironment());
        }

        [Test]
        public void ShouldFindCONTROLBasedLocation()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(TestConfiguration.WinFormsTestAppLocation);
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
                window.Get<Button>("addNode");
            }
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(TestConfiguration.WinFormsTestAppLocation);
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