using NSubstitute;
using NUnit.Framework;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UnitTests.Repository
{
    [TestFixture]
    public class ScreenClassTest
    {
        [Test]
        public void NewScreenContainingComponent()
        {
            var window = Substitute.For<Window>();
            var screenRepository = Substitute.For<ScreenRepository>();
            new ScreenClass(typeof(ScreenClassContainingComponent)).New(window, screenRepository);
        }
    }
}