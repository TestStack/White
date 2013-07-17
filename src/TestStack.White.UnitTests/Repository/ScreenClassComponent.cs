using TestStack.White.Repository;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UnitTests.Repository
{
    public class ScreenClassComponent : AppScreenComponent
    {
        public ScreenClassComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}