using System;
using TestStack.White.Bricks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Interceptors
{
    public class CoreInterceptContext : IInterceptContext
    {
        private readonly IUIItem uiItem;
        private readonly IActionListener actionListener;

        public CoreInterceptContext(IUIItem uiItem, IActionListener actionListener)
        {
            this.uiItem = uiItem;
            this.actionListener = actionListener;
        }

        public virtual IUIItem UiItem
        {
            get { return uiItem; }
        }

        public virtual IActionListener ActionListener
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