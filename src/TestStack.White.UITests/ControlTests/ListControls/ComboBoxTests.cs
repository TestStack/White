using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ComboBoxTests : WhiteUITestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        public ComboBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox"));
        }

        [Test]
        public void ListItemInComboBoxWithoutTextAvailableInitiallyTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }

            // Restart the application and reinitialize
            Restart();
            ComboBoxUnderTest = MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox"));

            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            try
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
                Assert.That(ComboBoxUnderTest.Items, Has.Count.EqualTo(0));
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
            }
        }

        [Test]
        public void ComboBoxOnlyCollapsesWhenExpansionWasForItemRetrievalTest()
        {
            // Arrange
            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            config.ComboBoxItemsPopulatedWithoutDropDownOpen = false;

            try
            {
                ComboBoxUnderTest.Expand();

                // Act
#pragma warning disable 168
                // ReSharper disable once UnusedVariable
                var items = ComboBoxUnderTest.Items;
#pragma warning restore 168

                // Assert
                var expansionState = ComboBoxUnderTest.ExpandCollapseState;
                Assert.That(expansionState, Is.EqualTo(ExpandCollapseState.Expanded));
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
                ComboBoxUnderTest.Collapse();
            }
        }

        [Test]
        public void ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrievedTest()
        {
            // Arrange
            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            config.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                // Act
#pragma warning disable 168
                // Required to force the expansion of the combobox
                // ReSharper disable once UnusedVariable
                var items = ComboBoxUnderTest.Items;
#pragma warning restore 168

                // Assert
                var expansionState = ComboBoxUnderTest.ExpandCollapseState;
                // The combobox should have been collapsed after the items were retrieved
                Assert.That(expansionState, Is.EqualTo(ExpandCollapseState.Collapsed));
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
            }

        }

        [Test]
        public void CanSelectByIndexTest()
        {
            ComboBoxUnderTest.Select(4);
            Assert.That(ComboBoxUnderTest.SelectedItemText, Is.EqualTo("Test5"));
        }

        [Test]
        public void CanSelectItemAtBottomOfListTest()
        {
            ComboBoxUnderTest.Select("Test19");
            Assert.That(ComboBoxUnderTest.SelectedItemText, Is.EqualTo("Test19"));
        }

        [Test]
        public void CanGetAllItemsTest()
        {
            var items = ComboBoxUnderTest.Items;
            Assert.That(items, Has.Count.EqualTo(21));
            Assert.That(items[0].Name, Is.EqualTo("Test"));
            Assert.That(items[19].Name, Is.EqualTo("Test20"));
        }

        [Test]
        public void CanSelectItemAtTopOfListTest()
        {
            ComboBoxUnderTest.Select("Test2");
            Assert.That(ComboBoxUnderTest.SelectedItemText, Is.EqualTo("Test2"));
        }

        [Test]
        public void CanSelectReallyLongTextTest()
        {
            ComboBoxUnderTest.Select("ReallyReallyReallyLongTextHere");
            Assert.That(ComboBoxUnderTest.SelectedItem.Text, Is.EqualTo("ReallyReallyReallyLongTextHere"));
        }

        [Test]
        public void SetValueTest()
        {
            ComboBoxUnderTest.SetValue("Test4");
            Assert.That(ComboBoxUnderTest.SelectedItem.Text, Is.EqualTo("Test4"));
        }
    }
}