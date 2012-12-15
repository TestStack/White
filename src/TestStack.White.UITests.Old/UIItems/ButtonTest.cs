using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WPFUIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class ButtonTest : ControlsActionTest
    {
        private Button button;

        [SetUp]
        public void SetUp()
        {
            button = window.Get<Button>("buton");            
        }

        [Test]
        public void Click()
        {
            button.Click();
            AssertResultLabelText("Button Clicked");
        }

        [Test]
        public void ThrowsWhenNotFound()
        {
            var exception = Assert.Throws<AutomationException>(()=>button.Get<Button>(SearchCriteria.ByAutomationId("foo")));

            Assert.AreEqual("Failed to get ControlType=button,AutomationId=foo", exception.Message);
        }

        [Test]
        public void RaiseClickEvent()
        {
            button.RaiseClickEvent();
        }
    }
}