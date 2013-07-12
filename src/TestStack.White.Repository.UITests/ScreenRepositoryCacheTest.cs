using NSubstitute;
using White.Core;
using White.Core.Factory;
using White.Core.Sessions;
using Xunit;

namespace TestStack.White.Repository.UITests
{
    public class ScreenRepositoryCacheTest
    {
        [Fact]
        public void ScreensShouldBeCached()
        {
            var application = Substitute.For<Application>();
            var window = Substitute.For<DummyWindow>();
            window.IsClosed.Returns(false);
            application.GetWindow("dummy", InitializeOption.NoCache).ReturnsForAnyArgs(window);
            var applicationSession = Substitute.For<ApplicationSession>();
            applicationSession.Application.Returns(application);

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.Same(GetScreen(screenRepository), GetScreen(screenRepository));
        }

        [Fact]
        public void ScreenShouldRemovedFromCacheWhenClosed()
        {
            var application = Substitute.For<Application>();
            var window = Substitute.For<DummyWindow>();
            window.Title.Returns("dummy");
            window.IsClosed.Returns(false);
            window.Close();
            application.GetWindow("dummy", InitializeOption.NoCache).ReturnsForAnyArgs(window);
            var applicationSession = Substitute.For<ApplicationSession>();
            applicationSession.Application.Returns(application);

            var screenRepository = new ScreenRepository(applicationSession);
            DummyScreen screen = GetScreen(screenRepository);
            Assert.Same(screen, GetScreen(screenRepository));
            screen.Close();
            GetScreen(screenRepository);
            application.ReceivedWithAnyArgs(2).GetWindow("dummy", InitializeOption.NoCache);
        }

        [Fact]
        public void ScreenCachingWithMatches()
        {
            var application = Substitute.For<Application>();
            var window = Substitute.For<DummyWindow>();
            window.Title.Returns("whatever");
            window.IsClosed.Returns(false);
            application.Find(t => true, InitializeOption.NoCache).ReturnsForAnyArgs(window);
            var applicationSession = Substitute.For<ApplicationSession>();
            applicationSession.Application.Returns(application);

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.Same(FindScreen(screenRepository), FindScreen(screenRepository));
        }

        private static DummyScreen FindScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>(t => true, InitializeOption.NoCache);
        }

        private static DummyScreen GetScreen(ScreenRepository screenRepository) {
            return screenRepository.Get<DummyScreen>("dummy", InitializeOption.NoCache);
        }
    }
}