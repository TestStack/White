using System;
using Bricks.RuntimeFramework;
using Castle.DynamicProxy;
using White.Core.UIItems.WindowItems;

namespace Repository.Interceptors
{
    public class WindowInterceptor : IInterceptor
    {
        private readonly Window window;
        private readonly ScreenRepositoryListener listener;

        public WindowInterceptor(Window window, ScreenRepositoryListener listener)
        {
            this.window = window;
            this.listener = listener;
        }

        public virtual void Intercept(IInvocation invocation)
        {
            try
            {
                new ReflectedObject(window).Invoke(invocation.Method, invocation.Arguments);
            }
            catch (Exception)
            {
                listener.ScreenChanged();
            }
        }
    }
}