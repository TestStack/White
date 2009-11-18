using System;

namespace White.Core.Testing
{
    public class IllegalTestException : Exception
    {
        public IllegalTestException(string message) : base(message) {}
    }
}