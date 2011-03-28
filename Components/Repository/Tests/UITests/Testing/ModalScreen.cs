using Repository;
using White.Core.UIItems.WindowItems;

namespace White.Repository.UITests.Testing
{
    public class ModalScreen : AppScreen
    {
        protected ModalScreen() {}
        public ModalScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}