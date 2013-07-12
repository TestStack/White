using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestStack.White.Bricks
{
    /// <summary>
    /// This class builds an object to invoke a late-bound method, without using MethodInfo.InvokeAction and thus avoiding exceptions being wrapped 
    /// as target invocation exceptions.
    /// </summary>
    internal static class DelegateInvoker
    {
        static T Get<T>(object o)
        {
            if (o == null)
                return default(T);

            return (T)o;
        }

        internal interface IActionInvokerWrapper
        {
            object Call(object[] args);
        }

        public static IActionInvokerWrapper CreateInvoker(object target, MethodInfo method)
        {
            if (method.ReturnType == typeof (void))
                return CreateReturnVoidInvoker(target, method);
            var parameterTypes = new List<Type>();
            parameterTypes.AddRange(method.GetParameters().Select(x => x.ParameterType));
            parameterTypes.Add(method.ReturnType);

            var invokerType = invokerTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
            if (invokerType == null)
                throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

            invokerType = invokerType.MakeGenericType(parameterTypes.ToArray());

            var invokerWrapperType = invokerWrapperTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
            if (invokerWrapperType == null)
                throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

            invokerWrapperType = invokerWrapperType.MakeGenericType(parameterTypes.ToArray());

            var invoker = Delegate.CreateDelegate(invokerType, target, method);
            var wrapper = Activator.CreateInstance(invokerWrapperType, invoker);
            return (IActionInvokerWrapper)wrapper;
        }

        private static IActionInvokerWrapper CreateReturnVoidInvoker(object target, MethodInfo method)
        {
            var parameterTypes = new List<Type>();
            parameterTypes.AddRange(method.GetParameters().Select(x => x.ParameterType));

            var invokerType = voidInvokerTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
            if (invokerType == null)
                throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

            if (parameterTypes.Count > 0)
                invokerType = invokerType.MakeGenericType(parameterTypes.ToArray());

            var invokerWrapperType = voidInvokerWrapperTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
            if (invokerWrapperType == null)
                throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

            if (parameterTypes.Count > 0)
                invokerWrapperType = invokerWrapperType.MakeGenericType(parameterTypes.ToArray());

            var invoker = Delegate.CreateDelegate(invokerType, target, method);
            var wrapper = Activator.CreateInstance(invokerWrapperType, invoker);
            return (IActionInvokerWrapper)wrapper;
        }

        #region Generated
        // ReSharper disable TypeParameterCanBeVariant
        private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
        private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
        private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2);
        private delegate TReturn ActionInvoker<TArg0, TArg1, TReturn>(TArg0 arg0, TArg1 arg1);
        private delegate TReturn ActionInvoker<TArg0, TReturn>(TArg0 arg0);
        private delegate TReturn ActionInvoker<TReturn>();
        private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
        private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
        private delegate void VoidActionInvoker<TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2);
        private delegate void VoidActionInvoker<TArg0, TArg1>(TArg0 arg0, TArg1 arg1);
        private delegate void VoidActionInvoker<TArg0>(TArg0 arg0);
        private delegate void VoidActionInvoker();
        // ReSharper restore TypeParameterCanBeVariant

        private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TReturn> : IActionInvokerWrapper
        {
            private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn> invoker;

            public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                var arg2 = Get<TArg2>(args[2]);
                var arg3 = Get<TArg3>(args[3]);
                var result = invoker(arg0, arg1, arg2, arg3);
                return result;
            }
        }

        private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TReturn> : IActionInvokerWrapper
        {
            private readonly ActionInvoker<TArg0, TArg1, TArg2, TReturn> invoker;

            public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TReturn> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                var arg2 = Get<TArg2>(args[2]);
                var result = invoker(arg0, arg1, arg2);
                return result;
            }
        }

        private class ActionInvokerWrapper<TArg0, TArg1, TReturn> : IActionInvokerWrapper
        {
            private readonly ActionInvoker<TArg0, TArg1, TReturn> invoker;

            public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TReturn> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                var result = invoker(arg0, arg1);
                return result;
            }
        }

        private class ActionInvokerWrapper<TArg0, TReturn> : IActionInvokerWrapper
        {
            private readonly ActionInvoker<TArg0, TReturn> invoker;

            public ActionInvokerWrapper(ActionInvoker<TArg0, TReturn> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var result = invoker(arg0);
                return result;
            }
        }

        private class ActionInvokerWrapper<TReturn> : IActionInvokerWrapper
        {
            private readonly ActionInvoker<TReturn> invoker;

            public ActionInvokerWrapper(ActionInvoker<TReturn> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var result = invoker();
                return result;
            }
        }

        private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3> : IActionInvokerWrapper
        {
            private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3> invoker;

            public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                var arg2 = Get<TArg2>(args[2]);
                var arg3 = Get<TArg3>(args[3]);
                invoker(arg0, arg1, arg2, arg3);
                return null;
            }
        }

        private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2> : IActionInvokerWrapper
        {
            private readonly VoidActionInvoker<TArg0, TArg1, TArg2> invoker;

            public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                var arg2 = Get<TArg2>(args[2]);
                invoker(arg0, arg1, arg2);
                return null;
            }
        }

        private class VoidActionInvokerWrapper<TArg0, TArg1> : IActionInvokerWrapper
        {
            private readonly VoidActionInvoker<TArg0, TArg1> invoker;

            public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                var arg1 = Get<TArg1>(args[1]);
                invoker(arg0, arg1);
                return null;
            }
        }

        private class VoidActionInvokerWrapper<TArg0> : IActionInvokerWrapper
        {
            private readonly VoidActionInvoker<TArg0> invoker;

            public VoidActionInvokerWrapper(VoidActionInvoker<TArg0> invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                var arg0 = Get<TArg0>(args[0]);
                invoker(arg0);
                return null;
            }
        }

        private class VoidActionInvokerWrapper : IActionInvokerWrapper
        {
            private readonly VoidActionInvoker invoker;

            public VoidActionInvokerWrapper(VoidActionInvoker invoker)
            {
                this.invoker = invoker;
            }

            public object Call(object[] args)
            {
                invoker();
                return null;
            }
        }

        private readonly static Type[] invokerTypes = new[] {
                                                                typeof(ActionInvoker<,,,,,>),
                                                                typeof(ActionInvoker<,,,,>),
                                                                typeof(ActionInvoker<,,,>),
                                                                typeof(ActionInvoker<,,>),
                                                                typeof(ActionInvoker<,>),
                                                                typeof(ActionInvoker<>)};
        private readonly static Type[] invokerWrapperTypes = new[] {
                                                                       typeof(ActionInvokerWrapper<,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,>),
                                                                       typeof(ActionInvokerWrapper<,,>),
                                                                       typeof(ActionInvokerWrapper<,>),
                                                                       typeof(ActionInvokerWrapper<>)};

        private readonly static Type[] voidInvokerTypes = new[] {
                                                                    typeof(VoidActionInvoker<,,,,>),
                                                                    typeof(VoidActionInvoker<,,,>),
                                                                    typeof(VoidActionInvoker<,,>),
                                                                    typeof(VoidActionInvoker<,>),
                                                                    typeof(VoidActionInvoker<>),
                                                                    typeof(VoidActionInvoker)};
        private readonly static Type[] voidInvokerWrapperTypes = new[] {
                                                                           typeof(VoidActionInvokerWrapper<,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,>),
                                                                           typeof(VoidActionInvokerWrapper<,>),
                                                                           typeof(VoidActionInvokerWrapper<>),
                                                                           typeof(VoidActionInvokerWrapper)};

        #endregion
    }
}