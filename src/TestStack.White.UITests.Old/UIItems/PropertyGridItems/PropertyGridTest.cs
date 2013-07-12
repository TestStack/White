using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;
using TestStack.White.WindowsAPI;

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
            window = Application.GetWindow("FormWithPropertyGrid");
            propertyGrid = window.Get<PropertyGrid>("propertyGrid1");
        }

        [Fact]
        public void Get()
        {
            Assert.NotEqual(null, propertyGrid);
        }

        [Fact]
        public void Categories()
        {
            List<PropertyGridCategory> categories = propertyGrid.Categories;
            Assert.Equal(4, categories.Count);
            Assert.Equal("General", categories[0].Text);
            Assert.Equal("Input", categories[1].Text);
            Assert.Equal("Misc", categories[2].Text);
            Assert.Equal("Number", categories[3].Text);
        }

        [Fact]
        public void BrowseForValue()
        {
            PropertyGridCategory propertyGridCategory = propertyGrid.Category("Input");
            PropertyGridProperty property = propertyGridCategory.GetProperty("FileName");
            property.BrowseForValue();
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE);
        }

        [Test, ExpectedException(typeof(WhiteException))]
        public void CannotBrowseForValue()
        {
            PropertyGridProperty propertyWithoutBrowseButton = propertyGrid.Category("General").GetProperty("WindowSize");
            propertyWithoutBrowseButton.BrowseForValue();
        }

        [Fact]
        public void Properties()
        {
            Assert.Equal(3, propertyGrid.Category("General").Properties.Count);
            Assert.Equal(2, propertyGrid.Category("Misc").Properties.Count);
            Assert.Equal(2, propertyGrid.Category("Number").Properties.Count);
        }

        [Fact]
        public void Property()
        {
            PropertyGridProperty gridProperty = propertyGrid.Category("General").Properties[0];
            Assert.Equal("ToolbarColor", gridProperty.Name);
            Assert.Equal("Control", gridProperty.Value);
            gridProperty.Value = "ControlDark";
            Assert.Equal("ControlDark", gridProperty.Value);
            Assert.Equal(false, gridProperty.IsReadOnly);
        }

        public override void TextFixtureTearDown()
        {
            window.Close();
        }
    }
}