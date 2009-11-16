using System;

namespace White.Core
{
    public class WhiteException : Exception
    {
        public WhiteException(string message, Exception innerException) : base(message, innerException) {}
        public WhiteException(string message) : base(message) {}
    }
}