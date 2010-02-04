using System;
using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.RuntimeFramework;

namespace White.Core.UIItems.Custom
{
    public class CustomControlTypeMapping
    {
        private static readonly Dictionary<CustomUIItemType, ControlType> mappings = new Dictionary<CustomUIItemType, ControlType>();

        static CustomControlTypeMapping()
        {
            mappings[CustomUIItemType.Pane] = System.Windows.Automation.ControlType.Pane;
            mappings[CustomUIItemType.Custom] = System.Windows.Automation.ControlType.Custom;
            mappings[CustomUIItemType.Group] = System.Windows.Automation.ControlType.Group;
            mappings[CustomUIItemType.Window] = System.Windows.Automation.ControlType.Window;
            mappings[CustomUIItemType.Table] = System.Windows.Automation.ControlType.Table;
            mappings[CustomUIItemType.Button] = System.Windows.Automation.ControlType.Button;
            mappings[CustomUIItemType.Calendar] = System.Windows.Automation.ControlType.Calendar;
            mappings[CustomUIItemType.CheckBox] = System.Windows.Automation.ControlType.CheckBox;
            mappings[CustomUIItemType.ComboBox] = System.Windows.Automation.ControlType.ComboBox;
            mappings[CustomUIItemType.DataGrid] = System.Windows.Automation.ControlType.DataGrid;
            mappings[CustomUIItemType.DataItem] = System.Windows.Automation.ControlType.DataItem;
            mappings[CustomUIItemType.Document] = System.Windows.Automation.ControlType.Document;
            mappings[CustomUIItemType.Edit] = System.Windows.Automation.ControlType.Edit;
            mappings[CustomUIItemType.Header] = System.Windows.Automation.ControlType.Header;
            mappings[CustomUIItemType.HeaderItem] = System.Windows.Automation.ControlType.HeaderItem;
            mappings[CustomUIItemType.Hyperlink] = System.Windows.Automation.ControlType.Hyperlink;
            mappings[CustomUIItemType.Image] = System.Windows.Automation.ControlType.Image;
            mappings[CustomUIItemType.List] = System.Windows.Automation.ControlType.List;
            mappings[CustomUIItemType.ListItem] = System.Windows.Automation.ControlType.ListItem;
            mappings[CustomUIItemType.Menu] = System.Windows.Automation.ControlType.Menu;
            mappings[CustomUIItemType.MenuBar] = System.Windows.Automation.ControlType.MenuBar;
            mappings[CustomUIItemType.MenuItem] = System.Windows.Automation.ControlType.MenuItem;
            mappings[CustomUIItemType.ProgressBar] = System.Windows.Automation.ControlType.ProgressBar;
            mappings[CustomUIItemType.RadioButton] = System.Windows.Automation.ControlType.RadioButton;
            mappings[CustomUIItemType.ScrollBar] = System.Windows.Automation.ControlType.ScrollBar;
            mappings[CustomUIItemType.Separator] = System.Windows.Automation.ControlType.Separator;
            mappings[CustomUIItemType.Slider] = System.Windows.Automation.ControlType.Slider;
            mappings[CustomUIItemType.Spinner] = System.Windows.Automation.ControlType.Spinner;
            mappings[CustomUIItemType.SplitButton] = System.Windows.Automation.ControlType.SplitButton;
            mappings[CustomUIItemType.StatusBar] = System.Windows.Automation.ControlType.StatusBar;
            mappings[CustomUIItemType.Tab] = System.Windows.Automation.ControlType.Tab;
            mappings[CustomUIItemType.TabItem] = System.Windows.Automation.ControlType.TabItem;
            mappings[CustomUIItemType.Text] = System.Windows.Automation.ControlType.Text;
            mappings[CustomUIItemType.Thumb] = System.Windows.Automation.ControlType.Thumb;
            mappings[CustomUIItemType.TitleBar] = System.Windows.Automation.ControlType.TitleBar;
            mappings[CustomUIItemType.ToolBar] = System.Windows.Automation.ControlType.ToolBar;
            mappings[CustomUIItemType.ToolTip] = System.Windows.Automation.ControlType.ToolTip;
            mappings[CustomUIItemType.Tree] = System.Windows.Automation.ControlType.Tree;
            mappings[CustomUIItemType.TreeItem] = System.Windows.Automation.ControlType.TreeItem;
        }

        public static ControlType ControlType(CustomUIItemType customUIItemType)
        {
            return mappings[customUIItemType];
        }

        public static ControlType ControlType(Type type)
        {
            var @class = new Class(type);
            if (!@class.HasAttribute(typeof (ControlTypeMappingAttribute)))
                throw new CustomUIItemException("ControlTypeMappingAttribute needs to be defined for this type: " + type.FullName);
            var controlTypeMappingAttribute = @class.Attribute<ControlTypeMappingAttribute>();
            return ControlType(controlTypeMappingAttribute.CustomUIItemType);
        }
    }
}