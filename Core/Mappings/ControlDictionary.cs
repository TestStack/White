using System;
using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.Core;
using Bricks.RuntimeFramework;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.PropertyGridItems;
using White.Core.UIItems.Scrolling;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.TableItems;
using White.Core.UIItems.TreeItems;
using White.Core.UIItems.WindowStripControls;

namespace White.Core.Mappings
{
    public class ControlDictionary
    {
        public static readonly ControlDictionary Instance = new ControlDictionary();
        private readonly ControlDictionaryItems items = new ControlDictionaryItems();
        private readonly Types editableControls = new Types();

        private ControlDictionary()
        {
            items.AddWin32Primary(typeof (TextBox), ControlType.Edit);
            items.AddWPFPrimary(typeof (TextBox), ControlType.Edit);
            items.AddSilverlightPrimary(typeof (TextBox), ControlType.Edit);
            items.AddWinFormPrimary(typeof (WinFormTextBox), ControlType.Edit);

            items.AddWinFormPrimary(typeof (WinFormSlider), ControlType.Slider);
            items.AddWPFPrimary(typeof (WPFSlider), ControlType.Slider);
            items.AddSilverlightPrimary(typeof (WPFSlider), ControlType.Slider);

            items.AddPrimary(typeof (Thumb), ControlType.Thumb);
            items.AddPrimary(typeof (Button), ControlType.Button);
            items.AddPrimary(typeof (CheckBox), ControlType.CheckBox);
            items.AddPrimary(typeof (ListBox), ControlType.List);
            items.AddPrimary(typeof (Hyperlink), ControlType.Hyperlink);
            items.AddPrimary(typeof (Tree), ControlType.Tree);
            items.AddPrimary(typeof (RadioButton), ControlType.RadioButton);
            items.AddPrimary(typeof (Table), ControlType.Table);
            items.AddPrimary(typeof (MultilineTextBox), ControlType.Document);
            items.AddPrimary(typeof (Tab), ControlType.Tab, true);
            items.AddPrimary(typeof (ListView), ControlType.DataGrid);
            items.AddPrimary(typeof (ToolStrip), ControlType.ToolBar);
            items.AddWin32Primary(typeof (MenuBar), ControlType.MenuBar);
            items.AddWinFormPrimary(typeof (MenuBar), ControlType.MenuBar);
            items.AddWPFPrimary(typeof (MenuBar), ControlType.Menu);
            items.AddSilverlightPrimary(typeof(MenuBar), ControlType.Menu);
            items.AddPrimary(typeof (ProgressBar), ControlType.ProgressBar);
            items.AddPrimary(typeof (Spinner), ControlType.Spinner);

            items.Add(new ControlDictionaryItem(typeof (Panel), ControlType.Pane, "", false, true, false, null, true));

            ControlDictionaryItem dictionaryItem = ControlDictionaryItem.Primary(typeof (PropertyGrid), ControlType.Pane);
            dictionaryItem.IsIdentifiedByName = true;
            items.Add(dictionaryItem);

            items.AddWinFormPrimary(typeof (Label), ControlType.Text);
            items.AddWin32Primary(typeof (Label), ControlType.Text);
            items.AddWPFPrimary(typeof (WPFLabel), ControlType.Text);
            items.AddSilverlightPrimary(typeof (WPFLabel), ControlType.Text);

            items.AddWin32Primary(typeof (Win32ComboBox), ControlType.ComboBox);
            items.AddWinFormPrimary(typeof (WinFormComboBox), ControlType.ComboBox);
            items.AddWPFPrimary(typeof (WPFComboBox), ControlType.ComboBox);
            items.AddSilverlightPrimary(typeof (WPFComboBox), ControlType.ComboBox);

            items.AddWin32Primary(typeof (StatusStrip), ControlType.StatusBar);
            items.AddWinFormPrimary(typeof (StatusStrip), ControlType.StatusBar);
            items.AddWPFPrimary(typeof (WPFStatusBar), ControlType.StatusBar);
            items.AddSilverlightPrimary(typeof (WPFStatusBar), ControlType.StatusBar);
            items.AddWPFPrimary(typeof (Image), ControlType.Image);
            items.AddSilverlightPrimary(typeof (Image), ControlType.Image);
            items.AddWin32Primary(typeof (Image), ControlType.Image);

            items.AddSecondary(typeof (TableRowHeader), ControlType.Header);
            items.AddSecondary(typeof (TabPage), ControlType.TabItem, true);
            items.AddSecondary(typeof (VScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof (HScrollBar), ControlType.ScrollBar);
            items.AddSecondary(typeof (TableHeader), ControlType.Custom);
            items.AddSecondary(typeof (TableRow), ControlType.Custom);
            items.AddSecondary(typeof (Menu), ControlType.MenuItem);
            items.AddSecondary(typeof (ListViewRow), ControlType.DataItem);

            //TODO: create method for specific implementors (Tree, StatusBar, Label)
            items.Add(ControlDictionaryItem.WinFormSecondary(typeof (Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.Win32Secondary(typeof (Win32ListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.WPFSecondary(typeof (WPFListItem), ControlType.ListItem));
            items.Add(ControlDictionaryItem.SilverlightSecondary(typeof (WPFListItem), ControlType.ListItem));

            items.Add(ControlDictionaryItem.WinFormSecondary(typeof (Win32TreeNode), ControlType.TreeItem));
            items.Add(ControlDictionaryItem.WPFSecondary(typeof (WPFTreeNode), ControlType.TreeItem));
            items.Add(ControlDictionaryItem.Win32Secondary(typeof (Win32TreeNode), ControlType.TreeItem));

            items.Add(new ControlDictionaryItem(typeof (DateTimePicker), ControlType.Pane, "SysDateTimePick32", true, true, false, null, false));
            items.Add(new ControlDictionaryItem(typeof (GroupBox), ControlType.Group, string.Empty, false, true, false, null, true));
            items.Add(new ControlDictionaryItem(null, ControlType.TitleBar, string.Empty, false, false, true, null, false));
            items.Add(new ControlDictionaryItem(null, ControlType.Pane, string.Empty, false, false, false, null, true));

            editableControls.Add(typeof (TextBox));
            editableControls.Add(typeof (CheckBox));
            editableControls.Add(typeof (RadioButton));
            editableControls.Add(typeof (ListControl));
        }

        public virtual bool HasPrimaryChildren(ControlType controlType)
        {
            if (controlType.Equals(ControlType.Custom)) return true;
            ControlDictionaryItem item = items.FindBy(controlType);
            if (item == null) throw new ControlDictionaryException("Could not find control of type " + controlType.LocalizedControlType);
            return item.HasPrimaryChildren;
        }

        public virtual ControlType GetControlType(Type testControlType, string frameworkId)
        {
            return items.FindBy(testControlType, frameworkId).ControlType;
        }

        public virtual ControlType GetControlType(Type testControlType)
        {
            return items.FindBy(testControlType, null).ControlType;
        }

        public virtual Type GetTestControlType(ControlType controlType, string frameWorkId, bool isNativeControl)
        {
            ControlDictionaryItem dictionaryItem = items.Find(controlDictionaryItem =>
                                                                  {
                                                                      string itemFrameworkId = controlDictionaryItem.FrameworkId;
                                                                      bool controlTypeMatched = controlDictionaryItem.ControlType.Equals(controlType);

                                                                      if (!controlTypeMatched) return false;
                                                                      if (itemFrameworkId == null) return true;
                                                                      if (string.IsNullOrEmpty(frameWorkId))
                                                                      {
                                                                          if (Equals(itemFrameworkId, Constants.Win32FrameworkId) && isNativeControl)
                                                                              return true;
                                                                          if (Equals(itemFrameworkId, Constants.WPFFrameworkId) && !isNativeControl)
                                                                              return true;
                                                                      }
                                                                      return Equals(frameWorkId, itemFrameworkId);
                                                                  });
            if (dictionaryItem == null)
            {
                throw new ControlDictionaryException(string.Format("Could not find TestControl for ControlType={0} and FrameworkId:{1}",
                                                                   controlType.LocalizedControlType, frameWorkId));
            }
            return dictionaryItem.TestControlType;
        }

        public virtual Type GetTestControlType(string className)
        {
            if (S.IsEmpty(className)) return null;
            ControlDictionaryItem dictionaryItem =
                items.Find(
                    controlDictionaryItem => !string.IsNullOrEmpty(controlDictionaryItem.ClassName) && className.Contains(controlDictionaryItem.ClassName));
            if (dictionaryItem == null) return null;
            return dictionaryItem.TestControlType;
        }

        public virtual bool IsPrimaryControl(ControlType controlType, string className, string name)
        {
            return
                items.Exists(
                    controlDictionaryItem =>
                    (controlDictionaryItem.IsPrimary && controlDictionaryItem.ControlType.Equals(controlType) &&
                     !controlDictionaryItem.IsIdentifiedByClassName && !controlDictionaryItem.IsIdentifiedByName) ||
                    (S.IsNotEmpty(className) && className.Contains(controlDictionaryItem.ClassName) && controlDictionaryItem.IsIdentifiedByClassName) ||
                    (S.IsNotEmpty(name) && name.Equals("PropertyGrid") && controlDictionaryItem.IsIdentifiedByName));
        }

        public virtual bool IsExcluded(ControlType controlType)
        {
            return items.Exists(controlDictionaryItem => controlDictionaryItem.ControlType.Equals(controlType) && controlDictionaryItem.IsExcluded);
        }

        public virtual bool IsControlTypeSupported(ControlType controlType)
        {
            foreach (ControlDictionaryItem controlDictionaryItem in items)
                if (controlDictionaryItem.ControlType.Equals(controlType)) return true;
            return false;
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
            return editableControls.IsAssignableFrom(uiItem.GetType());
        }

        public virtual Type GetTestType(AutomationElement automationElement)
        {
            AutomationElement.AutomationElementInformation current = automationElement.Current;
            return GetTestType(current.ClassName, current.ControlType, current.FrameworkId, current.Name, current.NativeWindowHandle != 0);
        }

        public virtual Type GetTestType(string className, ControlType controlType, string frameworkId, string name, bool isNativeControl)
        {
            Type type = GetTestControlType(className);
            if (type == null && "PropertyGrid".Equals(name) && ControlType.Pane.Equals(controlType))
                type = typeof (PropertyGrid);
            if (type == null) type = GetTestControlType(controlType, frameworkId, isNativeControl);
            return type;
        }
    }
}
