using Castle.DynamicProxy;

namespace TestStack.White.Interceptors
{
    public interface IWhiteInterceptor
    {
        void PreProcess(IInvocation invocation, CoreInterceptContext context);
        void PostProcess(IInvocation invocation, CoreInterceptContext context);
    }
}