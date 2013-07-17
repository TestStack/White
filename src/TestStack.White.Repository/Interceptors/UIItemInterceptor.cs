using System;
using Castle.DynamicProxy;
using TestStack.White.Bricks;
using TestStack.White.Factory;
using TestStack.White.Reporting.Domain;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Repository.Interceptors
{
    /// <summary>
    /// Lazily initializes the UIItem.
    /// </summary>
    public class UIItemInterceptor : IInterceptor
    {
        private readonly SearchCriteria searchCriteria;
        private readonly Window window;
        private readonly IReport sessionReport;
        private IUIItem uiItem;

        public UIItemInterceptor(SearchCriteria searchCriteria, Window window,IReport sessionReport)
        {
            this.searchCriteria = searchCriteria;
            this.window = window;
            this.sessionReport = sessionReport;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            if (uiItem == null)
            {
                uiItem = window.Get(searchCriteria);
                if (uiItem == null) throw new UIItemSearchException("Could not find UIItem with, " + searchCriteria);
            }
            try
            {
                var invoker = DelegateInvoker.CreateInvoker(uiItem, invocation.Method);
                invocation.ReturnValue = invoker.Call(invocation.Arguments);
            }
            catch (Exception)
            {
                sessionReport.Act();
                throw;
            }
        }
    }
}