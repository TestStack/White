using System;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ListBoxWithScrollBarTests : WhiteUITestBase
    {
        public ListBoxWithScrollBarTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void SelectItemNotVisibleBecauseOfScrollBarTest()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.Select("0");
            var selectedItem = listBox.SelectedItem;
            Assert.That(selectedItem.Text, Is.EqualTo("0"));
        }

        [Test]
        public void ListItemContainingTextboxTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            var listItem = (WPFListItem)listBox.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var textBox = listItem.Get<TextBox>(SearchCriteria.All);
            Assert.That(textBox, Is.Not.Null);
            textBox.Text = "Hrishikesh M";
            Assert.That(listItem.Text, Is.EqualTo("Hrishikesh M"));
        }

        [Test]
        public void FindNonExistentObjectTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            var listItem = (WPFListItem)listBox.Items.Find(item => item.Text.StartsWith("Hrishikesh"));
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                Assert.That(() => { listItem.Get<TextBox>(SearchCriteria.ByAutomationId("foo")); },
                    Throws.TypeOf<AutomationException>().With.Message.EqualTo(
                        String.Format("Failed to get ControlType={0},AutomationId=foo", ControlType.Edit.LocalizedControlType)));
            }
        }

        [Test]
        public void ListBoxWithScrollBarWithChangingItemsTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            listBox.Select("Spielberg");
            listBox.Select("Whedon");
            MainWindow.Get<Button>("ChangeListItems").Click();
            listBox.Select("Jackson");
            listBox.Select("Allen");
        }
    }
}