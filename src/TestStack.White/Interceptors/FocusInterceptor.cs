using Bricks.DynamicProxy;
using Castle.DynamicProxy;

namespace White.Core.Interceptors
{
    //TODO How to do focus on secondary controls?
    public class FocusInterceptor : DynamicProxyInterceptor
    {
        public virtual void PreProcess(IInvocation invocation, object target)
        {
            if (invocation.Method.Name.StartsWith("get_") || "ToString".Equals(invocation.Method.Name))
                return;
            ((CoreInterceptContext) target).UiItem.Focus();
        }

        public virtual void PostProcess(IInvocation invocation, object target) {}
    }
}