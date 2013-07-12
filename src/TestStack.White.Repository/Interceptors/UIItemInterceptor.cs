using System;
using Castle.DynamicProxy;
using TestStack.White.Reporting.Domain;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.Repository.Interceptors
{
    /// <summary>
    /// Lazily initializes the UIItem.
    /// </summary>
    //TODO: Use DynamicProxy correctly by using its own mechanism of forwarding the call
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
                invocation.ReturnValue = invocation.Method.Invoke(uiItem, invocation.Arguments);
            }
            catch (Exception e)
            {
                sessionReport.Act();
                throw new WhiteException(string.Format("Error Invoking {0}.{1}", uiItem.GetType().Name, invocation.Method.Name), e.InnerException);
            }
        }
    }
}