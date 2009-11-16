using Bricks.RuntimeFramework;
using Castle.Core.Interceptor;

namespace Repository.Interceptors
{
    public class ScreenObjectInterceptor : IInterceptor
    {
        private readonly ReflectedObject reflectedScreen;

        public ScreenObjectInterceptor(AppScreen appScreen)
        {
            reflectedScreen = new ReflectedObject(appScreen);
        }

        public virtual void Intercept(IInvocation invocation)
        {
            reflectedScreen.Invoke(invocation.Method, invocation.Arguments);
        }
    }
}