using System.Windows.Automation;

namespace White.Core.UIItems.Finders
{
    public class ControlTypeProperty : AutomationElementProperty
    {
        public ControlTypeProperty(ControlType controlType, string displayName)
            : base(controlType, displayName, AutomationElement.ControlTypeProperty) {}

        public override string DisplayValue
        {
            get { return ((ControlType) value).LocalizedControlType; }
        }
    }
}