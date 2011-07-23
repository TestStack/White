using NUnit.Framework;
using White.CustomControls.Peers.Automation;

namespace White.CustomControls.UnitTests.Automation
{
    [TestFixture]
    public class CustomCommandRequestTest
    {
        [Test]
        public void IsLoadAssemblyCommand()
        {
            var request = new CustomCommandRequest(new object[]{null, new byte[0]});
            Assert.AreEqual(true, request.IsLoadAssemblyCommand);
            Assert.AreEqual(false, request.IsEndSessionCommand);
        }

        [Test]
        public void IsEndSessionCommand()
        {
            var request = new CustomCommandRequest(new object[0]{});
            Assert.AreEqual(true, request.IsEndSessionCommand);
            Assert.AreEqual(false, request.IsLoadAssemblyCommand);
        }
    }
}