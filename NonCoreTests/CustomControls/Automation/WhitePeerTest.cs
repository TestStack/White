using NUnit.Framework;
using White.Core.CustomCommands;
using White.CustomControls.Automation;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class WhitePeerTest
    {
        private CustomCommandSerializer commandSerializer;

        [SetUp]
        public void SetUp()
        {
            commandSerializer = new CustomCommandSerializer();
        }

        [Test]
        public void ReturnAssemblyCommandWhenCommandAssemblyIsNotFound()
        {
            string serializedCommand = commandSerializer.Serialize("Foo.dll", "Bar", "Baz", new object[0]);

            WhitePeer whitePeer = WhitePeer.Create(new TestAutomationPeer(), new TestControl());
            whitePeer.SetValue(serializedCommand);
            object[] response = commandSerializer.ToObject(whitePeer.Value, typeof(void));
            Assert.AreEqual(2, response.Length);
            response = commandSerializer.ToObject(whitePeer.Value, typeof(void));
            Assert.AreEqual(2, response.Length);
        }
    }
}