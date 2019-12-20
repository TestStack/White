using System;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Custom
{
    public class CustomUIItem : UIItem
    {
        private UIItemContainer container;

        public CustomUIItem(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        protected CustomUIItem() {}

        /// <summary>
        /// Container which can used to find the UIItems inside this item.
        /// e.g. Container.Get<TextBox>("day") to find a TextBox with AutomationId "day" inside this item.
        /// You can also use any SearchCriteria for performing the find
        /// </summary>
        protected virtual UIItemContainer Container
        {
            get { return container; }
        }

        internal virtual void SetContainer(UIItemContainer uiItemContainer)
        {
            container = uiItemContainer;
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Allows setting value of Custom UI items
        /// </summary>
        public override void SetValue(object value)
        {
            //Look for value pattern in the object
            var pattern = Pattern(ValuePattern.Pattern) as ValuePattern;
            if (pattern != null)
            {
                pattern.SetValue(value.ToString());
            }
        }

        /// <summary>
        /// Allows getting value of Custom UI items
        /// </summary>
        /// <returns>Value pattern value as a string</returns>
        public string GetValue()
        {
            var pattern = Pattern(ValuePattern.Pattern) as ValuePattern;
            if (pattern != null)
            {
                return pattern.Current.Value;
            }

            //If nothing found or pattern is not accessible return empty string
            return string.Empty;
        }
    }
}
