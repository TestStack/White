using System.Linq;
using Castle.DynamicProxy;

namespace TestStack.White.UITests.Infrastructure
{
    public class ForwardIfExistsInterceptor : IInterceptor
    {
        private readonly object target;

        public ForwardIfExistsInterceptor(object target)
        {
            this.target = target;
        }

        public void Intercept(IInvocation invocation)
        {
            var targetMethod = invocation.Method;
            var argumentTypes = invocation.Arguments.Select(a => a.GetType()).ToArray();
            var matchingTypeMethods = target.GetType().GetMethods().Where(m=>
            {
                var parameterInfos = m.GetParameters();
                
                return m.Name == targetMethod.Name && 
                    argumentTypes.Length == parameterInfos.Length &&
                    parameterInfos.Select((p, i) => new { p.ParameterType, Index = i }).All(p => p.ParameterType.IsAssignableFrom(argumentTypes[p.Index]));
            })
                .ToList();
            if (!matchingTypeMethods.Any())
            {
                return;
            }

            object result;
            if (targetMethod.IsGenericMethod)
            {
                result = matchingTypeMethods.Single(m=>m.IsGenericMethodDefinition)
                    .MakeGenericMethod(targetMethod.GetGenericArguments())
                    .Invoke(target, invocation.Arguments);
            }
            else
                result = matchingTypeMethods.Single(m => !m.IsGenericMethodDefinition).Invoke(target, invocation.Arguments);

            invocation.ReturnValue = result;
        }
    }
}