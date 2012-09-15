using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems.PropertyGridItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;
using White.Core.WindowsAPI;

namespace White.Core.UITests.UIItems.PropertyGridItems
{
    [TestFixture, WinFormCategory]
    public class PropertyGridTest : CoreTestTemplate
    {
        private Window window;
        private PropertyGrid propertyGrid;
        protected override string CommandLineArguments
        {
            get { return "PropertyGrid"; }
        }

        protected override void TestFixtureSetUp()
        {
            window = application.GetWindow("FormWithPropertyGrid");
            propertyGrid = window.Get<PropertyGrid>("propertyGrid1");
        }

        [Test]
        public void Get()
        {
            Assert.AreNotEqual(null, propertyGrid);
        }

        [Test]
        public void Categories()
        {
            List<PropertyGridCategory> categories = propertyGrid.Categories;
            Assert.AreEqual(4, categories.Count);
            Assert.AreEqual("General", categories[0].Text);
            Assert.AreEqual("Input", categories[1].Text);
            Assert.AreEqual("Misc", categories[2].Text);
            Assert.AreEqual("Number", categories[3].Text);
        }

        [Test]
        public void BrowseForValue()
        {
            PropertyGridCategory propertyGridCategory = propertyGrid.Category("Input");
            PropertyGridProperty property = propertyGridCategory.GetProperty("FileName");
            property.BrowseForValue();
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE);
        }

        [Test, ExpectedException(typeof(WhiteException))]
        public void CannotBrowseForValue()
        {
            PropertyGridProperty propertyWithoutBrowseButton = propertyGrid.Category("General").GetProperty("WindowSize");
            propertyWithoutBrowseButton.BrowseForValue();
        }

        [Test]
        public void Properties()
        {
            Assert.AreEqual(3, propertyGrid.Category("General").Properties.Count);
            Assert.AreEqual(2, propertyGrid.Category("Misc").Properties.Count);
            Assert.AreEqual(2, propertyGrid.Category("Number").Properties.Count);
        }

        [Test]
        public void Property()
        {
            PropertyGridProperty gridProperty = propertyGrid.Category("General").Properties[0];
            Assert.AreEqual("ToolbarColor", gridProperty.Name);
            Assert.AreEqual("Control", gridProperty.Value);
            gridProperty.Value = "ControlDark";
            Assert.AreEqual("ControlDark", gridProperty.Value);
            Assert.AreEqual(false, gridProperty.IsReadOnly);
        }

        public override void TextFixtureTearDown()
        {
            window.Close();
        }
    }
}