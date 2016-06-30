// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomControlTypeMapping.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the CustomControlTypeMapping type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.UIItems.Custom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    /// <summary>
    /// The custom control type mapping.
    /// </summary>
    public static class CustomControlTypeMapping
    {
        /// <summary>
        /// The mappings.
        /// </summary>
        private static readonly Dictionary<CustomUIItemType, ControlType> Mappings = new Dictionary<CustomUIItemType, ControlType>();

        /// <summary>
        /// Initializes static members of the <see cref="CustomControlTypeMapping"/> class.
        /// </summary>
        static CustomControlTypeMapping()
        {
            Mappings[CustomUIItemType.Pane] = System.Windows.Automation.ControlType.Pane;
            Mappings[CustomUIItemType.Custom] = System.Windows.Automation.ControlType.Custom;
            Mappings[CustomUIItemType.Group] = System.Windows.Automation.ControlType.Group;
            Mappings[CustomUIItemType.Window] = System.Windows.Automation.ControlType.Window;
            Mappings[CustomUIItemType.Table] = System.Windows.Automation.ControlType.Table;
            Mappings[CustomUIItemType.Button] = System.Windows.Automation.ControlType.Button;
            Mappings[CustomUIItemType.Calendar] = System.Windows.Automation.ControlType.Calendar;
            Mappings[CustomUIItemType.CheckBox] = System.Windows.Automation.ControlType.CheckBox;
            Mappings[CustomUIItemType.ComboBox] = System.Windows.Automation.ControlType.ComboBox;
            Mappings[CustomUIItemType.DataGrid] = System.Windows.Automation.ControlType.DataGrid;
            Mappings[CustomUIItemType.DataItem] = System.Windows.Automation.ControlType.DataItem;
            Mappings[CustomUIItemType.Document] = System.Windows.Automation.ControlType.Document;
            Mappings[CustomUIItemType.Edit] = System.Windows.Automation.ControlType.Edit;
            Mappings[CustomUIItemType.Header] = System.Windows.Automation.ControlType.Header;
            Mappings[CustomUIItemType.HeaderItem] = System.Windows.Automation.ControlType.HeaderItem;
            Mappings[CustomUIItemType.Hyperlink] = System.Windows.Automation.ControlType.Hyperlink;
            Mappings[CustomUIItemType.Image] = System.Windows.Automation.ControlType.Image;
            Mappings[CustomUIItemType.List] = System.Windows.Automation.ControlType.List;
            Mappings[CustomUIItemType.ListItem] = System.Windows.Automation.ControlType.ListItem;
            Mappings[CustomUIItemType.Menu] = System.Windows.Automation.ControlType.Menu;
            Mappings[CustomUIItemType.MenuBar] = System.Windows.Automation.ControlType.MenuBar;
            Mappings[CustomUIItemType.MenuItem] = System.Windows.Automation.ControlType.MenuItem;
            Mappings[CustomUIItemType.ProgressBar] = System.Windows.Automation.ControlType.ProgressBar;
            Mappings[CustomUIItemType.RadioButton] = System.Windows.Automation.ControlType.RadioButton;
            Mappings[CustomUIItemType.ScrollBar] = System.Windows.Automation.ControlType.ScrollBar;
            Mappings[CustomUIItemType.Separator] = System.Windows.Automation.ControlType.Separator;
            Mappings[CustomUIItemType.Slider] = System.Windows.Automation.ControlType.Slider;
            Mappings[CustomUIItemType.Spinner] = System.Windows.Automation.ControlType.Spinner;
            Mappings[CustomUIItemType.SplitButton] = System.Windows.Automation.ControlType.SplitButton;
            Mappings[CustomUIItemType.StatusBar] = System.Windows.Automation.ControlType.StatusBar;
            Mappings[CustomUIItemType.Tab] = System.Windows.Automation.ControlType.Tab;
            Mappings[CustomUIItemType.TabItem] = System.Windows.Automation.ControlType.TabItem;
            Mappings[CustomUIItemType.Text] = System.Windows.Automation.ControlType.Text;
            Mappings[CustomUIItemType.Thumb] = System.Windows.Automation.ControlType.Thumb;
            Mappings[CustomUIItemType.TitleBar] = System.Windows.Automation.ControlType.TitleBar;
            Mappings[CustomUIItemType.ToolBar] = System.Windows.Automation.ControlType.ToolBar;
            Mappings[CustomUIItemType.ToolTip] = System.Windows.Automation.ControlType.ToolTip;
            Mappings[CustomUIItemType.Tree] = System.Windows.Automation.ControlType.Tree;
            Mappings[CustomUIItemType.TreeItem] = System.Windows.Automation.ControlType.TreeItem;
        }

        /// <summary>
        /// The control type.
        /// </summary>
        /// <param name="customUIItemType">
        /// The custom UI item type.
        /// </param>
        /// <returns>
        /// The <see cref="System.Windows.Automation.ControlType"/>.
        /// </returns>
        public static ControlType ControlType(CustomUIItemType customUIItemType)
        {
            return Mappings[customUIItemType];
        }

        /// <summary>
        /// The control type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="framework">
        /// The framework.
        /// </param>
        /// <returns>
        /// The <see cref="System.Windows.Automation.ControlType"/>.
        /// </returns>
        public static ControlType ControlType(Type type, WindowsFramework framework)
        {
            var controlTypeMappingAttribute = type.GetCustomAttributes(typeof(ControlTypeMappingAttribute), true)
                .OfType<ControlTypeMappingAttribute>()
                .ToArray();
            if (!controlTypeMappingAttribute.Any())
            {
                throw new CustomUIItemException(
                    "ControlTypeMappingAttribute needs to be defined for this type: " + type.FullName);
            }

            var frameworkSpecific = controlTypeMappingAttribute.FirstOrDefault(c => c.AppliesToFramework == framework);
            return ControlType(frameworkSpecific?.CustomUIItemType ?? controlTypeMappingAttribute.Single(a => a.AppliesToFramework == null).CustomUIItemType);
        }
    }
}