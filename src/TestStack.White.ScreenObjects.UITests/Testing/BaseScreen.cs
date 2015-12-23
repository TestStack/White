using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects.UITests.Testing
{
    public class BaseScreen : AppScreen
    {
        protected Button Button = null;

        public BaseScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }
    }
}
