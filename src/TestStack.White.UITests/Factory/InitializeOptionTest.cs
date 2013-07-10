using System.Collections.Generic;
using System.IO;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
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

        public override void Dispose()
        {
            base.Dispose();
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