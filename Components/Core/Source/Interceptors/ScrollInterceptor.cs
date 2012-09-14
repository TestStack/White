using Bricks.DynamicProxy;
using Castle.DynamicProxy;
using White.Core.UIItems;

namespace White.Core.Interceptors
{
    //Doc PrimaryUIItems would be scrolled automatically but secondary wont
    public class ScrollInterceptor : DynamicProxyInterceptor
    {
        public virtual void PreProcess(IInvocation invocation, object target)
        {
            if (invocation.Method.Name.StartsWith("get_") || "ToString".Equals(invocation.Method.Name))
                return;

            var coreInterceptContext = (CoreInterceptContext) target;
            coreInterceptContext.ActionListener.ActionPerforming((UIItem) coreInterceptContext.UiItem);
        }

        public virtual void PostProcess(IInvocation invocation, object target) {}
    }
}