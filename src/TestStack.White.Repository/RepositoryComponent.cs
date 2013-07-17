using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.Repository
{
    public class RepositoryComponent
    {
        protected readonly Window Window;
        protected readonly ScreenRepository ScreenRepository;

        protected RepositoryComponent() {}

        public RepositoryComponent(Window window, ScreenRepository screenRepository)
        {
            Window = window;
            ScreenRepository = screenRepository;
        }
    }
}