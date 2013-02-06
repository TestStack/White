using System;

namespace TestStack.White.UITests
{
    public class TestFailedException : Exception
    {
        public TestFailedException(string message) : base(message) { }

        public TestFailedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}