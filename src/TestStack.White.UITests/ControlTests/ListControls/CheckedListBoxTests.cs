using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class CheckedListBoxTests : WhiteUITestBase
    {
        public CheckedListBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void CanCheckItemTest()
        {
            var listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            Assert.That(listBoxUnderTest.IsChecked("Item1"), Is.False);
            listBoxUnderTest.Check("Item1");
            Assert.That(listBoxUnderTest.IsChecked("Item1"), Is.True);
        }

        [Test]
        public void CheckSelectedItemTest()
        {
            var listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            Assert.That(listBoxUnderTest.IsChecked("Item2"), Is.False);
            var item = listBoxUnderTest.Item("Item2");
            ((SelectionItemPattern)item.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
            listBoxUnderTest.Check("Item2");
            Assert.That(listBoxUnderTest.IsChecked("Item2"), Is.True);
        }

        [Test]
        public void CheckUncheckItemTest()
        {
            var listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            Assert.That(listBoxUnderTest.IsChecked("Item3"), Is.False);
            listBoxUnderTest.Check("Item3");
            Assert.That(listBoxUnderTest.IsChecked("Item3"), Is.True);
            listBoxUnderTest.UnCheck("Item3");
            Assert.That(listBoxUnderTest.IsChecked("Item3"), Is.False);
        }
    }
}