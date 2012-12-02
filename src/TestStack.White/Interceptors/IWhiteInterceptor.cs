using Castle.DynamicProxy;

namespace White.Core.Interceptors
{
    public interface IWhiteInterceptor
    {
        void PreProcess(IInvocation invocation, CoreInterceptContext context);
        void PostProcess(IInvocation invocation, CoreInterceptContext context);
    }
}