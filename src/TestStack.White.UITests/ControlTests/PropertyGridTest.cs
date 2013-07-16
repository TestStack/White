using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class PropertyGridTest : WhiteTestBase
    {
        PropertyGrid propertyGrid;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectPropertyGridTab();
            propertyGrid = MainWindow.Get<PropertyGrid>("PropertyGrid");

            RunTest(Get);
            RunTest(Categories);
            RunTest(BrowseForValue);
            RunTest(CannotBrowseForValue);
            RunTest(Properties);
            RunTest(Property);
        }
        void Get()
        {
            Assert.NotNull(propertyGrid);
        }

        void Categories()
        {
            List<PropertyGridCategory> categories = propertyGrid.Categories;
            Assert.Equal(4, categories.Count);
            Assert.Equal("General", categories[0].Text);
            Assert.Equal("Input", categories[1].Text);
            Assert.Equal("Misc", categories[2].Text);
            Assert.Equal("Number", categories[3].Text);
        }

        void BrowseForValue()
        {
            PropertyGridCategory propertyGridCategory = propertyGrid.Category("Input");
            PropertyGridProperty property = propertyGridCategory.GetProperty("FileName");
            property.BrowseForValue();
            MainWindow.ModalWindow("Open File").Close();
        }

        void CannotBrowseForValue()
        {
            PropertyGridProperty propertyWithoutBrowseButton = propertyGrid.Category("General").GetProperty("WindowSize");
            Assert.Throws<WhiteException>(()=>propertyWithoutBrowseButton.BrowseForValue());
        }

        void Properties()
        {
            Assert.Equal(3, propertyGrid.Category("General").Properties.Count);
            Assert.Equal(2, propertyGrid.Category("Misc").Properties.Count);
            Assert.Equal(2, propertyGrid.Category("Number").Properties.Count);
        }

        void Property()
        {
            PropertyGridProperty gridProperty = propertyGrid.Category("General").Properties[0];
            Assert.Equal("ToolbarColor", gridProperty.Name);
            Assert.Equal("Control", gridProperty.Value);
            gridProperty.Value = "ControlDark";
            Assert.Equal("ControlDark", gridProperty.Value);
            Assert.Equal(false, gridProperty.IsReadOnly);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}