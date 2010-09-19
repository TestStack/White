using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class RadioButtonTest : ControlsActionTest
    {
        [Test]
        public void SelectSingleRadioButton()
        {
            var radioButton = window.Get<RadioButton>("radioButton1");
            Assert.AreEqual(false, radioButton.IsSelected);
            radioButton.Select();
            Assert.AreEqual(true, radioButton.IsSelected);
        }

        [Test]
        public void SelectRadioButtonGroup()
        {
            var radioButton1 = window.Get<RadioButton>("radioButton1");
            var radioButton2 = window.Get<RadioButton>("radioButton2");

            Assert.AreEqual(false, radioButton1.IsSelected && radioButton2.IsSelected);

            radioButton1.Select();
            Assert.AreEqual(true, radioButton1.IsSelected);
            Assert.AreEqual(false, radioButton2.IsSelected);

            radioButton2.Select();

            Assert.AreEqual(false, radioButton1.IsSelected);
            Assert.AreEqual(true, radioButton2.IsSelected);
        }
    }
}