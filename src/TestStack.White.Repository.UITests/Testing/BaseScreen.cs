using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.Repository.UITests.Testing
{
    public class BaseScreen : AppScreen
    {
        protected Button buton = null;

        public BaseScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }
    }
}
