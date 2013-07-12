using White.Core;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.WebBrowser.Silverlight;
using White.Core.UIA;
using Xunit;

namespace White.WebBrowser.UITests.Silverlight
{
    public class SilverlightDocumentTest : SilverlightTestFixture
    {
        private SilverlightDocument document;
        private Label label;

        [Fact]
        public void Get()
        {
            var button = document.Get<Button>("button");
            Assert.NotEqual(null, button);
        }

        protected override void PostSetup()
        {
            document = BrowserWindow.SilverlightDocument;
            label = document.Get<Label>("status");
        }

        [Fact(Skip = "Ignoring broken tests in silverlight for the moment")]
        public void Event()
        {
            Assert.NotEqual(null, label);
            var button = document.Get<Button>("button");
            button.Click();
            Assert.Equal("0", label.Text);
        }

        [Fact]
        public void TestComboBox()
        {
            var comboBox = document.Get<ComboBox>("combo");
            Assert.Equal(2, comboBox.Items.Count);
            Assert.Equal("foo", comboBox.Items[0].Text);
        }

        [Fact(Skip = "Ignoring broken tests in silverlight for the moment")]
        public void Tooltip()
        {
            var button = document.Get<Button>("button");
            ToolTip toolTip = document.GetToolTipOn(button);
            Assert.Equal(null, toolTip);

            var comboBox = document.Get<ComboBox>("combo");
            toolTip = document.GetToolTipOn(comboBox);
            Assert.NotEqual(null, toolTip);
            Debug.LogPatterns(toolTip);
            Debug.LogProperties(toolTip);
        }

        [Fact(Skip = "Ignoring broken tests in silverlight for the moment")]
        public void SelectItemInComboBoxWhichIsAlreadySelected()
        {
            string previousText = label.Text;
            var button = document.Get<Button>("button");
            var comboBox = document.Get<ComboBox>("combo");
            comboBox.Select("foo");
            comboBox.Select("foo");
            Mouse.Instance.Click(button.Bounds.Center(), document);
            Assert.NotEqual(label.Text, previousText);
        }
    }
}