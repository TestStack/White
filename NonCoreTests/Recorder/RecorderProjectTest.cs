using System.Reflection;
using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace White.UnitTests.Recorder
{
    [TestFixture]
    public class RecorderProjectTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(Assembly.GetExecutingAssembly());
        }
    }
}