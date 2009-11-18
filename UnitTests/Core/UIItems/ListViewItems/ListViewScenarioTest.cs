using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.ListViewItems
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
            ListView listView = window.Get<ListView>("listViewWithHorizontalScroll");
            listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre").Select();
        }
    }
}