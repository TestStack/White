using System;
using System.Runtime.Serialization;

namespace TestStack.White.Repository.EntityMapping
{
    [Serializable]
    public class EntityFieldNotFoundException : Exception
    {
        public EntityFieldNotFoundException() { }
        public EntityFieldNotFoundException(string message) : base(message) { }
        public EntityFieldNotFoundException(string message, Exception exception) : base(message, exception) { }
        protected EntityFieldNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}