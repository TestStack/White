using TestStack.White.Repository;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UnitTests.Repository
{
    public class DummyScreen : AppScreen
    {
        public DummyScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }
    }
}