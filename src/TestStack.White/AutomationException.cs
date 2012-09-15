using System;

namespace White.Core
{
    public class AutomationException : Exception
    {
        public AutomationException(string message) : base(message) {}
    }
}