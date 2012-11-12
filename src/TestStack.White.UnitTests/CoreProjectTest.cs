using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using White.Core.UIItems;
using NUnit.Framework;
using White.Core.UIItems.Finders;

namespace White.Core.UnitTests
{
    [TestFixture]
    public class CoreProjectTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            var virtuals = typeof (UIItem).Assembly.GetTypes()
                .Where(t => t.IsClass)
                .Select(t => new
                {
                    Type = t,
                    NonVirtualMethods = NonVirtuals(t)
                })
                .SelectMany(r => r.NonVirtualMethods.Select(m => r.Type.Name + "." + m.Name))
                .ToArray();

            Assert.IsEmpty(virtuals, "The following methods are not marked virtual: \r\n" +
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
            Assert.AreEqual(0, collection.Count, collection.ToString());
        }

        private void AllSubsclassesHaveEmptyConstructor(List<string> collection, Type type)
        {
            var types = typeof (UIItem).Assembly.GetTypes();
            var classes = types.Where(item =>
            {
                if (!item.IsClass || type == item) return false;
                return type.IsAssignableFrom(item);
            });
            foreach (var subClass in classes)
            {
                bool hasDefaultConstructor = false;
                foreach (var constructorInfo in subClass.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
                {
                    if (constructorInfo.GetParameters().Length == 0 || subClass.Name.Equals(typeof(ToggleableItem).Name))
                        hasDefaultConstructor = true;
                }
                if (!hasDefaultConstructor && subClass.IsVisible && !subClass.Name.Equals("Desktop"))
                    if (subClass.FullName != null) collection.Add(subClass.FullName);
            }
        }

        public virtual IEnumerable<MethodInfo> NonVirtuals(Type type)
        {
            var methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            return methodInfos
                .Where(methodInfo => !methodInfo.IsPrivate && methodInfo.DeclaringType == type && !methodInfo.Name.StartsWith("<"))
                .Where(methodInfo => !methodInfo.IsVirtual || methodInfo.IsFinal);
        }
    }
}