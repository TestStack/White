using System;
using System.Threading;
using White.Core.UIItems.WindowItems;

namespace White.Core.Utility
{
    public static class Retry
    {
        //TODO Make this read configuration
        public static TimeSpan WindowWaitDefault = TimeSpan.FromSeconds(30);
        public static TimeSpan ElementWaitDefault = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan DefaultRetryInterval = TimeSpan.FromMilliseconds(200);

        /// <summary>
        /// Retries until method returns a non-default value using default timeout for window
        /// </summary>
        /// <param name="getMethod">The operation to perform.</param>
        public static Window ForDefault(Func<Window> getMethod)
        {
            return For(getMethod, WindowWaitDefault);
        }

        /// <summary>
        /// Retries until method returns a non-default value using default element timeout
        /// </summary>
        /// <param name="getMethod">The method.</param>
        public static T ForDefault<T>(Func<T> getMethod)
        {
            return For(getMethod, ElementWaitDefault);
        }

        /// <summary>
        /// Retries as long as predicate is satisfied using default timeout for window
        /// </summary>
        /// <param name="getMethod">The operation to perform.</param>
        /// <param name="shouldRetry">The predicate used for retry.</param>
        public static Window ForDefault(Func<Window> getMethod, Predicate<Window> shouldRetry)
        {
            return For(getMethod, shouldRetry, WindowWaitDefault);
        }

        /// <summary>
        /// Retries as long as predicate is satisfied using default element timeout
        /// </summary>
        /// <param name="getMethod">The operation to perform.</param>
        /// <param name="shouldRetry">The predicate used for retry.</param>
        public static T ForDefault<T>(Func<T> getMethod, Predicate<T> shouldRetry)
        {
            return For(getMethod, shouldRetry, ElementWaitDefault);
        }

        /// <summary>
        /// Retries until action does not throw an exception
        /// </summary>
        /// <param name="action">The operation to perform.</param>
        /// <param name="retryFor">The duration before timing outs.</param>
        public static void For(Action action, TimeSpan retryFor)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < retryFor.TotalMilliseconds)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(DefaultRetryInterval);
                }
            }

            action();
        }

        /// <summary>
        /// Retries until method returns true
        /// </summary>
        /// <param name="getMethod">The operation to perform.</param>
        /// <param name="retryFor">The duration before timing out.</param>
        /// <param name="retryInterval">The time to sleep betwen retries.</param>
        public static bool For(Func<bool> getMethod, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            return For(getMethod, g => !g, retryFor, retryInterval);
        }

        /// <summary>
        /// Retries until method returns a non-default value
        /// </summary>
        /// <param name="getMethod">The method.</param>
        /// <param name="retryFor">The duration before timing out.</param>
        /// <param name="retryInterval">The time to sleep betwen retries.</param>
        public static T For<T>(Func<T> getMethod, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            //If T is a value type, by default we should retry if the value is default
            //Reference types will return false, so our predicate will always pass
            return For(getMethod, IsValueTypeAndDefault, retryFor, retryInterval);
        }

        /// <summary>
        /// Retries as long as predicate is satisfied
        /// </summary>
        /// <param name="getMethod">The operation to perform.</param>
        /// <param name="shouldRetry">The predicate used for retry.</param>
        /// <param name="retryFor">The duration before timing out.</param>
        /// <param name="retryInterval">The time to sleep betwen retries.</param>
        public static T For<T>(Func<T> getMethod, Predicate<T> shouldRetry, TimeSpan retryFor, TimeSpan? retryInterval = null)
        {
            var startTime = DateTime.Now;
            T element;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < retryFor.TotalMilliseconds)
            {
                try
                {
                    element = getMethod();
                }
                catch (Exception)
                {
                    Thread.Sleep(retryInterval ?? DefaultRetryInterval);
                    continue;
                }

                if (!typeof(T).IsValueType && element != null && !shouldRetry(element))
                    return element;

                //Making it safe for bool and value types and reference types
                if (typeof(T) == typeof(bool) && !shouldRetry(element))
                    return element;

                if (typeof(T) != typeof(bool) &&
                    !IsReferenceTypeAndIsNull(element) &&
                    !shouldRetry(element))
                {
                    return element;
                }

                Thread.Sleep(retryInterval ?? DefaultRetryInterval);
            }

            element = getMethod();
            return element;
        }

        private static bool IsReferenceTypeAndIsNull<T>(T element)
        {
            return (!(typeof(T).IsValueType) && ReferenceEquals(element, null));
        }

        private static bool IsValueTypeAndDefault<T>(T element)
        {
            return (typeof(T).IsValueType && element.Equals(default(T)));
        }
    }
}