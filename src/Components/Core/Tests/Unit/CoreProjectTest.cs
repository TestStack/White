using System;
using System.Reflection;
using Bricks.RuntimeFramework;
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
            AssemblyTest.AllMethodsVirtual(typeof(UIItem).Assembly);
        }

        [Test]
        public void AllUIItemsHaveDefaultConstructor()
        {
            var collection = new BricksCollection<Class>();
            AllSubsclassesHaveEmptyConstructor(collection, typeof (UIItem));
            AllSubsclassesHaveEmptyConstructor(collection, typeof (SearchCondition));
            AllSubsclassesHaveEmptyConstructor(collection, typeof (SearchCriteria));
            AllSubsclassesHaveEmptyConstructor(collection, typeof (AutomationElementProperty));
        }

        private void AllSubsclassesHaveEmptyConstructor(BricksCollection<Class> collection, Type type)
        {
            var @class = new Class(type);
            Classes classes = @class.SubClassesInAssembly();
            foreach (Class subClass in classes)
            {
                bool hasDefaultConstructor = false;
                subClass.EachConstructor(delegate(ConstructorInfo constructorInfo)
                                             {
                                                 if (constructorInfo.GetParameters().Length == 0 || subClass.Name.Equals(typeof(ToggleableItem).Name))
                                                     hasDefaultConstructor = true;
                                             });
                if (!hasDefaultConstructor &&  subClass.ClassType.IsVisible && !subClass.Name.Equals("Desktop")) collection.Add(subClass);
            }

            Assert.AreEqual(0, collection.Count, collection.ToString());
        }
    }
}