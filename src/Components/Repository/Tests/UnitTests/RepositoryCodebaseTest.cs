using System.Linq;
using NUnit.Framework;
using White.Core.SystemExtensions;

namespace White.Repository.UnitTests
{
    [TestFixture]
    public class RepositoryCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof (ScreenRepository).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.FullName.Contains("InvokerWrapper") && !t.FullName.Contains("AnonymousType"))
                .Select(t => new
                {
                    Type = t,
                    NonVirtualMethods = t.NonVirtuals()
                })
                .SelectMany(r => r.NonVirtualMethods.Select(m => r.Type.Name + "." + m.Name))
                .ToArray();

            Assert.IsEmpty(virtuals, "The following methods are not marked virtual: \r\n" +
                string.Join("\r\n", virtuals));
        }
    }
}