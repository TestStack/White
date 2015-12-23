using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WPFUIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.Wpf)]
    public class UIItemTests : WhiteUITestBase
    {
        public UIItemTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void ClickOnElementLocatedBySearchingThroughSeveralContainersTest()
        {
            var groupBox = MainWindow.Get<TabPage>(SearchCriteria.ByAutomationId("ListControlsTab"));
            var listbox = groupBox.Get<ListBox>(SearchCriteria.ByAutomationId("CheckedListBox"));
            var listboxItem = listbox.Get<ListItem>(SearchCriteria.ByText("Item1"));
            Assert.That(() => { listboxItem.Click(); }, Throws.Nothing);
        }
    }
}