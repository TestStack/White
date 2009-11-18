using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using NUnit.Framework;

namespace White.WebBrowser.Silverlight
{
    [TestFixture]
    public class SilverlightDocumentTest : SilverlightTestFixture
    {
        private SilverlightDocument document;

        [Test]
        public void Get()
        {
            var button = document.Get<Button>("buton");
            Assert.AreNotEqual(null, button);
        }

        protected override void PostSetup()
        {
            document = browserWindow.SilverlightDocument;
        }

        [Test]
        public void Event()
        {
            var button = document.Get<Button>("buton");
            var label = document.Get<Label>("status");
            Assert.AreNotEqual(null, label);
            button.Click();
            Assert.AreEqual("Buton Clicked", label.Text);
        }

        [Test]
        public void TestComboBox()
        {
            var comboBox = document.Get<ComboBox>("combo");
            Assert.AreEqual(2, comboBox.Items.Count);
            Assert.AreEqual("foo", comboBox.Items[0].Text);
        }

        [Test]
        public void Tooltip()
        {
            var button = document.Get<Button>("buton");
            ToolTip toolTip = document.GetToolTipOn(button);
            Assert.AreEqual(null, toolTip);

            var comboBox = document.Get<ComboBox>("combo");
            toolTip = document.GetToolTipOn(comboBox);
            Assert.AreNotEqual(null, toolTip);
            Debug.LogPatterns(toolTip);
            Debug.LogProperties(toolTip);
        }
    }
}