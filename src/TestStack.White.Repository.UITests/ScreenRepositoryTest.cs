using TestStack.White.Factory;
using Xunit;

namespace TestStack.White.Repository.UITests
{
    public class ScreenRepositoryTest
    {
        readonly ScreenRepositoryTester screenRepositoryTester;

        public ScreenRepositoryTest()
        {
            screenRepositoryTester = new ScreenRepositoryTester();
        }

        [Fact]
        public void TestGetForCachedMode()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.Get();
        }

        [Fact]
        public void ControlsWithSameNameAreResolvedUsingIndex()
        {
            screenRepositoryTester.SetUp(InitializeOption.NoCache);
            screenRepositoryTester.ControlsWithSameNameAreResolvedUsingIndex();
        }

        [Fact]
        public void ComponentsAreInjected()
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