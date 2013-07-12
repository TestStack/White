using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public class RadioButtonTest : ControlsActionTest
    {
        [Fact]
        public void SelectSingleRadioButton()
        {
            var radioButton = Window.Get<RadioButton>("radioButton1");
            Assert.Equal(false, radioButton.IsSelected);
            radioButton.Select();
            Assert.Equal(true, radioButton.IsSelected);
        }

        [Fact]
        public void SelectRadioButtonGroup()
        {
            var radioButton1 = Window.Get<RadioButton>("radioButton1");
            var radioButton2 = Window.Get<RadioButton>("radioButton2");

            Assert.Equal(false, radioButton1.IsSelected && radioButton2.IsSelected);

            radioButton1.Select();
            Assert.Equal(true, radioButton1.IsSelected);
            Assert.Equal(false, radioButton2.IsSelected);

            radioButton2.Select();

            Assert.Equal(false, radioButton1.IsSelected);
            Assert.Equal(true, radioButton2.IsSelected);
        }
    }
}