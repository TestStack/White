using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace White.Core.SystemExtensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<MethodInfo> NonVirtuals(this Type type)
        {
            var methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            return methodInfos
                .Where(methodInfo => !methodInfo.IsPrivate && methodInfo.DeclaringType == type && !methodInfo.Name.StartsWith("<") && methodInfo.Name != "Equals")
                .Where(methodInfo => !methodInfo.IsVirtual || methodInfo.IsFinal);
        }  
    }
}