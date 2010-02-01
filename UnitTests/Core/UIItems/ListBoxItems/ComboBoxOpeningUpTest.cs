using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.ListBoxItems
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