using System;

namespace White.Core
{
    public class WhiteAssertionException : Exception
    {
        public WhiteAssertionException(string message) : base(message) {}
        public WhiteAssertionException(string message, Exception exception) : base(message, exception) {}
        public WhiteAssertionException() {}
    }
}