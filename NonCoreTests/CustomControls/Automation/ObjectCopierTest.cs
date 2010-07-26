using System;
using NUnit.Framework;
using Rhino.Mocks;
using White.CustomControls.Peers.Automation;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class ObjectCopierTest
    {
        private ICommandAssembly commandAssembly;

        [SetUp]
        public void SetUp()
        {
            var mocks = new MockRepository();
            commandAssembly = mocks.CreateMock<ICommandAssembly>();
            SetupResult.For(commandAssembly.GetType(typeof (ObjectForObjectCopierTest))).Return(typeof (ObjectForObjectCopierTest));
            SetupResult.For(commandAssembly.GetType(typeof(ObjectWithoutNoArgConstructor))).Return(typeof(ObjectWithoutNoArgConstructor));
            SetupResult.For(commandAssembly.GetType(typeof(CustomEnum))).Return(typeof(CustomEnum));
            SetupResult.For(commandAssembly.GetType(typeof(CustomEnum[]))).Return(typeof(CustomEnum[]));
            SetupResult.For(commandAssembly.GetType(typeof(CustomEnum[][]))).Return(typeof(CustomEnum[][]));
            mocks.ReplayAll();
        }

        [Test]
        public void Copy()
        {
            var o = new ObjectForObjectCopierTest(1, "foo");
            var copy = (ObjectForObjectCopierTest) ObjectCopier.Copy(o, commandAssembly);
            Assert.AreNotSame(o, copy);
            Assert.AreEqual(o.X, copy.X);
            Assert.AreEqual(o.Y, copy.Y);
        }

        [Test, ExpectedException(typeof(MissingMethodException))]
        public void CannotCopyNoArgConstructorClasses()
        {
            var o = new ObjectWithoutNoArgConstructor("foo");
            ObjectCopier.Copy(o, commandAssembly);
        }

        [Test]
        public void CopyPrimitives()
        {
            const string s = "s";
            object copy = ObjectCopier.Copy(s, commandAssembly);
            Assert.AreSame(s, copy);

            const int i = 1;
            copy = ObjectCopier.Copy(i, commandAssembly);
            Assert.AreNotSame(i, copy);
            Assert.AreEqual(i, copy);
        }

        [Test]
        public void CopyEnum()
        {
            const CustomEnum customEnum = CustomEnum.Foo;
            object copy = ObjectCopier.Copy(customEnum, commandAssembly);
            Assert.AreNotSame(customEnum, copy);
            Assert.AreEqual(customEnum, copy);
        }

        [Test]
        public void CopyArray()
        {
            ObjectCopier.Copy(new[] {"a"}, commandAssembly);
        }

        [Test]
        public void CopyArrayContainingArray()
        {
            ObjectCopier.Copy(new[] { new []{"a"} }, commandAssembly);
        }

        [Test]
        public void CopyArrayOfNonPrimitives()
        {
            ObjectCopier.Copy(new[] {CustomEnum.Foo}, commandAssembly);
        }

        [Test]
        public void CopyArrayContainingArrayOfNonPrimitives()
        {
            ObjectCopier.Copy(new[] { new []{CustomEnum.Foo} }, commandAssembly);
        }
    }

    public class ObjectWithoutNoArgConstructor
    {
        public ObjectWithoutNoArgConstructor(string @string)
        {
        }
    }

    public enum CustomEnum
    {
        Foo,Bar
    }

    public class ObjectForObjectCopierTest
    {
        private int x;
        private string y;

        public ObjectForObjectCopierTest()
        {
        }

        public ObjectForObjectCopierTest(int x, string y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public string Y
        {
            get { return y; }
        }
    }
}