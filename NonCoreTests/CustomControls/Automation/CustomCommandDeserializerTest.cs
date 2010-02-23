using NUnit.Framework;
using White.CustomControls.Automation;
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
            var customCommand = (CustomCommand) new CommandSerializer(new CommandAssemblies()).Deserialize(s);
            Assert.AreNotEqual(null, customCommand);
        }
    }
}