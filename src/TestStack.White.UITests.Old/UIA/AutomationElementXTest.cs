using NUnit.Framework;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIA
{
    [TestFixture, WPFCategory]
    public class AutomationElementXTest : ControlsActionTest
    {
        [Test]
        public void TestToString()
        {
            var button = Window.Get<Button>("buton");
            string s = button.AutomationElement.Display();
            Assert.AreEqual(string.Format("AutomationId:buton, Name:Buton, ControlType:button, FrameworkId:WPF"), s);
        }
    }
}