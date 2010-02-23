using NUnit.Framework;
using White.Core.CustomCommands;

namespace White.UnitTests.Core.CustomCommands
{
    [TestFixture]
    public class CustomCommandSerializerTest
    {
        [Test]
        public void ToXml()
        {
            var s = new CustomCommandSerializer().Serialize("", "IBazCommand", "foo", new object[] { "bar", 1 });
            Assert.AreNotEqual(null, s);
            Assert.AreNotEqual(0, s.Length);
        }

        [Test]
        public void ToXmlWhenOneOfTheArgumentsIsNull()
        {
            var s = new CustomCommandSerializer().Serialize("", "IBazCommand", "foo", new object[] { "bar", 1, null });
            Assert.AreNotEqual(null, s);
            Assert.AreNotEqual(0, s.Length);
        }
    }
}