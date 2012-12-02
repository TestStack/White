using System;
using White.Core.Bricks;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core.Interceptors
{
    public class CoreInterceptContext : IInterceptContext
    {
        private readonly IUIItem uiItem;
        private readonly ActionListener actionListener;

        public CoreInterceptContext(IUIItem uiItem, ActionListener actionListener)
        {
            this.uiItem = uiItem;
            this.actionListener = actionListener;
        }

        public virtual IUIItem UiItem
        {
            get { return uiItem; }
        }

        public virtual ActionListener ActionListener
        {
            get { return actionListener; }
        }

        public virtual object Target
        {
            get { return uiItem; }
        }

        public virtual void VerifyUIItem()
        {
            if (uiItem.AutomationElement == null) throw new NullReferenceException("AutomationElement in this UIItem is null");
        }
    }
}