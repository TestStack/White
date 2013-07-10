using System;
using System.Linq;
using White.Core.SystemExtensions;
using Xunit;

namespace White.WebBrowser.UITests
{
    public class WebBrowserCodebaseTest
    {
        [Fact]
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