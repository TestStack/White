using NUnit.Framework;
using White.Core.CustomCommands;

namespace White.Core.UnitTests.CustomCommands
{
    [TestFixture]
    public class CustomCommandResponseTest
    {
        [Test]
        public void IsAssemblyNotFoundResponse()
        {
            Assert.AreEqual(true, new CustomCommandResponse(new object[2] {null, null}).IsAssemblyNotFound);
            Assert.AreEqual(false, new CustomCommandResponse(new object[2] {"foo", null}).IsAssemblyNotFound);
        }

        [Test]
        public void IsException()
        {
            Assert.AreEqual(true, new CustomCommandResponse(new object[2] {"foo", null}).IsException);
            Assert.AreEqual(false, new CustomCommandResponse(new object[2] {null, null}).IsException);
        }

        [Test]
        public void IsValidResponse()
        {
            var response = new CustomCommandResponse(new object[1] {null});
            Assert.AreEqual(true, response.IsValidResponse);
        }
    }
}