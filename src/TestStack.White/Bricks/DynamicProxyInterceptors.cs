// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicProxyInterceptors.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the DynamicProxyInterceptors type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.Bricks
{
    using System.Collections.Generic;
    using System.Linq;

    using Castle.DynamicProxy;

    using TestStack.White.Interceptors;

    /// <summary>
    /// The dynamic proxy interceptors.
    /// </summary>
    public sealed class DynamicProxyInterceptors : List<IWhiteInterceptor>
    {
        /// <summary>
        /// The to-string.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToString(IInvocation invocation)
        {
            string message = $"Error when invoking {invocation.Method.Name}, on {invocation.TargetType.Name} with parameters: ";
            return message + string.Join(",", invocation.Arguments.Select(argument => argument?.ToString() ?? "null").ToArray());
        }

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        public void Process(IInvocation invocation)
        {
            this.ForEach(obj => obj.PreProcess(invocation, null));
            invocation.Proceed();
            this.ForEach(obj => obj.PostProcess(invocation, null));
        }

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="invocation">
        /// The invocation.
        /// </param>
        /// <param name="interceptedContext">
        /// The intercepted context.
        /// </param>
        public void Process(IInvocation invocation, CoreInterceptContext interceptedContext)
        {
            this.ForEach(obj => obj.PreProcess(invocation, interceptedContext));
            var invokeTargetDelegate = DelegateInvoker.CreateInvoker(interceptedContext.Target, invocation.Method);
            invocation.ReturnValue = invokeTargetDelegate.Call(invocation.Arguments);
            this.ForEach(obj => obj.PostProcess(invocation, interceptedContext));
        }
    }
}