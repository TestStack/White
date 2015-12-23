using NSubstitute;
using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.Sessions;

namespace TestStack.White.UnitTests.Repository
{
    [TestFixture]
    public class ScreenRepositoryCacheTest
    {
        [Test]
        public void ScreensShouldBeCached()
        {
            var application = Substitute.For<Application>();
            var window = Substitute.For<DummyWindow>();
            window.IsClosed.Returns(false);
            application.GetWindow("dummy", InitializeOption.NoCache).ReturnsForAnyArgs(window);
            var applicationSession = Substitute.For<ApplicationSession>();
            applicationSession.Application.Returns(application);

            var screenRepository = new ScreenRepository(applicationSession);
            Assert.That(GetScreen(screenRepository), Is.SameAs(GetScreen(screenRepository)));
        }

        [Test]
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
            var screen = GetScreen(screenRepository);
            Assert.That(GetScreen(screenRepository), Is.SameAs(screen));
            screen.Close();
            GetScreen(screenRepository);
            application.ReceivedWithAnyArgs(2).GetWindow("dummy", InitializeOption.NoCache);
        }

        [Test]
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
            Assert.That(FindScreen(screenRepository), Is.SameAs(FindScreen(screenRepository)));
        }

        private static DummyScreen FindScreen(ScreenRepository screenRepository)
        {
            return screenRepository.Get<DummyScreen>(t => true, InitializeOption.NoCache);
        }

        private static DummyScreen GetScreen(ScreenRepository screenRepository)
        {
            return screenRepository.Get<DummyScreen>("dummy", InitializeOption.NoCache);
        }
    }
}