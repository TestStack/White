using White.Core.UIItems.WindowItems;

namespace White.Repository
{
    public class RepositoryComponent
    {
        protected readonly Window window;
        protected readonly ScreenRepository screenRepository;

        protected RepositoryComponent() {}

        public RepositoryComponent(Window window, ScreenRepository screenRepository)
        {
            this.window = window;
            this.screenRepository = screenRepository;
        }
    }
}