using NUnit.Framework;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TabItems
{
    [TestFixture, WinFormCategory]
    public class TabWithReverseDisplayOrderTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ReverseTab"; }
        }

        [Fact]
        public void SelectTab()
        {
            Tab tab = Window.Get<Tab>("tabControl1");
            tab.SelectTabPage("tabPage2");
            Assert.Equal("tabPage2", tab.SelectedTab.ToString());
            tab.SelectTabPage("tabPage1");
            Assert.Equal("tabPage1", tab.SelectedTab.ToString());
        }
    }
}