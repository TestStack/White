using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ErrorProviderTest : ControlsActionTest
    {
        [Test, Ignore]
        public void HasError()
        {
            window.Get<Button>("showError").Click();
            var comboBox = window.Get<ComboBox>("komboBox");
            Assert.AreEqual("The name is wrong", comboBox.ErrorProviderMessage(window));
        }
    }
}