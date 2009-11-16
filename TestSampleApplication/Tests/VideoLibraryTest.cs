using Core;
using Core.Factory;
using Core.UIItems.WindowItems;
using NUnit.Framework;

namespace TestSampleApplication.Tests
{
    public class VideoLibraryTest
    {
        protected Application application;
        protected Window window;

        [SetUp]
        public void SetUp()
        {
            application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
            window = application.GetWindow("Dashboard", InitializeOption.NoCache);
            TestSpecificSetup();
        }

        protected virtual void TestSpecificSetup()
        {
        }

        [TearDown]
        public void CloseApplication()
        {
            if (application != null) application.Kill();
        }
    }
}