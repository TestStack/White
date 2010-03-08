using System;
using System.IO;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
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

        [Test, ExpectedException(typeof (ArgumentException))]
        public void DonotAcceptNonValueProviderPeers()
        {
            var button = new Button();
            WhitePeer.Create(new ButtonAutomationPeer(button), button);
        }

        [Test]
        public void ReturnAssemblyCommandWhenCommandAssemblyIsNotFound()
        {
            string serializedCommand = commandSerializer.Serialize("Foo.dll", "Bar", "Baz", new object[0]);

            WhitePeer whitePeer = WhitePeer.Create(new TestAutomationPeer(), new TestControl());
            whitePeer.SetValue(serializedCommand);
            object[] response = commandSerializer.ToObject(whitePeer.Value);
            Assert.AreEqual(2, response.Length);
            response = commandSerializer.ToObject(whitePeer.Value);
            Assert.AreEqual(2, response.Length);
        }

        [Test]
        public void ExceptionThrownInSetValueIsReturnedWhenGetValueIsCalled()
        {
            WhitePeer whitePeer = WhitePeer.Create(new TestAutomationPeer(), new TestControl());
            whitePeer.SetValue(commandSerializer.SerializeAssembly(typeof(IExceptionCommand).Assembly.Location));
            
            string serializedCommand = commandSerializer.Serialize(new FileInfo(typeof(IExceptionCommand).Assembly.Location).Name, typeof(IExceptionCommand).FullName, "ThrowException", new object[0]);
            whitePeer.SetValue(serializedCommand);
            var response = commandSerializer.ToObject(whitePeer.Value);
            Assert.IsInstanceOfType(typeof(Exception), response[0]);
            response = commandSerializer.ToObject(whitePeer.Value);
            Assert.IsInstanceOfType(typeof(Exception), response[0]);
        }
    }

    public interface IExceptionCommand
    {
        void ThrowException();
    }

    public class ExceptionCommand : IExceptionCommand
    {
        public void ThrowException()
        {
            throw new NotImplementedException();
        }
    }
}