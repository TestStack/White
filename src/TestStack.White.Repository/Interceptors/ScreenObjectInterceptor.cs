using Castle.DynamicProxy;

namespace TestStack.White.Repository.Interceptors
{
    public class ScreenObjectInterceptor : IInterceptor
    {
        private readonly AppScreen appScreen;

        public ScreenObjectInterceptor(AppScreen appScreen)
        {
            this.appScreen = appScreen;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            invocation.Method.Invoke(appScreen, invocation.Arguments);
        }
    }
}