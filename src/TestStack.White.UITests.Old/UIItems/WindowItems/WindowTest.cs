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
            var groupBox = Window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = Window.ItemsWithin(groupBox);
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
            var groupBox = Window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = Window.ItemsWithin(groupBox);
            Assert.AreEqual(3, uiItems.Count);
            Assert.AreEqual(1, uiItems.OfType<Button>().Count());
        }
    }

    public class WindowTest : ControlsActionTest
    {
        [SetUp]
        public void SetUp()
        {
            Window.DisplayState = DisplayState.Restored;
        }

        [Test]
        public void GetTitle()
        {
            Assert.AreNotEqual(null, Window.Title);
        }

        [Test]
        public void HandleDynamicallyAddedControls()
        {
            Assert.Throws<AutomationException>(() => Window.Get<TextBox>("dynamicTextBox"));

            Window.Get<Button>("addDynamicControl").Click();
            Assert.AreNotEqual(null, Window.Get<TextBox>(GetSearchCriteria()));
        }

        private SearchCriteria GetSearchCriteria()
        {
            if (Window is Win32Window)
                return SearchCriteria.ByText("dynamicTextBox");
            return SearchCriteria.ByAutomationId("dynamicTextBox");
        }

        [Test]
        public void SetWindowState()
        {
            Window.DisplayState = DisplayState.Maximized;
            Assert.AreEqual(DisplayState.Maximized, Window.DisplayState);

            Window.DisplayState = DisplayState.Restored;
            Assert.AreEqual(DisplayState.Restored, Window.DisplayState);

            Window.DisplayState = DisplayState.Minimized;
            Assert.AreEqual(DisplayState.Minimized, Window.DisplayState);
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAGroupBox()
        {
            var button = Window.Get<Button>("buttonInGroupBox");
            Assert.AreNotEqual(null, button);
            button.Click();
            AssertResultLabelText("Button In GroupBox Clicked");
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAPanel()
        {
            var textBox = Window.Get<TextBox>("textBoxInsidePanel");
            Assert.AreNotEqual(null, textBox);
        }

        [Test]
        public void FindTabs()
        {
            Assert.AreEqual(1, Window.Tabs.Count);
        }

        [Test]
        public void GetAll()
        {
            Assert.AreNotEqual(0, Window.Items.Count);
        }

        [Test]
        public void HasAttachedMouse()
        {
            Assert.AreNotEqual(null, Window.Mouse);
        }

        [Test]
        public void FindNonExistentItem()
        {
            var excepion = Assert.Throws<AutomationException>(() => Window.Get<Button>("DoesntExist"));
            Assert.AreEqual("Failed to get ControlType=button,AutomationId=DoesntExist", excepion.Message);
        }
    }
}