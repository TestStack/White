using NUnit.Framework;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Mappings;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TestStack.White.UnitTests.Mappings
{
    [TestFixture]
    public class ControlDictionaryTests
    {
        private ControlDictionary controlDictionary;

        [OneTimeSetUp]
        public void Setup()
        {
            controlDictionary = ControlDictionary.Instance;
        }

        [Test]
        public void PrimaryControlTypesTest()
        {
            Assert.That(controlDictionary.PrimaryControlTypes(WindowsFramework.WinForms.FrameworkId()).Count > 23, Is.True);
        }

        [Test]
        public void IsPrimaryControlTest()
        {
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Custom, "CustomItem", null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Button, string.Empty, null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Menu, string.Empty, null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfjSysDateTimePick32ffdgdg", null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfj", null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Tab, "fsdfhsdfj", null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.TabItem, "fsdfhsdfj", null), Is.False);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Group, null, null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Image, "WindowsForms10.Window.8.app.0.33c0d9d", null), Is.True);
            Assert.That(controlDictionary.IsPrimaryControl(ControlType.Pane, "WindowsForms10.Window.8.app.0.33c0d9d", "PropertyGrid"), Is.True);
        }

        [Test]
        public void HasPrimaryChildrenTest()
        {
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.Tab), Is.True);
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.TabItem), Is.True);
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.Pane), Is.True);
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.Button), Is.False);
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.Custom), Is.True);
            Assert.That(controlDictionary.HasPrimaryChildren(ControlType.Group), Is.True);
        }

        [Test]
        public void GetControlTypeTest()
        {
            Assert.That(controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single(), Is.EqualTo(ControlType.Pane));
            Assert.That(controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.Button));
            Assert.That(controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.CheckBox));
            Assert.That(controlDictionary.GetControlType(typeof(GroupBox), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Group));
            Assert.That(controlDictionary.GetControlType(typeof(Panel), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Pane));
        }

        [Test]
        public void GetControlTypeForAFrameworkTest()
        {
            Assert.That(controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.Edit));
            Assert.That(controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Edit));
            Assert.That(controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Menu));
            Assert.That(controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.WinForms.FrameworkId()).Single(), Is.EqualTo(ControlType.MenuBar));
        }

        [Test]
        public void IsControlTypeSupportedTest()
        {
            Assert.That(controlDictionary.IsControlTypeSupported(ControlType.Separator), Is.False);
            Assert.That(controlDictionary.IsControlTypeSupported(ControlType.Button), Is.True);
            Assert.That(controlDictionary.IsControlTypeSupported(ControlType.Group), Is.True);
            Assert.That(controlDictionary.IsControlTypeSupported(ControlType.Pane), Is.True);
        }

        [Test]
        public void GetTestControlTypeTest()
        {
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(WinFormComboBox)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(WPFComboBox)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Silverlight.FrameworkId(), false), Is.EqualTo(typeof(SilverlightComboBox)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Text, WindowsFramework.Silverlight.FrameworkId(), false), Is.EqualTo(typeof(WPFLabel)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Group, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(GroupBox)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Image, WindowsFramework.Win32.FrameworkId(), true), Is.EqualTo(typeof(Image)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(() => { controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), false); }, Throws.TypeOf<ControlDictionaryException>());
            Assert.That(() => { controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), true); }, Throws.TypeOf<ControlDictionaryException>());
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Silverlight.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Edit, WindowsFramework.Silverlight.FrameworkId(), true), Is.EqualTo(typeof(TextBox)));
            Assert.That(controlDictionary.GetTestControlType("SysDateTimePick32", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(DateTimePicker)));
            Assert.That(controlDictionary.GetTestControlType("Winforms.SysDateTimePick32.ad8aa", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(DateTimePicker)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, string.Empty, false), Is.EqualTo(typeof(Win32ListItem)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Win32ListItem)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(WPFListItem)));
        }

        [Test]
        public void GetTestTypeTest()
        {
            Assert.That(controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Button, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Panel)));
            Assert.That(controlDictionary.GetTestControlType(string.Empty, "PropertyGrid", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(PropertyGrid)));
        }

        [Test]
        public void ControlTypeCanChangeBasedOnFrameworkTest()
        {
            Assert.That(controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single().ProgrammaticName, Is.EqualTo(ControlType.Pane.ProgrammaticName));
            Assert.That(controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.Wpf.FrameworkId()).Single().ProgrammaticName, Is.EqualTo(ControlType.Custom.ProgrammaticName));
        }
    }
}
