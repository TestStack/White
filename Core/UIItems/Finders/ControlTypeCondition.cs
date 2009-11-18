using System;
using System.Windows.Automation;
using White.Core.Mappings;
using White.Core.UIItems.Custom;

namespace White.Core.UIItems.Finders
{
    public class ControlTypeCondition : SearchCondition
    {
        private readonly ControlType controlType;

        protected ControlTypeCondition() {}

        public ControlTypeCondition(ControlType controlType)
        {
            this.controlType = controlType;
        }

        public ControlTypeCondition(Type testControlType)
        {
            controlType = testControlType.IsCustomType() ? 
                                CustomControlTypeMapping.ControlType(testControlType) : ControlDictionary.Instance.GetControlType(testControlType);
        }

        public ControlTypeCondition(Type testControlType, string frameworkId)
        {
            controlType = testControlType.IsCustomType() ?
                                CustomControlTypeMapping.ControlType(testControlType) : ControlDictionary.Instance.GetControlType(testControlType, frameworkId);
        }

        public override Condition AutomationCondition
        {
            get { return new PropertyCondition(AutomationElement.ControlTypeProperty, controlType); }
        }

        public override bool Satisfies(AutomationElement element)
        {
            return element.Current.ControlType.Equals(controlType);
        }

        internal override string ToString(string operation)
        {
            return string.Format("ControlType{0}{1}", operation, controlType.LocalizedControlType);
        }

        protected internal override object SearchValue
        {
            get { return controlType; }
        }

        public virtual ControlType ControlType
        {
            get { return controlType; }
        }

        public override bool AppliesTo(AutomationElement element)
        {
            return controlType.Equals(element.Current.ControlType);
        }

        public override string ToString()
        {
            return ToString("=");
        }
    }

    public static class TestControlTypeX
    {
        public static bool IsCustomType(this Type type)
        {
            return typeof (CustomUIItem).IsAssignableFrom(type);
        }
    }
}