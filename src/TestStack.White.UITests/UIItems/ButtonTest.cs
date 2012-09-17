using System.Windows.Automation;
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
        public void FindNonExistent()
        {
            var box = button.Get<TextBox>(SearchCriteria.ByAutomationId("foo"));
            Assert.AreEqual(null, box);
        }

        [Test]
        public void FindViaNativeProperty()
        {
            var box = button.Get<TextBox>(SearchCriteria.ByNativeProperty(AutomationElement.AutomationIdProperty, "foo"));
            Assert.AreEqual(null, box);
        }

        [Test]
        public void RaiseClickEvent()
        {
            button.RaiseClickEvent();
        }
    }
}