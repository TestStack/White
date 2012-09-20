using System.Threading;
using Castle.DynamicProxy;

namespace White.Core.Interceptors
{
    //TODO How to do focus on secondary controls?
    public class FocusInterceptor : IWhiteInterceptor
    {
        public virtual void PreProcess(IInvocation invocation, CoreInterceptContext context)
        {
            if (invocation.Method.Name.StartsWith("get_") || "ToString".Equals(invocation.Method.Name))
                return;
            context.UiItem.Focus();
        }

        public virtual void PostProcess(IInvocation invocation, CoreInterceptContext context) { }
    }
}