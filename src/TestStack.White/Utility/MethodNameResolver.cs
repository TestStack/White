using System;
using System.Linq.Expressions;

namespace White.Core.Utility
{
    internal static class MethodNameResolver
    {
        public static string NameFor<T>(Expression<Action<T>> invocation)
        {
            var invoke = invocation.Body as MethodCallExpression;
            if (invoke != null)
                return invoke.Method.Name;

            return null;
        }
    }
}