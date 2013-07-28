using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects
{
    public class AppScreenComponent : RepositoryComponent
    {
        protected AppScreenComponent() {}
        public AppScreenComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}