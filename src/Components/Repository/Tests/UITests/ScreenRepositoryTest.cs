using White.Core.Factory;
using White.Core.UIItems.WindowItems;
using NUnit.Framework;

namespace White.Repository.UITests
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

    public class DummyScreen : AppScreen
    {
        public DummyScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}