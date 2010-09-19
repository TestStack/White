using System;

namespace Repository
{
    public interface ScreenRepositoryListener
    {
        void NewScreen(Type screenType, string title);
        void MessageBox(string title);
        void Disposing();
        void ScreenChanged();
    }

    public class NullScreenRepositoryListener : ScreenRepositoryListener
    {
        public virtual void NewScreen(Type screenType, string title) {}

        public virtual void MessageBox(string title) { }

        public virtual void Disposing() { }

        public virtual void ScreenChanged() {}
    }
}