using System.Windows.Automation;
using NUnit.Framework;
using White.Core;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Custom;
using White.Core.UIItems.ListBoxItems;
using White.WebBrowser.Silverlight;
using White.Core.UIA;

namespace NonCoreTests.WebBrowser.Silverlight
{
    [TestFixture]
    public class SilverlightDocumentTest : SilverlightTestFixture
    {
        private SilverlightDocument document;
        private Label label;

        [Test]
        public void Get()
        {
            var button = document.Get<Button>("buton");
            Assert.AreNotEqual(null, button);
        }

        protected override void PostSetup()
        {
            document = browserWindow.SilverlightDocument;
            label = document.Get<Label>("status");
        }

        [Test]
        public void Event()
        {
            Assert.AreNotEqual(null, label);
            var button = document.Get<Button>("buton");
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

        [Test]
        public void SelectItemInComboBoxWhichIsAlreadySelected()
        {
            string previousText = label.Text;
            var button = document.Get<Button>("buton");
            var comboBox = document.Get<ComboBox>("combo");
            comboBox.Select("foo");
            comboBox.Select("foo");
            Mouse.Instance.Click(button.Bounds.Center(), document);
            Assert.AreNotEqual(label.Text, previousText);
        }

        [Test]
        public void CustomUIItemsContainer()
        {
            var customButton = document.Get<CustomButton>("buton");
            Assert.IsInstanceOfType(typeof(SilverlightDocument), customButton.ButtonContainer.ActionListener);
        }
    }

    [ControlTypeMapping(CustomUIItemType.Button)]
    public class CustomButton : CustomUIItem
    {
        protected CustomButton(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
        }

        protected CustomButton()
        {
        }

        public virtual UIItemContainer ButtonContainer
        {
            get { return Container; }
        }
    }
}