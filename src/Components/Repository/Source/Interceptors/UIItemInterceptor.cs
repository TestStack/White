using System;
using Bricks.RuntimeFramework;
using Castle.DynamicProxy;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using Reporting.Domain;

namespace Repository.Interceptors
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
        private ReflectedObject reflectedUIItem;
        
        public UIItemInterceptor(SearchCriteria searchCriteria, Window window,IReport sessionReport)
        {
            this.searchCriteria = searchCriteria;
            this.window = window;
            this.sessionReport = sessionReport;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            if (reflectedUIItem == null)
            {
                IUIItem uiItem = window.Get(searchCriteria);
                if (uiItem == null) throw new UIItemSearchException("Could not find UIItem with, " + searchCriteria);
                reflectedUIItem = new ReflectedObject(uiItem);
            }
            try
            {
                invocation.ReturnValue = reflectedUIItem.Invoke(invocation.Method, invocation.Arguments);
            }
            catch (Exception e)
            {
                sessionReport.Act();
                throw new WhiteException(string.Format("Error Invoking {0}.{1}", reflectedUIItem.Class.Name, invocation.Method.Name), e.InnerException);
            }
        }
    }
}