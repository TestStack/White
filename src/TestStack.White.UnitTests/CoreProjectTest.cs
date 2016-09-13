using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestStack.White.Reporting.Domain;
using TestStack.White.ScreenObjects;
using TestStack.White.SystemExtensions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests
{
    [TestFixture]
    public class CoreProjectTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof(UIItem).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Where(t => !t.FullName.Contains("InvokerWrapper") && !t.FullName.Contains("AnonymousType")
                && !t.FullName.Contains("ApplicationActivationManager"))
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

        [Test]
        public void AllMethodsAreVirtualInRepositoryCodeBase()
        {
            var virtuals = typeof(ScreenRepository).Assembly.GetTypes()
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

        [Test]
        public void AllMethodsAreVirtualInReportingCodeBase()
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

            if (virtuals.Any())
                throw new Exception("The following methods are not marked virtual: \r\n" +
                    string.Join("\r\n", virtuals));
        }

        [Test]
        public void AllUIItemsHaveDefaultConstructor()
        {
            var collection = new List<string>();
            AllSubsclassesHaveEmptyConstructor(collection, typeof(UIItem));
            AllSubsclassesHaveEmptyConstructor(collection, typeof(SearchCondition));
            AllSubsclassesHaveEmptyConstructor(collection, typeof(SearchCriteria));
            AllSubsclassesHaveEmptyConstructor(collection, typeof(AutomationElementProperty));
            if (collection.Any())
                throw new Exception(string.Join("\r\n", collection));
        }

        private void AllSubsclassesHaveEmptyConstructor(List<string> collection, Type type)
        {
            var types = typeof(UIItem).Assembly.GetTypes();
            var classes = types.Where(item =>
            {
                if (!item.IsClass || type == item) return false;
                return type.IsAssignableFrom(item);
            });
            foreach (var subClass in classes)
            {
                var hasDefaultConstructor = false;
                foreach (var constructorInfo in subClass.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                {
                    if (constructorInfo.GetParameters().Length == 0 || subClass.Name.Equals(typeof(ToggleableItem).Name))
                        hasDefaultConstructor = true;
                }
                if (!hasDefaultConstructor && subClass.IsVisible && !subClass.Name.Equals("Desktop"))
                    if (subClass.FullName != null) collection.Add(subClass.FullName);
            }
        }
    }
}