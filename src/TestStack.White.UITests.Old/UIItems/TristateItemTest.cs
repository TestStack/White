using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WPFCategory]
    public class TristateItemTest : ControlsActionTest
    {
        [Test]
        public void TristateCheckbox()
        {
            var checkBox = Window.Get<CheckBox>("checkBox");
            checkBox.State = ToggleState.Indeterminate;
            Assert.AreEqual(ToggleState.Indeterminate, checkBox.State);
        }

        [Test]
        public void TristateButton()
        {
            var button = Window.Get<Button>("button");
        }
    }
}