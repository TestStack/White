using NUnit.Framework;
using Rhino.Mocks;
using White.Core;
using White.Core.Factory;
using White.Core.Sessions;

namespace White.Repository.UITests
{
    [TestFixture]
    public class ScreenRepositoryCacheTest
    {
        [Test]
        public void ScreensShouldBeCached()
        {
            var mocks = new MockRepository();
            var mockApplication = mocks.StrictMock<Application>();
            var window = mocks.StrictMock<DummyWindow>();
            SetupResult.For(window.IsClosed).Return(false);
            Expect.Call(mockApplication.GetWindow("dummy", InitializeOption.NoCache)).Return(window).IgnoreArguments();
            var applicationSession = mocks.StrictMock<ApplicationSession>();
            SetupResult.For(applicationSession.Application).Return(mockApplication);
            mocks.ReplayAll();

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.AreSame(GetScreen(screenRepository), GetScreen(screenRepository));

            mocks.VerifyAll();
        }

        [Test]
        public void ScreenShouldRemovedFromCacheWhenClosed()
        {
            var mocks = new MockRepository();
            var mockApplication = mocks.StrictMock<Application>();
            var window = mocks.StrictMock<DummyWindow>();
            Expect.Call(window.Title).Return("dummy");
            SetupResult.For(window.IsClosed).Return(false);
            window.Close();
            Expect.Call(mockApplication.GetWindow("dummy", InitializeOption.NoCache)).Return(window).IgnoreArguments().Repeat.Twice();
            var applicationSession = mocks.StrictMock<ApplicationSession>();
            SetupResult.For(applicationSession.Application).Return(mockApplication);
            mocks.ReplayAll();

            var screenRepository = new ScreenRepository(applicationSession);
            DummyScreen screen = GetScreen(screenRepository);
            Assert.AreSame(screen, GetScreen(screenRepository));
            screen.Close();
            GetScreen(screenRepository);
            mocks.VerifyAll();
        }

        [Test]
        public void ScreenCachingWithMatches()
        {
            var mocks = new MockRepository();
            var mockApplication = mocks.StrictMock<Application>();
            var window = mocks.StrictMock<DummyWindow>();
            SetupResult.For(window.Title).Return("whatever");
            SetupResult.For(window.IsClosed).Return(false);
            Expect.Call(mockApplication.Find(t => true, InitializeOption.NoCache)).Return(window).IgnoreArguments();
            var applicationSession = mocks.StrictMock<ApplicationSession>();
            SetupResult.For(applicationSession.Application).Return(mockApplication);
            mocks.ReplayAll();

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.AreSame(FindScreen(screenRepository), FindScreen(screenRepository));

            mocks.VerifyAll();
        }

        private static DummyScreen FindScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>(t => true, InitializeOption.NoCache);
        }

        private static DummyScreen GetScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>("dummy", InitializeOption.NoCache);
        }
    }
}