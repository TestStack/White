using System;
using NUnit.Framework;
using White.CustomControls.Automation;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class ObjectCopierTest
    {
        [Test]
        public void Copy()
        {
            var o = new ObjectForObjectCopierTest(1, "foo");
            var copy = (ObjectForObjectCopierTest) ObjectCopier.Copy(o, typeof (ObjectForObjectCopierTest));
            Assert.AreNotSame(o, copy);
            Assert.AreEqual(o.X, copy.X);
            Assert.AreEqual(o.Y, copy.Y);
        }

        [Test, ExpectedException(typeof(MissingMethodException))]
        public void CannotCopyNoArgConstructorClasses()
        {
            var o = new ObjectWithoutNoArgConstructor("foo");
            ObjectCopier.Copy(o, typeof (ObjectWithoutNoArgConstructor));
        }

        [Test]
        public void CopyPrimitives()
        {
            const string s = "s";
            object copy = ObjectCopier.Copy(s, typeof(string));
            Assert.AreSame(s, copy);

            const int i = 1;
            copy = ObjectCopier.Copy(i, typeof(int));
            Assert.AreNotSame(i, copy);
            Assert.AreEqual(i, copy);
        }

        [Test]
        public void CopyEnum()
        {
            const CustomEnum customEnum = CustomEnum.Foo;
            object copy = ObjectCopier.Copy(customEnum, typeof(CustomEnum));
            Assert.AreNotSame(customEnum, copy);
            Assert.AreEqual(customEnum, copy);
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