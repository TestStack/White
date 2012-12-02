using System;
using Castle.DynamicProxy;
using White.Core.Bricks;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using log4net;

namespace White.Core.Interceptors
{
    public class CoreInterceptor : IInterceptor
    {
        private readonly CoreInterceptContext coreInterceptContext;
        private readonly ILog logger = LogManager.GetLogger(typeof(CoreInterceptor));

        public CoreInterceptor(IUIItem uiItem, ActionListener actionListener)
        {
            coreInterceptContext = new CoreInterceptContext(uiItem, actionListener);
        }

        public virtual void Intercept(IInvocation invocation)
        {
            coreInterceptContext.VerifyUIItem();
            try
            {
                CoreAppXmlConfiguration.Instance.Interceptors.Process(invocation, coreInterceptContext);
            }
            catch (Exception)
            {
                logger.Error(DynamicProxyInterceptors.ToString(invocation));
                throw;
            }
        }

        public virtual CoreInterceptContext Context
        {
            get { return coreInterceptContext; }
        }
    }
}