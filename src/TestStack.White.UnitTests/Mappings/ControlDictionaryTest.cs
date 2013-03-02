using System.Windows.Automation;
using NUnit.Framework;
using White.Core.Mappings;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.PropertyGridItems;
using White.Core.UIItems.WindowStripControls;

namespace White.Core.UnitTests.Mappings
{
    [TestFixture]
    public class ControlDictionaryTest
    {
        private ControlDictionary controlDictionary;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            controlDictionary = ControlDictionary.Instance;
        }

        [Test]
        public void PrimaryControlTypes()
        {
            Assert.AreEqual(true, controlDictionary.PrimaryControlTypes(Constants.WinFormFrameworkId).Count > 23);
        }

        [Test]
        public void IsPrimaryControl()
        {
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Button, string.Empty, null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Menu, string.Empty, null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfjSysDateTimePick32ffdgdg", null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "fsdfhsdfj", null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Tab, "fsdfhsdfj", null));
            Assert.AreEqual(false, controlDictionary.IsPrimaryControl(ControlType.TabItem, "fsdfhsdfj", null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Group, null, null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Image, "WindowsForms10.Window.8.app.0.33c0d9d", null));
            Assert.AreEqual(true, controlDictionary.IsPrimaryControl(ControlType.Pane, "WindowsForms10.Window.8.app.0.33c0d9d", "PropertyGrid"));
        }

        [Test]
        public void HasPrimaryChildren()
        {
            Assert.AreEqual(true, controlDictionary.HasPrimaryChildren(ControlType.Tab));
            Assert.AreEqual(true, controlDictionary.HasPrimaryChildren(ControlType.TabItem));
            Assert.AreEqual(true, controlDictionary.HasPrimaryChildren(ControlType.Pane));
            Assert.AreEqual(false, controlDictionary.HasPrimaryChildren(ControlType.Button));
            Assert.AreEqual(true, controlDictionary.HasPrimaryChildren(ControlType.Custom));
            Assert.AreEqual(true, controlDictionary.HasPrimaryChildren(ControlType.Group));
        }

        [Test]
        public void GetControlType()
        {
            Assert.AreEqual(ControlType.Edit, controlDictionary.GetControlType(typeof (TextBox), Constants.WPFFrameworkId));
            Assert.AreEqual(ControlType.Pane, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WinFormFrameworkId));
            Assert.AreEqual(ControlType.Button, controlDictionary.GetControlType(typeof(Button), Constants.WPFFrameworkId));
            Assert.AreEqual(ControlType.Group, controlDictionary.GetControlType(typeof(GroupBox), Constants.WPFFrameworkId));
            Assert.AreEqual(ControlType.Pane, controlDictionary.GetControlType(typeof(Panel), Constants.WPFFrameworkId));
        }

        [Test]
        public void GetControlTypeForAFramework()
        {
            Assert.AreEqual(ControlType.Edit, controlDictionary.GetControlType(typeof(TextBox), Constants.WPFFrameworkId));
            Assert.AreEqual(ControlType.Menu, controlDictionary.GetControlType(typeof (MenuBar), Constants.WPFFrameworkId));
            Assert.AreEqual(ControlType.MenuBar, controlDictionary.GetControlType(typeof(MenuBar), Constants.WinFormFrameworkId));
        }

        [Test]
        public void IsControlTypeSupported()
        {
            Assert.AreEqual(false, controlDictionary.IsControlTypeSupported(ControlType.Separator));
            Assert.AreEqual(true, controlDictionary.IsControlTypeSupported(ControlType.Button));
            Assert.AreEqual(true, controlDictionary.IsControlTypeSupported(ControlType.Group));
            Assert.AreEqual(true, controlDictionary.IsControlTypeSupported(ControlType.Pane));
        }

        [Test]
        public void GetTestControlType()
        {
            Assert.AreEqual(typeof (Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.WinFormFrameworkId, true));
            Assert.AreEqual(typeof (Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.WPFFrameworkId, false));
            Assert.AreEqual(typeof (WinFormComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.WinFormFrameworkId, true));
            Assert.AreEqual(typeof (WPFComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.WPFFrameworkId, false));
            Assert.AreEqual(typeof (WPFComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.MissingFrameworkId, false));
            Assert.AreEqual(typeof (SilverlightComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.SilverlightFrameworkId, false));
            Assert.AreEqual(typeof (WPFLabel), controlDictionary.GetTestControlType(ControlType.Text, Constants.SilverlightFrameworkId, false));
            Assert.AreEqual(typeof (GroupBox), controlDictionary.GetTestControlType(ControlType.Group, Constants.WPFFrameworkId, false));
            Assert.AreEqual(null, controlDictionary.GetTestControlType(string.Empty));
            Assert.AreEqual(typeof(DateTimePicker), controlDictionary.GetTestControlType("sdfsSysDateTimePick32sdfdsf"));
            Assert.AreEqual(typeof(Image), controlDictionary.GetTestControlType(ControlType.Image, Constants.Win32FrameworkId, true));
            Assert.AreEqual(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.MissingFrameworkId, false));
            Assert.AreEqual(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.MissingFrameworkId, true));
            Assert.AreEqual(typeof(Win32ComboBox), controlDictionary.GetTestControlType(ControlType.ComboBox, Constants.MissingFrameworkId, true));
            Assert.AreEqual(typeof(Button), controlDictionary.GetTestControlType(ControlType.Button, Constants.SilverlightFrameworkId, true));
            Assert.AreEqual(typeof(TextBox), controlDictionary.GetTestControlType(ControlType.Edit, Constants.SilverlightFrameworkId, true));
        }

        [Test]
        public void GetTestType()
        {
            Assert.AreEqual(typeof(Button), controlDictionary.GetTestType(string.Empty, ControlType.Button, Constants.WinFormFrameworkId, "foo", false));
            Assert.AreEqual(typeof(Panel), controlDictionary.GetTestType(string.Empty, ControlType.Pane, Constants.WinFormFrameworkId, "foo", false));
            Assert.AreEqual(typeof(PropertyGrid), controlDictionary.GetTestType(string.Empty, ControlType.Pane, Constants.WinFormFrameworkId, "PropertyGrid", false));
        }

        [Test]
        public void ControlTypeCanChangeBasedOnFramework()
        {
            Assert.AreEqual(ControlType.Pane.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WinFormFrameworkId).ProgrammaticName);
            Assert.AreEqual(ControlType.Custom.ProgrammaticName, controlDictionary.GetControlType(typeof(DateTimePicker), Constants.WPFFrameworkId).ProgrammaticName);
        }
    }
}
