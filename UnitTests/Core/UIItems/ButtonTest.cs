using NUnit.Framework;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems
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
        public void RaiseClickEvent()
        {
            button.RaiseClickEvent();
        }
    }
}