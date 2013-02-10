using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class CheckBoxTest : ControlsActionTest
    {
        [Test]
        public void SelectUnSelect()
        {
            var checkBox = Window.Get<CheckBox>("chequeBox");
            Assert.AreEqual(false, checkBox.IsSelected);
            checkBox.Select();
            Assert.AreEqual(true, checkBox.IsSelected);
            checkBox.UnSelect();
            Assert.AreEqual(false, checkBox.IsSelected);
        }

        [Test]
        public void ClickOnCheckBoxWhichLaunchesModalWindow()
        {
            Window.Get<CheckBox>("checkBoxLaunchedModalWindow").Checked = true;
            CloseModal(Window);
        }
    }
}