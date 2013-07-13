using System;

namespace TestStack.White.Utility
{
    public class DelegateDisposable : IDisposable
    {
        private readonly Action action;

        public DelegateDisposable(Action action)
        {
            this.action = action;
        }

        public virtual void Dispose()
        {
            action();
        }
    }
}