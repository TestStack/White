using System.Windows.Automation;
using White.Core.Mappings;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.PropertyGridItems;
using White.Core.UIItems.WindowStripControls;
using Xunit;

namespace White.Core.UnitTests.Mappings
{
    public class ControlDictionaryTest
    {
        private readonly ControlDictionary controlDictionary;

        public ControlDictionaryTest()
        {
            controlDictionary = ControlDictionary.Instance;
        }

        [Fact]
        public void PrimaryControlTypes()
        {
            Assert.Equal(true, controlDictionary.PrimaryControlTypes(Constants.WinFormFrameworkId).Count > 23);
        }

        [Fact]
        public void IsPrimaryControl()
        {
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Custom, "CustomItem", null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Button, string.Empty, null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Menu, string.Empty, null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfjSysDateTimePick32ffdgdg", null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfj", null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Tab, "fsdfhsdfj", null));
            Assert.Equal(false, controlDictionary.IsPrimaryControl(ControlType.TabItem, "fsdfhsdfj", null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Group, null, null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Image, "WindowsForms10.Window.8.app.0.33c0d9d", null));
            Assert.Equal(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "WindowsForms10.Window.8.app.0.33c0d9d", "PropertyGrid"));
        }

        [Fact]
        public void HasPrimaryChildren()
        {
            Assert.Equal(true, controlDictionary.HasPrimaryChildren(ControlType.Tab));
            Assert.Equal(true, controlDictionary.HasPrimaryChildren(ControlType.TabItem));
            Assert.Equal(true, controlDictionary.HasPrimaryChildren(ControlType.Pane));
            Assert.Equal(false, controlDictionary.HasPrimaryChildren(ControlType.Button));
            Assert.Equal(true, controlDictionary.HasPrimaryChildren(ControlType.Custom));
            Assert.Equal(true, controlDictionary.HasPrimaryChildren(ControlType.Group));
        }

        [Fact]
        public void GetControlType()
        {
            Assert.Equal(ControlType.Edit, controlDictionary.GetControlType(typeof (TextBox), Constants.WPFFrameworkId));
            Assert.Equal(ControlType.Pane, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WinFormFrameworkId));
            Assert.Equal(ControlType.Button, controlDictionary.GetControlType(typeof(Button), Constants.WPFFrameworkId));
            Assert.Equal(ControlType.Group, controlDictionary.GetControlType(typeof(GroupBox), Constants.WPFFrameworkId));
            Assert.Equal(ControlType.Pane, controlDictionary.GetControlType(typeof(Panel), Constants.WPFFrameworkId));
        }

        [Fact]
        public void GetControlTypeForAFramework()
        {
            Assert.Equal(ControlType.Edit, controlDictionary.GetControlType(typeof(TextBox), Constants.WPFFrameworkId));
            Assert.Equal(ControlType.Menu, controlDictionary.GetControlType(typeof (MenuBar), Constants.WPFFrameworkId));
            Assert.Equal(ControlType.MenuBar, controlDictionary.GetControlType(typeof(MenuBar), Constants.WinFormFrameworkId));
        }

        [Fact]
        public void IsControlTypeSupported()
        {
            Assert.Equal(false, controlDictionary.IsControlTypeSupported(ControlType.Separator));
            Assert.Equal(true, controlDictionary.IsControlTypeSupported(ControlType.Button));
            Assert.Equal(true, controlDictionary.IsControlTypeSupported(ControlType.Group));
            Assert.Equal(true, controlDictionary.IsControlTypeSupported(ControlType.Pane));
        }

        [Fact]
        public void GetTestControlType()
        {
            Assert.Equal(typeof (Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.WinFormFrameworkId, true));
            Assert.Equal(typeof (Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.WPFFrameworkId, false));
            Assert.Equal(typeof (WinFormComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.WinFormFrameworkId, true));
            Assert.Equal(typeof (WPFComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.WPFFrameworkId, false));
            Assert.Equal(typeof (WPFComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.MissingFrameworkId, false));
            Assert.Equal(typeof (SilverlightComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.SilverlightFrameworkId, false));
            Assert.Equal(typeof (WPFLabel), controlDictionary.GetTestControlType(ControlType.Text, Constants.SilverlightFrameworkId, false));
            Assert.Equal(typeof (GroupBox), controlDictionary.GetTestControlType(ControlType.Group, Constants.WPFFrameworkId, false));
            Assert.Equal(null, controlDictionary.GetTestControlType(string.Empty));
            Assert.Equal(typeof(DateTimePicker), controlDictionary.GetTestControlType("sdfsSysDateTimePick32sdfdsf"));
            Assert.Equal(typeof(Image), controlDictionary.GetTestControlType(ControlType.Image, Constants.Win32FrameworkId, true));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.MissingFrameworkId, false));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.MissingFrameworkId, true));
            Assert.Equal(typeof(Win32ComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.MissingFrameworkId, true));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.SilverlightFrameworkId, true));
            Assert.Equal(typeof(TextBox), controlDictionary.GetTestControlType(ControlType.Edit, Constants.SilverlightFrameworkId, true));
        }

        [Fact]
        public void GetTestType()
        {
            Assert.Equal(typeof(Button), controlDictionary.GetTestType(string.Empty, ControlType.Button, Constants.WinFormFrameworkId, "foo", false));
            Assert.Equal(typeof(Panel), controlDictionary.GetTestType(string.Empty, ControlType.Pane, Constants.WinFormFrameworkId, "foo", false));
            Assert.Equal(typeof(PropertyGrid), controlDictionary.GetTestType(string.Empty, ControlType.Pane, Constants.WinFormFrameworkId, "PropertyGrid", false));
        }

        [Fact]
        public void ControlTypeCanChangeBasedOnFramework()
        {
            Assert.Equal(ControlType.Pane.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WinFormFrameworkId).ProgrammaticName);
            Assert.Equal(ControlType.Custom.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WPFFrameworkId).ProgrammaticName);
        }
    }
}
