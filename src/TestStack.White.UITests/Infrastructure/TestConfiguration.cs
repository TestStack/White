namespace TestStack.White.UITests.Infrastructure
{
    public abstract class TestConfiguration
    {
        public abstract Application LaunchApplication();
        public abstract IMainWindow GetMainWindow(Application application);
    }
}