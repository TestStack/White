using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture]
    public class ButtonTest : ControlsActionTest
    {
        [Test]
        public void Click()
        {
            var button = window.Get<Button>("buton");
            button.Click();
            AssertResultLabelText("Button Clicked");
        }
    }
}