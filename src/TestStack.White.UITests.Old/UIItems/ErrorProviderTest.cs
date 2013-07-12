using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UITests.Testing;
using Xunit;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ErrorProviderTest : ControlsActionTest
    {
        [Test, Ignore]
        public void HasError()
        {
            Window.Get<Button>("showError").Click();
            var comboBox = Window.Get<ComboBox>("komboBox");
            Assert.Equal("The name is wrong", comboBox.ErrorProviderMessage(Window));
        }
    }
}