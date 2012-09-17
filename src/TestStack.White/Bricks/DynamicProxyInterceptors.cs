using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using White.Core.Interceptors;

namespace White.Core.Bricks
{
    public class DynamicProxyInterceptors : List<IWhiteInterceptor>
    {
        public virtual void Process(IInvocation invocation)
        {
            ForEach(obj => obj.PreProcess(invocation, null));
            invocation.Proceed();
            ForEach(obj => obj.PostProcess(invocation, null));
        }

        public virtual void Process(IInvocation invocation, CoreInterceptContext interceptedContext)
        {
            ForEach(obj => obj.PreProcess(invocation, interceptedContext));
            invocation.ReturnValue = invocation.Method.Invoke(interceptedContext.Target, invocation.Arguments);
            ForEach(obj => obj.PostProcess(invocation, interceptedContext));
        }

        public static string ToString(IInvocation invocation)
        {
            string message = string.Format("Error when invoking {0}, on {1} with parameters: ", invocation.Method.Name, invocation.TargetType.Name);
            return message + string.Join(",", invocation.Arguments.Select(argument => argument == null ? "null" : argument.ToString()).ToArray());
        }
    }
}