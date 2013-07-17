using TestStack.White.Repository;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Screens;

namespace TestStack.White.UITests.Infrastructure
{
    public abstract class TestConfiguration
    {
        public abstract Application LaunchApplication();
        public abstract Window GetMainWindow(Application application);
        public abstract MainScreen GetMainScreen(ScreenRepository repository);
    }
}