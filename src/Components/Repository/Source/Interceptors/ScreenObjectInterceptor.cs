using Castle.DynamicProxy;

namespace Repository.Interceptors
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