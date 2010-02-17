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
            var customCommand = new CustomCommand(new List<object> { null, "White.NonCoreTests.CustomControls.Automation.IBar", null, null });
            Assert.AreEqual("White.NonCoreTests.CustomControls.Automation.Bar", customCommand.GetImplementedTypeName());
        }
    }
}