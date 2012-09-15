using System;
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;
using Rhino.Mocks;
using White.CustomControls.Peers.Automation;

namespace White.CustomControls.UnitTests.Automation
{
    [TestFixture]
    public class CommandSerializerTest
    {
        private CommandSerializer commandSerializer;
        private ICommandAssemblies commandAssemblies;
        private MockRepository mocks;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            commandAssemblies = mocks.StrictMock<ICommandAssemblies>();
            commandSerializer = new CommandSerializer(commandAssemblies);
        }

        [Test]
        public void ShouldFailToDeserializeValidBase64ButInvalidDataContractSerializationString()
        {
            mocks.ReplayAll();
            ICommand command;
            var hasSucceeded = commandSerializer.TryDeserializeCommand("Durables", out command);
            Assert.IsFalse(hasSucceeded);
            Assert.IsNull(command);
        }

        [Test]
        public void ShouldFailToDeserializeInvalidBase64String()
        {
            mocks.ReplayAll();
            ICommand command;
            var hasSucceeded = commandSerializer.TryDeserializeCommand("Retail", out command);
            Assert.IsFalse(hasSucceeded);
            Assert.IsNull(command);
        }

        [Test]
        public void TryDeserializeWrongString()
        {
            mocks.ReplayAll();
            ICommand command;
            Assert.AreEqual(false, commandSerializer.TryDeserializeCommand("", out command));
            Assert.AreEqual(null, command);
        }

        [Test]
        public void TryDeserializeLoadAssemblyCommand()
        {
            mocks.ReplayAll();
            var objects = new object[] { null, new byte[0] };
            string serialized = commandSerializer.Serialize(objects, new List<Type>());
            ICommand command;
            Assert.AreEqual(true, commandSerializer.TryDeserializeCommand(serialized, out command));
            Assert.IsInstanceOf<LoadAssemblyCommand>(command);
        }

        [Test]
        public void TryDeserializeEndSessionCommand()
        {
            mocks.ReplayAll();
            string serialized = commandSerializer.Serialize(new object[0], new List<Type>());
            ICommand command;
            Assert.AreEqual(true, commandSerializer.TryDeserializeCommand(serialized, out command));
            Assert.IsInstanceOf<EndSessionCommand>(command);
        }

        [Test, ExpectedException(typeof(XmlException))]
        public void InValidCustomCommand()
        {
            var commandAssembly = mocks.StrictMock<ICommandAssembly>();
            SetupResult.For(commandAssemblies.Get(null)).Return(commandAssembly).IgnoreArguments();
            mocks.ReplayAll();

            string serialized = commandSerializer.Serialize(new object[]{"foo", ""}, new List<Type>());
            ICommand command;
            commandSerializer.TryDeserializeCommand(serialized, out command);
        }
    }
}