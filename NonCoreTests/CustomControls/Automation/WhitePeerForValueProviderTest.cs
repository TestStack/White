using System.IO;
using System.Windows.Controls;
using NUnit.Framework;
using White.Core.CustomCommands;
using White.CustomControls.Peers.Automation;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class WhitePeerForValueProviderTest
    {
        private CustomCommandSerializer commandSerializer;
        private WhitePeer whitePeer;
        private string value;

        [SetUp]
        public void SetUp()
        {
            commandSerializer = new CustomCommandSerializer();
            var testAutomationPeer = new TestAutomationPeer();
            whitePeer = WhitePeer.CreateForValueProvider(testAutomationPeer, null, () => value, s => value = s);
        }

        [Test]
        public void ReturnAssemblyNotFoundResponseWhenCommandAssemblyIsNotFound()
        {
            string serializedCommand = commandSerializer.Serialize("Foo.dll", "Bar", "Baz", new object[0]);
            whitePeer.SetValue(serializedCommand);
            object[] response = commandSerializer.ToObject(whitePeer.Value);
            Assert.AreEqual(2, response.Length);
            response = commandSerializer.ToObject(whitePeer.Value);
            Assert.AreEqual(2, response.Length);
        }

        [Test]
        public void InvokeTheMethodWhenAssemblyIsPresent()
        {
            string assemblyFile = typeof (WhitePeerForValueProviderTest).Assembly.Location;
            string sendAssemblyCommand = commandSerializer.SerializeAssembly(assemblyFile);
            whitePeer.SetValue(sendAssemblyCommand);

            string serializedCommand = commandSerializer.Serialize(new FileInfo(assemblyFile).Name, typeof (ITestCommand).FullName, "Perform", new object[0]);
            whitePeer.SetValue(serializedCommand);
            object[] response = commandSerializer.ToObject(whitePeer.Value);
            Assert.AreEqual(1, response.Length);
        }

        [Test]
        public void RealSetValueCall()
        {
            whitePeer.SetValue("someValue");
            Assert.AreEqual("someValue", value);
        }

        [Test]
        public void SetEmptyValue()
        {
            whitePeer.SetValue("");
            Assert.AreEqual("", value);
        }

        [Test]
        public void EndSession()
        {
            string assemblyFile = typeof(WhitePeerForValueProviderTest).Assembly.Location;
            string sendAssemblyCommand = commandSerializer.SerializeAssembly(assemblyFile);
            whitePeer.SetValue(sendAssemblyCommand);

            string serializedCommand = commandSerializer.Serialize(new FileInfo(assemblyFile).Name, typeof(ITestCommand).FullName, "Perform", new object[0]);
            whitePeer.SetValue(serializedCommand);

            serializedCommand = commandSerializer.SerializeEndSession();
            whitePeer.SetValue(serializedCommand);

            RealSetValueCall();
        }
    }

    public interface ITestCommand
    {
        void Perform();
    }

    public class TestCommand : ITestCommand
    {
        private readonly TestControl control;

        public TestCommand(TestControl control)
        {
            this.control = control;
        }

        public void Perform()
        {
        }
    }

    public class TestControl : Control
    {
    }
}