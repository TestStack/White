using White.Core;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.UITests.Infrastructure
{
    public class MainScreen
    {
        public MainScreen(Application application, Window window)
        {
            Application = application;
            Window = window;
        }

        public Application Application { get; private set; }
        public Window Window { get; private set; }
    }
}