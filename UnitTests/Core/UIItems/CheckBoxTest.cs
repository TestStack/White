using NUnit.Framework;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems
{
    [TestFixture]
    public class CheckBoxTest : ControlsActionTest
    {
        [Test]
        public void SelectUnSelect()
        {
            var checkBox = window.Get<CheckBox>("chequeBox");
            Assert.AreEqual(false, checkBox.IsSelected);
            checkBox.Select();
            Assert.AreEqual(true, checkBox.IsSelected);
            checkBox.UnSelect();
            Assert.AreEqual(false, checkBox.IsSelected);
        }

        [Test]
        public void ClickOnCheckBoxWhichLaunchesModalWindow()
        {
            window.Get<CheckBox>("checkBoxLaunchedModalWindow").Checked = true;
            CloseModal(window);
        }
    }
}