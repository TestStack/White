using Bricks.RuntimeFramework;
using NUnit.Framework;
using Reporting.Domain;

namespace White.Reporting.UnitTests
{
    [TestFixture]
    public class ReportingCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof(IReport).Assembly);
        }
    }
}