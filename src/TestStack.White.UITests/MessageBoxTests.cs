using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class MessageBoxTests : WhiteUITestBase
    {
        public MessageBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void IsClosedTest()
        {
            MainWindow.Get<Button>("OpenMessageBox").Click();
            var messageBox = MainWindow.MessageBox("Test message box");
            Assert.That(messageBox.IsClosed, Is.False);
            messageBox.Close();
            Assert.That(messageBox.IsClosed, Is.True);
        }
        [Test]
        public void CloseMessageBoxTest()
        {
            MainWindow.Get<Button>("OpenMessageBox").Click();
            var messageBox = MainWindow.MessageBox("Test message box");
            var label = MainWindow.Get<Label>("65535");
            Assert.That(label.Text, Is.EqualTo("Close me"));
            messageBox.Close();
        }

        [Test]
        public void ClickButtonOnMessageBoxTest()
        {
            MainWindow.Get<Button>("OpenMessageBox").Click();
            var messageBox = MainWindow.MessageBox("Test message box");
            messageBox.Get<Button>(SearchCriteria.ByAutomationId("2")).Click();
        }

        [Test]
        public void ThrowsWhenNotFoundTest()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.FindWindowTimeout = 500))
            {
                Assert.That(() => { MainWindow.MessageBox("foo"); },
                   Throws.TypeOf<AutomationException>().With.Message.EqualTo("Could not find modal window with title: foo"));
            }
        }
    }
}