using Bricks.RuntimeFramework;
using NUnit.Framework;
using Repository;

namespace White.Repository.Tests
{
    [TestFixture]
    public class RepositoryCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof (ScreenRepository).Assembly);
        }
    }
}