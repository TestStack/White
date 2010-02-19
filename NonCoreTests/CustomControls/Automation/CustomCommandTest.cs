using System.Collections.Generic;
using NUnit.Framework;
using White.CustomControls.Automation;

namespace White.NonCoreTests.CustomControls.Automation
{
    [TestFixture]
    public class CustomCommandTest
    {
        [Test]
        public void GetImplementedTypeName()
        {
            var customCommand = new CustomCommand(null, new List<object> {"White.NonCoreTests.CustomControls.Automation.IBar", null, null });
            Assert.AreEqual("White.NonCoreTests.CustomControls.Automation.Bar", customCommand.GetImplementedTypeName());
        }

        [Test]
        public void GetArguments()
        {
            var customCommand = new CustomCommand(null, new List<object> { "White.NonCoreTests.CustomControls.Automation.IBar", "FooMethod", new object[] { new ArgumentForCustomCommand(1), 1, null } });
            object[] arguments = customCommand.GetArguments(new AssemblyBasedFactory(typeof (CustomCommandTest).Assembly.Location));
            Assert.AreEqual(3, arguments.Length);
            var argument1 = (ArgumentForCustomCommand) arguments[0];
            Assert.AreEqual(1, argument1.X);
            Assert.AreEqual(1, arguments[1]);
            Assert.AreEqual(null, arguments[2]);
        }
    }

    public class ArgumentForCustomCommand
    {
        private int x;

        public ArgumentForCustomCommand(int x)
        {
            this.x = x;
        }

        public ArgumentForCustomCommand()
        {
        }

        public int X
        {
            get { return x; }
        }
    }
}