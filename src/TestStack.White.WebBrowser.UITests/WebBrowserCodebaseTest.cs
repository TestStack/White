using NUnit.Framework;
using System;
using System.Linq;
using TestStack.White.SystemExtensions;

namespace TestStack.White.WebBrowser.UITests
{
    [TestFixture]
    public class WebBrowserCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof(Firefox).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.FullName.Contains("InvokerWrapper") && !t.FullName.Contains("AnonymousType"))
                .Select(t => new
                {
                    Type = t,
                    NonVirtualMethods = t.NonVirtuals()
                })
                .SelectMany(r => r.NonVirtualMethods.Select(m => r.Type.FullName + "." + m.Name))
                .ToArray();

            if (virtuals.Any())
                throw new Exception("The following methods are not marked virtual: \r\n" +
                string.Join("\r\n", virtuals));
        }
    }
}