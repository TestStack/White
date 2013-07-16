using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests.Infrastructure
{
    public abstract class TestConfiguration
    {
        public abstract Application LaunchApplication();
        public abstract Window GetMainWindow(Application application);
    }
}