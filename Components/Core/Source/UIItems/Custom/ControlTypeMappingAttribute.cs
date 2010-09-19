using System;

namespace White.Core.UIItems.Custom
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControlTypeMappingAttribute : Attribute
    {
        private readonly CustomUIItemType customUIItemType;

        public ControlTypeMappingAttribute(CustomUIItemType customUIItemType)
        {
            this.customUIItemType = customUIItemType;
        }

        public virtual CustomUIItemType CustomUIItemType
        {
            get { return customUIItemType; }
        }
    }
}