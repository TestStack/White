using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.PropertyGridItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    public class PropertyGridTests : WhiteUITestBase
    {
        private PropertyGrid propertyGrid;

        public PropertyGridTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectPropertyGridTab();
            propertyGrid = MainWindow.Get<PropertyGrid>("PropertyGrid");
        }

        [Test]
        public void GetTest()
        {
            Assert.That(propertyGrid, Is.Not.Null);
        }

        [Test]
        public void CategoriesTest()
        {
            var categories = propertyGrid.Categories;
            Assert.That(categories, Has.Count.EqualTo(4));
            Assert.That(categories, Has.Exactly(1).Matches<PropertyGridCategory>(c => c.Text == "General"));
            Assert.That(categories, Has.Exactly(1).Matches<PropertyGridCategory>(c => c.Text == "Input"));
            Assert.That(categories, Has.Exactly(1).Matches<PropertyGridCategory>(c => c.Text == "Number"));
            Assert.That(categories, Has.Exactly(1).Matches<PropertyGridCategory>(c => c.Text == UIItemIdAppXmlConfiguration.Instance.PropertyGridMiscText));
        }

        [Test]
        public void BrowseForValueTest()
        {
            var propertyGridCategory = propertyGrid.Category("Input");
            var property = propertyGridCategory.GetProperty("FileName");
            property.BrowseForValue();
            MainWindow.ModalWindow(UIItemIdAppXmlConfiguration.Instance.OpenFileDialogTitle).Close();
        }

        [Test]
        public void CannotBrowseForValueTest()
        {
            var propertyWithoutBrowseButton = propertyGrid.Category("General").GetProperty("WindowSize");
            Assert.That(() => { propertyWithoutBrowseButton.BrowseForValue(); }, Throws.TypeOf<WhiteException>());
        }

        [Test]
        public void PropertiesTest()
        {
            Assert.That(propertyGrid.Category("General").Properties, Has.Count.EqualTo(3));
            Assert.That(propertyGrid.Category(UIItemIdAppXmlConfiguration.Instance.PropertyGridMiscText).Properties, Has.Count.EqualTo(2));
            Assert.That(propertyGrid.Category("Number").Properties, Has.Count.EqualTo(2));
        }

        [Test]
        public void PropertyTest()
        {
            var gridProperty = propertyGrid.Category("General").Properties[0];
            Assert.That(gridProperty.Name, Is.EqualTo("ToolbarColor"));
            Assert.That(gridProperty.Value, Is.EqualTo("Control"));
            gridProperty.Value = "ControlDark";
            Assert.That(gridProperty.Value, Is.EqualTo("ControlDark"));
            Assert.That(gridProperty.IsReadOnly, Is.False);
        }
    }
}