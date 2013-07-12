using System;
using Castle.DynamicProxy;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Repository.Interceptors
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
                invocation.Method.Invoke(window, invocation.Arguments);
            }
            catch (Exception)
            {
                listener.ScreenChanged();
            }
        }
    }
}