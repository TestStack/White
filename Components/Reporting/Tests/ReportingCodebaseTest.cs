using Bricks.RuntimeFramework;
using NUnit.Framework;
using Reporting.Domain;

namespace White.Reporting.Tests
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