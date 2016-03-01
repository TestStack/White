using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Custom;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.PropertyGridItems;
using TestStack.White.UIItems.Scrolling;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TestStack.White.Mappings
{
    public class ControlDictionary
    {
        public static readonly ControlDictionary Instance = new ControlDictionary();
        private readonly ControlDictionaryItems items = new ControlDictionaryItems();
        private readonly List<Type> editableControls = new List<Type>();

        private ControlDictionary()
        {
            items.AddFrameworkSpecificPrimary(ControlType.Edit, typeof(TextBox), typeof(WinFormTextBox), typeof(TextBox), typeof(TextBox));

            items.AddWinFormPrimary(typeof(WinFormSlider), ControlType.Slider);
            items.AddWPFPrimary(typeof(WPFSlider), ControlType.Slider);
            items.AddSilverlightPrimary(typeof(WPFSlider), ControlType.Slider);

            items.AddPrimary(typeof(Thumb), ControlType.Thumb);
            items.AddPrimary(typeof(Button), ControlType.Button);
            items.AddPrimary(typeof(CheckBox), ControlType.CheckBox);
            items.AddPrimary(typeof(ListBox), ControlType.List);
            items.AddPrimary(typeof(Hyperlink), ControlType.Hyperlink);
            items.AddPrimary(typeof(Tree), ControlType.Tree);
            items.AddPrimary(typeof(RadioButton), ControlType.RadioButton);
            items.AddPrimary(typeof(Table), ControlType.Table);
            items.AddPrimary(typeof(Tab), ControlType.Tab, true);
            items.AddPrimary(typeof(ListView), ControlType.DataGrid);
            items.AddPrimary(typeof(ToolStrip), ControlType.ToolBar);

            items.AddWin32Primary(typeof(MenuBar), ControlType.MenuBar);
            items.AddWinFormPrimary(typeof(MenuBar), ControlType.MenuBar);
            items.AddWPFPrimary(typeof(MenuBar), ControlType.Menu);
            items.AddSilverlightPrimary(typeof(MenuBar), ControlType.Menu);

            items.AddPrimary(typeof(ProgressBar), ControlType.ProgressBar);
            items.AddPrimary(typeof(Spinner), ControlType.Spinner);

            items.Add(new ControlDictionaryItem(typeof(Panel), ControlType.Pane, "", false, true, false, null, true));

            ControlDictionaryItem dictionaryItem = ControlDictionaryItem.Primary(typeof(PropertyGrid), ControlType.Pane);
            dictionaryItem.IsIdentifiedByName = true;
            items.Add(dictionaryItem);

            items.AddFrameworkSpecificPrimary(ControlType.Text, typeof(Label), typeof(Label), typeof(WPFLabel), typeof(WPFLabel));
            items.AddFrameworkSpecificPrimary(ControlType.ComboBox, typeof(Win32ComboBox), typeof(WinFormComboBox), typeof(WPFComboBox), typeof(SilverlightComboBox));
            items.AddFrameworkSpecificPrimary(ControlType.StatusBar, typeof(StatusStrip), typeof(StatusStrip), typeof(WPFStatusBar), typeof(WPFStatusBar));

            items.AddWPFPrimary(typeof(CustomUIItem), ControlType.Custom);
            items.AddWinFormPrimary(typeof(TextBox), ControlType.Document);
            items.AddWin32Primary(typeof(TextBox), ControlType.Document);
            items.AddWPFPrimary(typeof(Image), ControlType.Image);
            items.AddSilverlightPrimary(typeof(Image), ControlType.Image);
            items.AddWin32Primary(typeof(Image), ControlType.Image);

            items.AddSilverlightPrimary(typeof(SilverlightChildWindow), ControlType.Window);

            items.AddSecondary(typeof(TableRowHeader), ControlType.Header);
            items.AddSecondary(typeof(TabPage), ControlType.TabItem, true);
            items.AddSecondary(typeof(VScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof(HScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof(TableHeader), ControlType.Custom);
            items.AddSecondary(typeof(TableRow), ControlType.Custom);
            items.AddSecondary(typeof(Menu), ControlType.MenuItem);
            items.AddSecondary(typeof(ListViewRow), ControlType.DataItem);

            //TODO: create method for specific implementors (Tree, StatusBar, Label)
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.Win32Secondary(typeof(Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.WPFSecondary(typeof(WPFListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.SilverlightSecondary(typeof(WPFListItem), ControlType.ListItem));

            items.Add(ControlDictionaryItem.WinFormSecondary(typeof(Win32TreeNode), ControlType.TreeItem));
            items.Add(ControlDictionaryItem.WPFSecondary(typeof(WPFTreeNode), ControlType.TreeItem));
            items.Add(ControlDictionaryItem.Win32Secondary(typeof(Win32TreeNode), ControlType.TreeItem));

            items.Add(new ControlDictionaryItem(typeof(DateTimePicker), ControlType.Pane, "SysDateTimePick32", true, true, false, WindowsFramework.WinForms.FrameworkId(), false));
            items.Add(new ControlDictionaryItem(typeof(WpfDatePicker), ControlType.Custom, "DatePicker", true, true, false, WindowsFramework.Wpf.FrameworkId(), false));
            items.Add(new ControlDictionaryItem(typeof(WpfDatePicker), ControlType.Pane, "DatePicker", true, true, false, WindowsFramework.Silverlight.FrameworkId(), false));
            items.Add(new ControlDictionaryItem(typeof(GroupBox), ControlType.Group, string.Empty, false, true, false, null, true));
            items.Add(new ControlDictionaryItem(null, ControlType.TitleBar, string.Empty, false, false, true, null, false));

            editableControls.Add(typeof(TextBox));
            editableControls.Add(typeof(CheckBox));
            editableControls.Add(typeof(RadioButton));
            editableControls.Add(typeof(ListControl));
        }

        public virtual bool HasPrimaryChildren(ControlType controlType)
        {
            if (controlType.Equals(ControlType.Custom)) return true;
            var results = items.FindBy(controlType).ToArray();
            if (!results.Any()) throw new ControlDictionaryException("Could not find control of type " + controlType.LocalizedControlType);
            return results.Any(i => i.HasPrimaryChildren);
        }

        public virtual ControlType[] GetControlType(Type testControlType, string frameworkId)
        {
            var controlDictionaryItem = items.FindBy(testControlType, frameworkId);
            if (controlDictionaryItem == null)
                throw new WhiteException(string.Format("Cannot find {0} for {1}", testControlType.Name, frameworkId));
            return controlDictionaryItem.Select(c => c.ControlType).ToArray();
        }

        public virtual Type GetTestControlType(string className, string name, ControlType controlType, string frameWorkId, bool isNativeControl)
        {
            if (Equals(controlType, ControlType.ListItem) && string.IsNullOrEmpty(frameWorkId))
                frameWorkId = WindowsFramework.Win32.FrameworkId();

            var dictionaryItems = items.Where(controlDictionaryItem =>
            {
                if (!ControlTypeMatches(controlType, controlDictionaryItem)) return false;
                if (!FrameworkIdMatches(frameWorkId, controlDictionaryItem)) return false;
                if (controlDictionaryItem.IsIdentifiedByClassName && !className.Contains(controlDictionaryItem.ClassName))
                    return false;
                if (controlDictionaryItem.IsIdentifiedByName && controlDictionaryItem.TestControlType.Name != name)
                    return false;

                return true;
            })
            .ToArray();
            if (!dictionaryItems.Any())
            {
                throw new ControlDictionaryException(string.Format("Could not find TestControl for ControlType={0} and FrameworkId:{1}",
                                                                   controlType.LocalizedControlType, frameWorkId));
            }
            if (dictionaryItems.Length > 1)
            {
                var primaries = dictionaryItems.Where(i => IsPrimaryControl(i.ControlType, className, name)).ToArray();
                if (primaries.Length == 1)
                    return primaries.Single().TestControlType;

                var identifiedByName = dictionaryItems.Where(i => i.IsIdentifiedByName).ToArray();
                if (identifiedByName.Length == 1)
                    return identifiedByName.Single().TestControlType;
                var identifiedByClassName = dictionaryItems.Where(i => i.IsIdentifiedByClassName).ToArray();
                if (identifiedByClassName.Length == 1)
                    return identifiedByClassName.Single().TestControlType;
                var isPrimary = dictionaryItems.Where(i => i.IsPrimary).ToArray();
                if (isPrimary.Length == 1)
                    return isPrimary.Single().TestControlType;

                //Get the first TestControldType when 'dictionaryItems' contains multiple elements...
                var isFirstItem = dictionaryItems.First();
                return isFirstItem.TestControlType;

                throw new ControlDictionaryException(string.Format(
                   "Multiple TestControls found for ControlType={0} and FrameworkId:{1} - {2}",
                   controlType.LocalizedControlType, frameWorkId,
                   string.Join(", ", dictionaryItems.Select(d => d.TestControlType == null ? "null" : d.TestControlType.FullName))));

            }
            return dictionaryItems.Single().TestControlType;
        }

        private static bool ControlTypeMatches(ControlType controlType, ControlDictionaryItem controlDictionaryItem)
        {
            return controlDictionaryItem.ControlType.Equals(controlType);
        }

        private static bool FrameworkIdMatches(string frameWorkId, ControlDictionaryItem controlDictionaryItem)
        {
            return string.IsNullOrEmpty(frameWorkId) ||
                controlDictionaryItem.FrameworkId == frameWorkId ||
                string.IsNullOrEmpty(controlDictionaryItem.FrameworkId);
        }

        public virtual bool IsPrimaryControl(ControlType controlType, string className, string name)
        {
            return items.Exists(controlDictionaryItem =>
            {
                bool isPrimaryMatching = controlDictionaryItem.IsPrimary && ControlTypeMatches(controlType, controlDictionaryItem) && !controlDictionaryItem.IsIdentifiedByClassName && !controlDictionaryItem.IsIdentifiedByName;
                bool identifiedByClassNameMatches = !string.IsNullOrWhiteSpace(className) && className.Contains(controlDictionaryItem.ClassName) && controlDictionaryItem.IsIdentifiedByClassName;
                bool identifiedByNameMatches = !string.IsNullOrWhiteSpace(name) && controlDictionaryItem.TestControlType != null && name.Equals(controlDictionaryItem.TestControlType.Name) && controlDictionaryItem.IsIdentifiedByName;
                return isPrimaryMatching || identifiedByClassNameMatches || identifiedByNameMatches;
            });
        }

        public virtual bool IsExcluded(ControlType controlType)
        {
            return items.Exists(controlDictionaryItem => controlDictionaryItem.ControlType.Equals(controlType) && controlDictionaryItem.IsExcluded);
        }

        public virtual bool IsControlTypeSupported(ControlType controlType)
        {
            return items.Any(controlDictionaryItem => controlDictionaryItem.ControlType.Equals(controlType));
        }

        public virtual List<ControlType> PrimaryControlTypes(string frameworkId)
        {
            var controlTypes = new List<ControlType>();
            foreach (ControlDictionaryItem controlDictionaryItem in items)
            {
                if (controlDictionaryItem.OfFramework(frameworkId) && controlDictionaryItem.IsPrimary &&
                    !controlTypes.Contains(controlDictionaryItem.ControlType))
                    controlTypes.Add(controlDictionaryItem.ControlType);
            }
            return controlTypes;
        }

        public virtual bool IsEditable(UIItem uiItem)
        {
            return editableControls.All(t => t.IsInstanceOfType(uiItem));
        }

        public virtual Type GetTestControlType(AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation current = automationElement.Current;
            return GetTestControlType(current.ClassName, current.Name, current.ControlType, current.FrameworkId, current.NativeWindowHandle != 0);
        }
    }
}
