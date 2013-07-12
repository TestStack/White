using System.Collections.Generic;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests.Factory
{
    public class InitializeOptionTest : WhiteTestBase
    {
        public InitializeOptionTest()
        {
            if (File.Exists("foo.xml"))
                File.Delete("foo.xml");
        }

        public void IdentifiedByCreatesAFile()
        {
            File.Delete("foo.xml");
            Window window = Application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("Foo"));
            window.Get<Button>("ButtonWithTooltip").Click();
            Application.ApplicationSession.Save();
            Assert.Equal(true, File.Exists("foo.xml"));
        }

        public void Dispose()
        {
            File.Delete("foo.xml");
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(IdentifiedByCreatesAFile);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}