using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.ListViewItems
{
    [TestFixture, WinFormCategory]
    public class ListViewScenarioTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ListView"; }
        }

        [Fact]
        public void SelectWhenHorizontalScrollIsPresent()
        {
            ListView listView = Window.Get<ListView>("listViewWithHorizontalScroll");
            listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre").Select();
        }
    }
}