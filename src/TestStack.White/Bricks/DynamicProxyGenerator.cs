using System;
using Castle.DynamicProxy;

namespace White.Core.Bricks
{
    public class DynamicProxyGenerator
    {
        private static readonly DynamicProxyGenerator ProxyGenerator = new DynamicProxyGenerator();
        private readonly ProxyGenerator generator = new ProxyGenerator();

        public static DynamicProxyGenerator Instance
        {
            get { return ProxyGenerator; }
        }

        public virtual object CreateProxy(IInterceptor interceptor, Type type)
        {
            object proxy;
            if (type.IsInterface)
                proxy = generator.CreateInterfaceProxyWithoutTarget(type, interceptor);
            else
                proxy = generator.CreateClassProxy(type, interceptor);
            return proxy;
        }
    }

}