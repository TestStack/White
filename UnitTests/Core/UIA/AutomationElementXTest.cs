using NUnit.Framework;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.Core.UIA
{
    [TestFixture, WPFCategory]
    public class AutomationElementXTest : ControlsActionTest
    {
        [Test]
        public void TestToString()
        {
            Button button = window.Get<Button>("buton");
            string s = button.AutomationElement.Display();
            Assert.AreEqual(string.Format("AutomationId:buton, Name:Buton, ControlType:button, FrameworkId:WPF"), s);
        }
    }
}