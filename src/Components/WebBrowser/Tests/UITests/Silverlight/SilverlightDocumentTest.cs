using NUnit.Framework;
using White.Core;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.WebBrowser.Silverlight;
using White.Core.UIA;

namespace White.WebBrowser.UITests.Silverlight
{
    [TestFixture]
    public class SilverlightDocumentTest : SilverlightTestFixture
    {
        private SilverlightDocument document;
        private Label label;

        [Test]
        public void Get()
        {
            var button = document.Get<Button>("button");
            Assert.AreNotEqual(null, button);
        }

        protected override void PostSetup()
        {
            document = BrowserWindow.SilverlightDocument;
            label = document.Get<Label>("status");
        }

        [Test]
        public void Event()
        {
            Assert.AreNotEqual(null, label);
            var button = document.Get<Button>("button");
            button.Click();
            Assert.AreEqual("0", label.Text);
        }

        [Test]
        public void TestComboBox()
        {
            var comboBox = document.Get<ComboBox>("combo");
            Assert.AreEqual(2, comboBox.Items.Count);
            Assert.AreEqual("foo", comboBox.Items[0].Text);
        }

        [Test, Ignore("Ignoring broken tests in silverlight for the moment")]
        public void Tooltip()
        {
            var button = document.Get<Button>("button");
            ToolTip toolTip = document.GetToolTipOn(button);
            Assert.AreEqual(null, toolTip);

            var comboBox = document.Get<ComboBox>("combo");
            toolTip = document.GetToolTipOn(comboBox);
            Assert.AreNotEqual(null, toolTip);
            Debug.LogPatterns(toolTip);
            Debug.LogProperties(toolTip);
        }

        [Test, Ignore("Ignoring broken tests in silverlight for the moment")]
        public void SelectItemInComboBoxWhichIsAlreadySelected()
        {
            string previousText = label.Text;
            var button = document.Get<Button>("button");
            var comboBox = document.Get<ComboBox>("combo");
            comboBox.Select("foo");
            comboBox.Select("foo");
            Mouse.Instance.Click(button.Bounds.Center(), document);
            Assert.AreNotEqual(label.Text, previousText);
        }
    }
}