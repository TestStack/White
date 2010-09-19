using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace White.CustomCommands.UnitTests
{
    [TestFixture]
    public class CustomCommandsCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof(IButtonCommands).Assembly);
        }
    }
}