using System;
using System.Linq;
using White.Core.SystemExtensions;
using Xunit;

namespace TestStack.White.Repository.UnitTests
{
    public class RepositoryCodebaseTest
    {
        [Fact]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof(ScreenRepository).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.FullName.Contains("InvokerWrapper") && !t.FullName.Contains("AnonymousType"))
                .Select(t => new
                {
                    Type = t,
                    NonVirtualMethods = t.NonVirtuals()
                })
                .SelectMany(r => r.NonVirtualMethods.Select(m => r.Type.Name + "." + m.Name))
                .ToArray();

            if (virtuals.Any())
                throw new Exception("The following methods are not marked virtual: \r\n" +
                    string.Join("\r\n", virtuals));
        }
    }
}