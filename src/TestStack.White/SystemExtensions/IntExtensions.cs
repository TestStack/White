using System;

namespace TestStack.White.SystemExtensions
{
    public static class IntExtensions
    {
        public static TimeSpan AsTimeSpan(this int timeSpanInMilliseconds)
        {
            return TimeSpan.FromMilliseconds(timeSpanInMilliseconds);
        }
    }
}
