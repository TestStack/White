using NSubstitute;
using TestStack.White.Repository;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UnitTests.Repository
{
    public class ScreenClassTest
    {
        [Fact]
        public void NewScreenContainingComponent()
        {
            var window = Substitute.For<Window>();
            var screenRepository = Substitute.For<ScreenRepository>();
            new ScreenClass(typeof(ScreenClassContainingComponent)).New(window, screenRepository);
        }
    }
}