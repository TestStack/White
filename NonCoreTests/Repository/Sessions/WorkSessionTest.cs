using System.IO;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using Repository.Services;
using Repository.Sessions;

namespace Repository.Sessions
{
    [TestFixture, NormalCategory]
    public class WorkSessionTest
    {
        [Test]
        public void Should_not_save_any_window_information_to_file_when_no_windows_are_launched()
        {
            int numberOfFilesBeforeSessionStart = NumberOfFiles();
            using (WorkSession()){}
            Assert.AreEqual(numberOfFilesBeforeSessionStart, NumberOfFiles());
        }

        [Test]
        public void Should_save_window_information_in_file()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(WinFormTestConfiguration.WinFormsTestAppLocation);
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
        public void Should_find_control_based_location()
        {
            File.Delete("foo.xml");
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(WinFormTestConfiguration.WinFormsTestAppLocation);
                workSession.Attach(application);
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("foo"));
                window.Get<Button>("buton");
                window.Get<Button>("addNode");
            }
            using (WorkSession workSession = WorkSession())
            {
                Application application = Application.Launch(WinFormTestConfiguration.WinFormsTestAppLocation);
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