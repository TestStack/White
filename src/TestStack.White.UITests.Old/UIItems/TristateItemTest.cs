using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WPFCategory]
    public class TristateItemTest : ControlsActionTest
    {
        [Fact]
        public void TristateCheckbox()
        {
            var checkBox = Window.Get<CheckBox>("checkBox");
            checkBox.State = ToggleState.Indeterminate;
            Assert.Equal(ToggleState.Indeterminate, checkBox.State);
        }

        [Fact]
        public void TristateButton()
        {
            var button = Window.Get<Button>("button");
        }
    }
}