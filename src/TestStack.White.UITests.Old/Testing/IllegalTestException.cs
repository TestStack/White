using System;

namespace White.Core.UITests.Testing
{
    public class IllegalTestException : Exception
    {
        public IllegalTestException(string message) : base(message) {}
    }
}