using Castle.DynamicProxy;
using TestStack.White.UIItems;

namespace TestStack.White.Interceptors
{
    //Doc PrimaryUIItems would be scrolled automatically but secondary wont
    public class ScrollInterceptor : IWhiteInterceptor
    {
        public virtual void PreProcess(IInvocation invocation, CoreInterceptContext context)
        {
            if (invocation.Method.Name.StartsWith("get_") || "ToString".Equals(invocation.Method.Name))
                return;

            context.ActionListener.ActionPerforming((UIItem)context.UiItem);
        }

        public virtual void PostProcess(IInvocation invocation, CoreInterceptContext context) { }
    }
}