using System.Reflection;
using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace Reporting
{
    [TestFixture]
    public class ReportingProjectTest
    {
        [Test]
        public void All_methods_are_virtual()
        {
            AssemblyTest.AllMethodsVirtual(Assembly.GetExecutingAssembly());
        }
    }
}