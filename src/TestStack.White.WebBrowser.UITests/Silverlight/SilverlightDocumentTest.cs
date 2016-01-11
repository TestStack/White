using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.WebBrowser.Silverlight;

namespace TestStack.White.WebBrowser.UITests.Silverlight
{
    [TestFixture]
    [Ignore("Ignoring broken tests in silverlight for the moment")]
    public class SilverlightDocumentTest : SilverlightTestFixture
    {
        private SilverlightDocument document;
        private Label label;

        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void Get()
        {
            var button = document.Get<Button>("button");
            Assert.That(button, Is.Not.Null);
        }

        protected override void PostSetup()
        {
            document = BrowserWindow.SilverlightDocument;
            label = document.Get<Label>("status");
        }

        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void Event()
        {
            Assert.That(label, Is.Not.Null);
            var button = document.Get<Button>("button");
            button.Click();
            Assert.That(label.Text, Is.EqualTo("0"));
        }

        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void TestComboBox()
        {
            var comboBox = document.Get<ComboBox>("combo");
            Assert.That(comboBox.Items, Has.Count.EqualTo(2));
            Assert.That(comboBox.Items[0].Text, Is.EqualTo("foo"));
        }

        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void Tooltip()
        {
            var button = document.Get<Button>("button");
            var toolTip = document.GetToolTipOn(button);
            Assert.That(toolTip, Is.Null);

            var comboBox = document.Get<ComboBox>("combo");
            toolTip = document.GetToolTipOn(comboBox);
            Assert.That(toolTip, Is.Not.Null);
            Debug.LogPatterns(toolTip);
            Debug.LogProperties(toolTip);
        }

        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void SelectItemInComboBoxWhichIsAlreadySelected()
        {
            var previousText = label.Text;
            var button = document.Get<Button>("button");
            var comboBox = document.Get<ComboBox>("combo");
            comboBox.Select("foo");
            comboBox.Select("foo");
            Mouse.Instance.LeftClick(button.Bounds.Center(), document);
            Assert.That(label.Text, Is.Not.EqualTo(previousText));
        }
    }
}