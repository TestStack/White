using System.Reflection;
using Bricks.RuntimeFramework;
using White.Core.UIItems;
using NUnit.Framework;

namespace White.UnitTests.Core
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
            var @class = new Class(typeof (UIItem));
            Classes classes = @class.SubClassesInAssembly();
            foreach (Class subClass in classes)
            {
                bool hasDefaultConstructor = false;
                subClass.EachConstructor(delegate(ConstructorInfo constructorInfo)
                                             {
                                                 if (constructorInfo.GetParameters().Length == 0)
                                                     hasDefaultConstructor = true;
                                             });
                if (!hasDefaultConstructor && !subClass.Name.Equals("Desktop")) collection.Add(subClass);
            }

            Assert.AreEqual(0, collection.Count, collection.ToString());
        }
    }
}