using System;

namespace TestStack.White.ScreenObjects.ScreenFlow
{
    public class ScreenIdentity
    {
        private readonly Type type;
        private string title;

        public ScreenIdentity(Type type, string title)
        {
            this.type = type;
            this.title = title;
        }

        public virtual Type Type
        {
            get { return type; }
        }
    }
}