using NUnit.Framework;
using White.WPFCustomControls.Automation;

namespace White.NonCoreTests.CustomControls
{
    [TestFixture]
    public class AssemblyBasedFactoryTest
    {
        private AssemblyBasedFactory assemblyBasedFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            assemblyBasedFactory = new AssemblyBasedFactory("White.NonCoreTests.dll");
        }

        [Test]
        public void Create()
        {
            object o = assemblyBasedFactory.Create(typeof(AssemblyBasedFactoryTest).FullName);
            Assert.AreNotEqual(null, o);
        }

        [Test]
        public void CreateWithArguments()
        {
            object o = assemblyBasedFactory.Create(typeof (ForAssemblyBasedFactoryTest).FullName, "bar");
            Assert.AreNotEqual(null, o);
        }
    }

    public class ForAssemblyBasedFactoryTest
    {
        private readonly string foo;

        public ForAssemblyBasedFactoryTest(string foo)
        {
            this.foo = foo;
        }
    }
}