using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.Wpf)]
    public class DataBoundComboBoxTests : WhiteUITestBase
    {
        public DataBoundComboBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void CanSelectDataboundItemsTest()
        {
            var comboBoxUnderTest = MainWindow.Get<ComboBox>("DataBoundComboBox");
            ListItems items;
            CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                items = comboBoxUnderTest.Items;
                Assert.That(items, Has.Count.EqualTo(0));
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }
            items = comboBoxUnderTest.Items;
            Assert.That(items, Has.Count.EqualTo(5));
            Assert.That(items[0].Text, Is.EqualTo("Test"));;
        }
    }
}
