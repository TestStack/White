using Bricks.RuntimeFramework;
using Repository;
using NUnit.Framework;
using Rhino.Mocks;
using White.Core.UIItems.WindowItems;

namespace White.Repository.UnitTests
{
    [TestFixture]
    public class ScreenClassTest
    {
        [Test]
        public void NewScreenContainingComponent()
        {
            var mocks = new MockRepository();
            var window = mocks.StrictMock<Window>();
            var screenRepository = mocks.StrictMock<ScreenRepository>();
            mocks.ReplayAll();
            var @class = new Class(typeof(ScreenClassContainingComponent));
            new ScreenClass(@class).New(window, screenRepository);
        }
    }

    public class ScreenClassContainingComponent : AppScreen
    {
        public ScreenClassContainingComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }

    public class ScreenClassComponent : AppScreenComponent
    {
        public ScreenClassComponent(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}