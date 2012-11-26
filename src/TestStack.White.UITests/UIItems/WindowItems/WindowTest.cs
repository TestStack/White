using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormsWindowTest : WindowTest
    {
        [Test]
        public void ItemsWithin()
        {
            var groupBox = window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = window.ItemsWithin(groupBox);
            Assert.AreEqual(1, uiItems.Count);
            Assert.AreEqual(1, uiItems.OfType<Button>().Count());
        }
    }

    [TestFixture, WPFCategory]
    public class WpfWindowTest : WindowTest
    {
        [Test]
        public void ItemsWithin()
        {
            var groupBox = window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = window.ItemsWithin(groupBox);
            Assert.AreEqual(3, uiItems.Count);
            Assert.AreEqual(1, uiItems.OfType<Button>().Count());
        }
    }

    public class WindowTest : ControlsActionTest
    {
        [SetUp]
        public void SetUp()
        {
            window.DisplayState = DisplayState.Restored;
        }

        [Test]
        public void GetTitle()
        {
            Assert.AreNotEqual(null, window.Title);
        }

        [Test]
        public void HandleDynamicallyAddedControls()
        {
            Assert.Throws<AutomationException>(() => window.Get<TextBox>("dynamicTextBox"));

            window.Get<Button>("addDynamicControl").Click();
            Assert.AreNotEqual(null, window.Get<TextBox>(GetSearchCriteria()));
        }

        private SearchCriteria GetSearchCriteria()
        {
            if (window is Win32Window)
                return SearchCriteria.ByText("dynamicTextBox");
            return SearchCriteria.ByAutomationId("dynamicTextBox");
        }

        [Test]
        public void SetWindowState()
        {
            window.DisplayState = DisplayState.Maximized;
            Assert.AreEqual(DisplayState.Maximized, window.DisplayState);

            window.DisplayState = DisplayState.Restored;
            Assert.AreEqual(DisplayState.Restored, window.DisplayState);

            window.DisplayState = DisplayState.Minimized;
            Assert.AreEqual(DisplayState.Minimized, window.DisplayState);
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAGroupBox()
        {
            var button = window.Get<Button>("buttonInGroupBox");
            Assert.AreNotEqual(null, button);
            button.Click();
            AssertResultLabelText("Button In GroupBox Clicked");
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAPanel()
        {
            var textBox = window.Get<TextBox>("textBoxInsidePanel");
            Assert.AreNotEqual(null, textBox);
        }

        [Test]
        public void FindTabs()
        {
            Assert.AreEqual(1, window.Tabs.Count);
        }

        [Test]
        public void GetAll()
        {
            Assert.AreNotEqual(0, window.Items.Count);
        }

        [Test]
        public void HasAttachedMouse()
        {
            Assert.AreNotEqual(null, window.Mouse);
        }

        [Test]
        public void FindNonExistentItem()
        {
            var excepion = Assert.Throws<AutomationException>(() => window.Get<Button>("DoesntExist"));
            Assert.AreEqual("Failed to get ControlType=button,AutomationId=DoesntExist", excepion.Message);
        }
    }
}