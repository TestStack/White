using NUnit.Framework;
using White.CustomControls.Peers.Automation;
using CustomCommandSerializer=White.Core.CustomCommands.CustomCommandSerializer;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class CustomCommandDeserializerTest
    {
        [Test]
        public void Deserialize()
        {
            var s = new CustomCommandSerializer().Serialize("White.NonCoreTests.CustomCommands.dll", "IBazCommand", "Foo", new object[] {"bar", 1});
            ICommand customCommand;
            bool result = new CommandSerializer(new CommandAssemblies()).TryDeserializeCommand(s, out customCommand);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void DeserializeInvalidString()
        {
            ICommand customCommand;
            bool result = new CommandSerializer(new CommandAssemblies()).TryDeserializeCommand("merylstreep", out customCommand);
            Assert.AreEqual(false, result);
            Assert.AreEqual(null, customCommand);
        }
    }
}