using System.Linq;
using System.Windows.Automation;
using TestStack.White.Mappings;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UnitTests.Mappings
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
            Assert.Equal(true, controlDictionary.PrimaryControlTypes(WindowsFramework.WinForms.FrameworkId()).Count > 23);
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
            Assert.Equal(ControlType.Pane, controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single());
            Assert.Contains(ControlType.Button, controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()));
            Assert.Contains(ControlType.CheckBox, controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()));
            Assert.Equal(ControlType.Group, controlDictionary.GetControlType(typeof(GroupBox), WindowsFramework.Wpf.FrameworkId()).Single());
            Assert.Equal(ControlType.Pane, controlDictionary.GetControlType(typeof(Panel), WindowsFramework.Wpf.FrameworkId()).Single());
        }

        [Fact]
        public void GetControlTypeForAFramework()
        {
            Assert.Contains(ControlType.Edit, controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()));
            Assert.Contains(ControlType.Edit, controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()));
            Assert.Equal(ControlType.Edit, controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()).Single());
            Assert.Equal(ControlType.Menu, controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.Wpf.FrameworkId()).Single());
            Assert.Equal(ControlType.MenuBar, controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.WinForms.FrameworkId()).Single());
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
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.WinForms.FrameworkId(), true));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Wpf.FrameworkId(), false));
            Assert.Equal(typeof(WinFormComboBox), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.WinForms.FrameworkId(), true));
            Assert.Equal(typeof(WPFComboBox), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Wpf.FrameworkId(), false));
            Assert.Throws<ControlDictionaryException>(()=>controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), false));
            Assert.Equal(typeof(SilverlightComboBox), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Silverlight.FrameworkId(), false));
            Assert.Equal(typeof(WPFLabel), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Text, WindowsFramework.Silverlight.FrameworkId(), false));
            Assert.Equal(typeof(GroupBox), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Group, WindowsFramework.Wpf.FrameworkId(), false));
            Assert.Equal(typeof(Image), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Image, WindowsFramework.Win32.FrameworkId(), true));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), false));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), true));
            Assert.Throws<ControlDictionaryException>(() => controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), true));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Silverlight.FrameworkId(), true));
            Assert.Equal(typeof(TextBox), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Edit, WindowsFramework.Silverlight.FrameworkId(), true));
            Assert.Equal(typeof(DateTimePicker), controlDictionary.GetTestControlType("SysDateTimePick32", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true));
            Assert.Equal(typeof(DateTimePicker), controlDictionary.GetTestControlType("Winforms.SysDateTimePick32.ad8aa", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true));
        }

        [Fact]
        public void GetTestType()
        {
            Assert.Equal(typeof(Label), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Text, string.Empty, false));
            Assert.Equal(typeof(Label), controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Text, null, false));
            Assert.Equal(typeof(Button), controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Button, WindowsFramework.WinForms.FrameworkId(), false));
            Assert.Equal(typeof(Panel), controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false));
            Assert.Equal(typeof(PropertyGrid), controlDictionary.GetTestControlType(string.Empty, "PropertyGrid", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false));
        }

        [Fact]
        public void ControlTypeCanChangeBasedOnFramework()
        {
            Assert.Equal(ControlType.Pane.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single().ProgrammaticName);
            Assert.Equal(ControlType.Custom.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.Wpf.FrameworkId()).Single().ProgrammaticName);
        }
    }
}
