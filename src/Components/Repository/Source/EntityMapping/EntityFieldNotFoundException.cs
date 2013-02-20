using System;

namespace White.Repository.EntityMapping
{
    public class EntityFieldNotFoundException : Exception
    {
        public EntityFieldNotFoundException() {}
        public EntityFieldNotFoundException(string message) : base(message) {}
        public EntityFieldNotFoundException(string message, Exception exception) : base(message, exception) {}
    }
}