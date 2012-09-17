using NUnit.Framework;
using White.Core.CustomCommands;

namespace White.Core.UnitTests.CustomCommands
{
    [TestFixture]
    public class CustomCommandSerializerTest
    {
        private CustomCommandSerializer commandSerializer;

        [SetUp]
        public void SetUp()
        {
            commandSerializer = new CustomCommandSerializer();
        }

        [Test]
        public void ToXml()
        {
            var s = commandSerializer.Serialize("", "IBazCommand", "foo", new object[] { "bar", 1 });
            Assert.AreNotEqual(null, s);
            Assert.AreNotEqual(0, s.Length);
        }

        [Test]
        public void ToXmlWhenOneOfTheArgumentsIsNull()
        {
            var s = commandSerializer.Serialize("", "IBazCommand", "foo", new object[] { "bar", 1, null });
            Assert.AreNotEqual(null, s);
            Assert.AreNotEqual(0, s.Length);
        }

        [Test]
        public void SerializeAndDeserialize()
        {
            string @string = commandSerializer.Serialize("", "IBazCommand", "foo", new object[] {new[] {"bar", "1"}});
            object[] objects = commandSerializer.ToObject(@string);
            commandSerializer.ToObject((string) objects[1]);
        }
    }
}