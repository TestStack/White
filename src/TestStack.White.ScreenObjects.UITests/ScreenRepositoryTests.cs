using NUnit.Framework;
using TestStack.White.Factory;

namespace TestStack.White.ScreenObjects.UITests
{
    [TestFixture]
    [Ignore("Not sure how this is supposed to work")]
    public class ScreenRepositoryTests
    {
        readonly ScreenRepositoryTester screenRepositoryTester;

        public ScreenRepositoryTests()
        {
            screenRepositoryTester = new ScreenRepositoryTester();
        }

        [Test]
        public void TestGetForCachedModeTest()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.Get();
        }

        [Test]
        public void ControlsWithSameNameAreResolvedUsingIndexTest()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.ControlsWithSameNameAreResolvedUsingIndex();
        }

        [Test]
        public void ComponentsAreInjectedTest()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.ComponentsAreInjected();
        }

        public void Dispose()
        {
            screenRepositoryTester.Dispose();
        }
    }
}