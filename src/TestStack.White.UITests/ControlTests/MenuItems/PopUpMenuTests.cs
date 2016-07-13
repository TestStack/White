using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class PopUpMenuTests : WhiteUITestBase
    {
        public PopUpMenuTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectListControls();
        }

        [Test]
        public void GetPopupMenuItemsTest()
        {
            MainWindow.Get<ListBox>("ListBoxWithVScrollBar").RightClick();
            var popup = MainWindow.Popup;
            var numberOfItems = Framework == WindowsFramework.Wpf ? 2 : 4;
            Assert.That(popup.Items, Has.Count.EqualTo(numberOfItems));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ClickOnPopupMenuTest()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            Assert.That(MainWindow.HasPopup(), Is.True);
            var menu = MainWindow.PopupMenu("Root2");
            menu.Click();
            Assert.That(listBox.HelpText, Is.EqualTo("Root2 Clicked"));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ClickOnNestedMenuTest()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            MainWindow.PopupMenu("Root", "Level1", "Level2").Click();
            Assert.That(listBox.HelpText, Is.EqualTo("Level 2 Clicked"));
        }
    }
}