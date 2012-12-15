using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class ComboBoxOpeningUpTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return WPFScenarioSet1; }
        }

        [Test]
        public void SelectVisibleItem()
        {
            var comboBox = window.Get<ComboBox>("comboBox1");
            comboBox.Select("U");
            Assert.AreEqual("U", comboBox.SelectedItemText);
            comboBox.Select("Z");
            Assert.AreEqual("Z", comboBox.SelectedItemText);
        }
    }
}