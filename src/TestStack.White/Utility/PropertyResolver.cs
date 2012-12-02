using System;
using System.Linq.Expressions;

namespace White.Core.Utility
{
    internal static class PropertyResolver
    {
        public static string NameFor<T>(Expression<Func<T>> getter)
        {
            var body = getter.Body as MemberExpression;
            if (body != null)
                return body.Member.Name;

            var unaryExpression = getter.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                body = unaryExpression.Operand as MemberExpression;
                if (body != null)
                    return body.Member.Name;
            }

            throw new ArgumentException("'getter' should be a member expression");

        }
        public static string NameFor<TObj, TProp>(Expression<Func<TObj, TProp>> getter)
        {
            var body = getter.Body as MemberExpression;
            if (body != null)
                return body.Member.Name;

            var unaryExpression = getter.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                body = unaryExpression.Operand as MemberExpression;
                if (body != null)
                    return body.Member.Name;
            }

            throw new ArgumentException("'getter' should be a member expression");

        }
    }
}