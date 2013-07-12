using NSubstitute;
using White.Core.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.Repository.UnitTests
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