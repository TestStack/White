using NUnit.Framework;
using White.CustomControls.Peers.Automation;

namespace White.CustomControls.Tests.Automation
{
    [TestFixture]
    public class CustomCommandTest
    {
        [Test]
        public void GetImplementedTypeName()
        {
            var customCommand = new CustomCommand("White.NonCoreTests.CustomControls.dll",
                                                  new object[] {"White.NonCoreTests.CustomControls.Automation.IBar", "Foo", null}, new CommandAssemblies());
            Assert.AreEqual("White.NonCoreTests.CustomControls.Automation.Bar", customCommand.GetImplementedTypeName());
        }
    }
}