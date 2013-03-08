using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WPFCategory]
    public class UIItemContainerTest : ControlsActionTest
    {
        [Test]
        public void GetMultiple()
        {
            IUIItem[] buttons = Window.GetMultiple(SearchCriteria.ByControlType(typeof(Button), WindowsFramework.Wpf));
            Assert.AreEqual(true, buttons.Length > 10);
        }
    }
}