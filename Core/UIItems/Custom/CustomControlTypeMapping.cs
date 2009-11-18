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