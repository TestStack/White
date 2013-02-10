using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListViewItems
{
    [TestFixture, WinFormCategory]
    public class ListViewScenarioTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ListView"; }
        }

        [Test]
        public void SelectWhenHorizontalScrollIsPresent()
        {
            ListView listView = Window.Get<ListView>("listViewWithHorizontalScroll");
            listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre").Select();
        }
    }
}