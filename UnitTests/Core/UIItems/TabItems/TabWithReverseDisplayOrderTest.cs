using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TabItems
{
    [TestFixture, WinFormCategory]
    public class TabWithReverseDisplayOrderTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ReverseTab"; }
        }

        [Test]
        public void SelectTab()
        {
            Tab tab = window.Get<Tab>("tabControl1");
            tab.SelectTabPage("tabPage2");
            Assert.AreEqual("tabPage2", tab.SelectedTab.ToString());
            tab.SelectTabPage("tabPage1");
            Assert.AreEqual("tabPage1", tab.SelectedTab.ToString());
        }
    }
}