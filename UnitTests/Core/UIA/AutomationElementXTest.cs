using NUnit.Framework;
using White.Core.Testing;
using White.Core.UIItems;

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