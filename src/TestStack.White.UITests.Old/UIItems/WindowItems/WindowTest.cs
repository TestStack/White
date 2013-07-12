using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormsWindowTest : WindowTest
    {
        [Fact]
        public void ItemsWithin()
        {
            var groupBox = Window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = Window.ItemsWithin(groupBox);
            Assert.Equal(1, uiItems.Count);
            Assert.Equal(1, uiItems.OfType<Button>().Count());
        }
    }

    [TestFixture, WPFCategory]
    public class WpfWindowTest : WindowTest
    {
        [Fact]
        public void ItemsWithin()
        {
            var groupBox = Window.Get<GroupBox>("groupBox1");
            List<UIItem> uiItems = Window.ItemsWithin(groupBox);
            Assert.Equal(3, uiItems.Count);
            Assert.Equal(1, uiItems.OfType<Button>().Count());
        }
    }

    public class WindowTest : ControlsActionTest
    {
        [SetUp]
        public void SetUp()
        {
            Window.DisplayState = DisplayState.Restored;
        }

        [Fact]
        public void GetTitle()
        {
            Assert.NotEqual(null, Window.Title);
        }

        [Fact]
        public void HandleDynamicallyAddedControls()
        {
            Assert.Throws<AutomationException>(() => Window.Get<TextBox>("dynamicTextBox"));

            Window.Get<Button>("addDynamicControl").Click();
            Assert.NotEqual(null, Window.Get<TextBox>(GetSearchCriteria()));
        }

        private SearchCriteria GetSearchCriteria()
        {
            if (Window is Win32Window)
                return SearchCriteria.ByText("dynamicTextBox");
            return SearchCriteria.ByAutomationId("dynamicTextBox");
        }

        [Fact]
        public void SetWindowState()
        {
            Window.DisplayState = DisplayState.Maximized;
            Assert.Equal(DisplayState.Maximized, Window.DisplayState);

            Window.DisplayState = DisplayState.Restored;
            Assert.Equal(DisplayState.Restored, Window.DisplayState);

            Window.DisplayState = DisplayState.Minimized;
            Assert.Equal(DisplayState.Minimized, Window.DisplayState);
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAGroupBox()
        {
            var button = Window.Get<Button>("buttonInGroupBox");
            Assert.NotEqual(null, button);
            button.Click();
            AssertResultLabelText("Button In GroupBox Clicked");
        }

        [Test, WinFormCategory, WPFCategory]
        public void FindControlsInsideAPanel()
        {
            var textBox = Window.Get<TextBox>("textBoxInsidePanel");
            Assert.NotEqual(null, textBox);
        }

        [Fact]
        public void FindTabs()
        {
            Assert.Equal(1, Window.Tabs.Count);
        }

        [Fact]
        public void GetAll()
        {
            Assert.NotEqual(0, Window.Items.Count);
        }

        [Fact]
        public void HasAttachedMouse()
        {
            Assert.NotEqual(null, Window.Mouse);
        }

        [Fact]
        public void FindNonExistentItem()
        {
            var excepion = Assert.Throws<AutomationException>(() => Window.Get<Button>("DoesntExist"));
            Assert.Equal("Failed to get ControlType=button,AutomationId=DoesntExist", excepion.Message);
        }
    }
}