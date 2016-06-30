// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlDictionaryTests.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the ControlDictionaryTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.UnitTests.Mappings
{
    using System.Linq;
    using System.Windows.Automation;

    using NUnit.Framework;

    using TestStack.White.Mappings;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.PropertyGridItems;
    using TestStack.White.UIItems.WindowStripControls;

    /// <summary>
    /// The control dictionary tests.
    /// </summary>
    [TestFixture]
    public class ControlDictionaryTests
    {
        /// <summary>
        /// The control dictionary.
        /// </summary>
        private ControlDictionary controlDictionary;

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.controlDictionary = ControlDictionary.Instance;
        }

        /// <summary>
        /// The primary control types test.
        /// </summary>
        [Test]
        public void PrimaryControlTypesTest()
        {
            Assert.That(this.controlDictionary.PrimaryControlTypes(WindowsFramework.WinForms.FrameworkId()).Count > 23, Is.True);
        }

        /// <summary>
        /// The is primary control test.
        /// </summary>
        [Test]
        public void IsPrimaryControlTest()
        {
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Custom, "CustomItem", null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Button, string.Empty, null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Menu, string.Empty, null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfjSysDateTimePick32ffdgdg", null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfj", null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Tab, "fsdfhsdfj", null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.TabItem, "fsdfhsdfj", null), Is.False);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Group, null, null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Image, "WindowsForms10.Window.8.app.0.33c0d9d", null), Is.True);
            Assert.That(this.controlDictionary.IsPrimaryControl(ControlType.Pane, "WindowsForms10.Window.8.app.0.33c0d9d", "PropertyGrid"), Is.True);
        }

        /// <summary>
        /// The has primary children test.
        /// </summary>
        [Test]
        public void HasPrimaryChildrenTest()
        {
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.Tab), Is.True);
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.TabItem), Is.True);
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.Pane), Is.True);
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.Button), Is.False);
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.Custom), Is.True);
            Assert.That(this.controlDictionary.HasPrimaryChildren(ControlType.Group), Is.True);
        }

        /// <summary>
        /// The get control type test.
        /// </summary>
        [Test]
        public void GetControlTypeTest()
        {
            Assert.That(this.controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single(), Is.EqualTo(ControlType.Pane));
            Assert.That(this.controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.Button));
            Assert.That(this.controlDictionary.GetControlType(typeof(Button), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.CheckBox));
            Assert.That(this.controlDictionary.GetControlType(typeof(GroupBox), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Group));
            Assert.That(this.controlDictionary.GetControlType(typeof(Panel), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Pane));
        }

        /// <summary>
        /// The get control type for a framework test.
        /// </summary>
        [Test]
        public void GetControlTypeForAFrameworkTest()
        {
            Assert.That(this.controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()), Has.Some.EqualTo(ControlType.Edit));
            Assert.That(this.controlDictionary.GetControlType(typeof(TextBox), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Edit));
            Assert.That(this.controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.Wpf.FrameworkId()).Single(), Is.EqualTo(ControlType.Menu));
            Assert.That(this.controlDictionary.GetControlType(typeof(MenuBar), WindowsFramework.WinForms.FrameworkId()).Single(), Is.EqualTo(ControlType.MenuBar));
        }

        /// <summary>
        /// The is control type supported test.
        /// </summary>
        [Test]
        public void IsControlTypeSupportedTest()
        {
            Assert.That(this.controlDictionary.IsControlTypeSupported(ControlType.Separator), Is.False);
            Assert.That(this.controlDictionary.IsControlTypeSupported(ControlType.Button), Is.True);
            Assert.That(this.controlDictionary.IsControlTypeSupported(ControlType.Group), Is.True);
            Assert.That(this.controlDictionary.IsControlTypeSupported(ControlType.Pane), Is.True);
        }

        /// <summary>
        /// The get test control type test.
        /// </summary>
        [Test]
        public void GetTestControlTypeTest()
        {
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(WinFormComboBox)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(WPFComboBox)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.Silverlight.FrameworkId(), false), Is.EqualTo(typeof(SilverlightComboBox)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Text, WindowsFramework.Silverlight.FrameworkId(), false), Is.EqualTo(typeof(WPFLabel)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Group, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(GroupBox)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Image, WindowsFramework.Win32.FrameworkId(), true), Is.EqualTo(typeof(Image)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.None.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(() => { controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), false); }, Throws.TypeOf<ControlDictionaryException>());
            Assert.That(() => { controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ComboBox, WindowsFramework.None.FrameworkId(), true); }, Throws.TypeOf<ControlDictionaryException>());
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Button, WindowsFramework.Silverlight.FrameworkId(), true), Is.EqualTo(typeof(Button)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.Edit, WindowsFramework.Silverlight.FrameworkId(), true), Is.EqualTo(typeof(TextBox)));
            Assert.That(this.controlDictionary.GetTestControlType("SysDateTimePick32", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(DateTimePicker)));
            Assert.That(this.controlDictionary.GetTestControlType("Winforms.SysDateTimePick32.ad8aa", string.Empty, ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), true), Is.EqualTo(typeof(DateTimePicker)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, string.Empty, false), Is.EqualTo(typeof(Win32ListItem)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Win32ListItem)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, string.Empty, ControlType.ListItem, WindowsFramework.Wpf.FrameworkId(), false), Is.EqualTo(typeof(WPFListItem)));
        }

        /// <summary>
        /// The get test type test.
        /// </summary>
        [Test]
        public void GetTestTypeTest()
        {
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Button, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Button)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, "foo", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(Panel)));
            Assert.That(this.controlDictionary.GetTestControlType(string.Empty, "PropertyGrid", ControlType.Pane, WindowsFramework.WinForms.FrameworkId(), false), Is.EqualTo(typeof(PropertyGrid)));
        }

        /// <summary>
        /// The control type can change based on framework test.
        /// </summary>
        [Test]
        public void ControlTypeCanChangeBasedOnFrameworkTest()
        {
            Assert.That(this.controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.WinForms.FrameworkId()).Single().ProgrammaticName, Is.EqualTo(ControlType.Pane.ProgrammaticName));
            Assert.That(this.controlDictionary.GetControlType(typeof(DateTimePicker), WindowsFramework.Wpf.FrameworkId()).Single().ProgrammaticName, Is.EqualTo(ControlType.Custom.ProgrammaticName));
        }
    }
}
