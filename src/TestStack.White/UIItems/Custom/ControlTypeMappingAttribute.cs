using System;

namespace TestStack.White.UIItems.Custom
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ControlTypeMappingAttribute : Attribute
    {
        private readonly CustomUIItemType customUIItemType;
        private readonly WindowsFramework? appliesToFramework;

        public ControlTypeMappingAttribute(CustomUIItemType customUIItemType)
        {
            this.customUIItemType = customUIItemType;
        }

        public ControlTypeMappingAttribute(CustomUIItemType customUIItemType, WindowsFramework appliesToFramework)
        {
            this.customUIItemType = customUIItemType;
            this.appliesToFramework = appliesToFramework;
        }

        public virtual CustomUIItemType CustomUIItemType
        {
            get { return customUIItemType; }
        }

        public virtual WindowsFramework? AppliesToFramework
        {
            get { return appliesToFramework; }
        }
    }
}