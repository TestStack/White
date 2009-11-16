using System.Reflection;
using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace White.Core.UnitTests.Repository
{
    [TestFixture]
    public class RepositoryProjectTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(Assembly.GetExecutingAssembly());
        }
    }
}