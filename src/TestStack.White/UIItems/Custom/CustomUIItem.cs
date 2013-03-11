using System;
using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Custom
{
    public class CustomUIItem : UIItem, IMappableUIItem
    {
        private UIItemContainer container;

        protected CustomUIItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        protected CustomUIItem() {}

        /// <summary>
        /// Container which can used to find the UIItems inside this item.
        /// <!--e.g. Container.Get<TextBox>("day") to find a TextBox with AutomationId "day" inside this item.
        /// You can also use any SearchCriteria for performing the find-->
        /// </summary>
        protected virtual UIItemContainer Container
        {
            get { return container; }
        }

        internal virtual void SetContainer(UIItemContainer uiItemContainer)
        {
            container = uiItemContainer;
        }

        /// <exception cref="NotImplementedException"> always </exception>
        public override void ActionPerforming(UIItem uiItem)
        {
            throw new NotImplementedException();
        }
    }
}
