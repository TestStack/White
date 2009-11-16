using Bricks.RuntimeFramework;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using Rhino.Mocks;

namespace Repository
{
    [TestFixture]
    public class ScreenClassTest
    {
        [Test]
        public void New_screen_containing_component()
        {
            MockRepository mocks = new MockRepository();
            Window window = mocks.CreateMock<Window>();
            ScreenRepository screenRepository = mocks.CreateMock<ScreenRepository>();
            mocks.ReplayAll();
            Class @class = new Class(typeof(ScreenClassContainingComponent));
            new ScreenClass(@class).New(window, screenRepository);
        }
    }

    public class ScreenClassContainingComponent : AppScreen
    {
        private ScreenClassComponent screenClassComponent;
        public ScreenClassContainingComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }

    public class ScreenClassComponent : AppScreenComponent
    {
        public ScreenClassComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}