using System.Linq;
using NUnit.Framework;
using Reporting.Domain;
using White.Core.SystemExtensions;

namespace White.Reporting.UnitTests
{
    [TestFixture]
    public class ReportingCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof(IReport).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.FullName.Contains("InvokerWrapper") && !t.FullName.Contains("AnonymousType"))
                .Select(t => new
                {
                    Type = t,
                    NonVirtualMethods = t.NonVirtuals()
                })
                .SelectMany(r => r.NonVirtualMethods.Select(m => r.Type.FullName + "." + m.Name))
                .ToArray();

            Assert.IsEmpty(virtuals, "The following methods are not marked virtual: \r\n" +
                string.Join("\r\n", virtuals));
        }
    }
}