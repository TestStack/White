using Repository;
using Rhino.Mocks;
using White.Core;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;
using White.Repository.UITests;

namespace White.Repository.Tests
{
    [TestFixture]
    public class ScreenRepositoryTest
    {
        private ScreenRepositoryTester screenRepositoryTester;

        [SetUp]
        public void SetUp()
        {
            screenRepositoryTester = new ScreenRepositoryTester();
        }

        [Test]
        public void TestGetForCachedMode()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.Get();
        }

        [Test]
        public void ControlsWithSameNameAreResolvedUsingIndex()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.ControlsWithSameNameAreResolvedUsingIndex();
        }

        [Test]
        public void ComponentsAreInjected()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.ComponentsAreInjected();
        }

        [TearDown]
        public void TearDown()
        {
            screenRepositoryTester.TearDown();
        }
    }

    [TestFixture]
    public class ScreenRepositoryCacheTest
    {
        [Test]
        public void Screens_should_be_cached()
        {
            var mocks = new MockRepository();
            var mockApplication = mocks.CreateMock<Application>();
            var window = mocks.CreateMock<DummyWindow>();
            SetupResult.For(window.IsClosed).Return(false);
            Expect.Call(mockApplication.GetWindow("dummy", InitializeOption.NoCache)).Return(window).IgnoreArguments();
            var applicationSession = mocks.CreateMock<ApplicationSession>();
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
            var mockApplication = mocks.CreateMock<Application>();
            var window = mocks.CreateMock<DummyWindow>();
            Expect.Call(window.Title).Return("dummy");
            SetupResult.For(window.IsClosed).Return(false);
            window.Close();
            Expect.Call(mockApplication.GetWindow("dummy", InitializeOption.NoCache)).Return(window).IgnoreArguments().Repeat.Twice();
            var applicationSession = mocks.CreateMock<ApplicationSession>();
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
            var mockApplication = mocks.CreateMock<Application>();
            var window = mocks.CreateMock<DummyWindow>();
            SetupResult.For(window.Title).Return("whatever");
            SetupResult.For(window.IsClosed).Return(false);
            Expect.Call(mockApplication.Find(delegate { return true; }, InitializeOption.NoCache)).Return(window).IgnoreArguments();
            var applicationSession = mocks.CreateMock<ApplicationSession>();
            SetupResult.For(applicationSession.Application).Return(mockApplication);
            mocks.ReplayAll();

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.AreSame(FindScreen(screenRepository), FindScreen(screenRepository));

            mocks.VerifyAll();
        }

        private static DummyScreen FindScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>(delegate { return true; }, InitializeOption.NoCache);
        }

        private static DummyScreen GetScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>("dummy", InitializeOption.NoCache);
        }
    }

    public class DummyScreen : AppScreen
    {
        public DummyScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
        public DummyScreen() {}
    }
}