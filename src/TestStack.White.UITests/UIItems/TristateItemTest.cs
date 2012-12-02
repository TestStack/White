using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WPFCategory]
    public class TristateItemTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "TristateControlWindow"; }
        }

        [Test]
        public void TristateCheckbox()
        {
            var checkBox = window.Get<CheckBox>("checkBox");
            checkBox.State = ToggleState.Indeterminate;
            Assert.AreEqual(ToggleState.Indeterminate, checkBox.State);
        }

        [Test]
        public void TristateButton()
        {
            var button = window.Get<Button>("button");
        }
    }
}