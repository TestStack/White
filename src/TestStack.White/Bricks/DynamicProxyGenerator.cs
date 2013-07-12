using System;
using Castle.DynamicProxy;

namespace TestStack.White.Bricks
{
    public class DynamicProxyGenerator
    {
        private static readonly DynamicProxyGenerator ProxyGenerator = new DynamicProxyGenerator();
        private readonly ProxyGenerator generator = new ProxyGenerator();

        public static DynamicProxyGenerator Instance
        {
            get { return ProxyGenerator; }
        }

        public virtual object CreateProxy(Type type, IInterceptor interceptor)
        {
            return type.IsInterface ? generator.CreateInterfaceProxyWithoutTarget(type, interceptor) : generator.CreateClassProxy(type, interceptor);
        }
    }
}