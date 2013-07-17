using TestStack.White.Repository;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UnitTests.Repository
{
    public class ScreenClassContainingComponent : AppScreen
    {
        public ScreenClassContainingComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}