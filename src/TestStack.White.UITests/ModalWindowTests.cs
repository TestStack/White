using NUnit.Framework;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ModalWindowTests : WhiteUITestBase
    {
        public ModalWindowTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void GetModalWindowTest()
        {
            LaunchModalWindow();
            var modalWindow = MainWindow.ModalWindow("GetMultiple");
            Assert.That(modalWindow, Is.Not.Null);
            modalWindow.Close();
        }

        [Test]
        public void GetModalWindowBasedOnSearchCriteriaTest()
        {
            LaunchModalWindow();
            var modalWindow = MainWindow.ModalWindow(SearchCriteria.ByText("GetMultiple"));
            Assert.That(modalWindow, Is.Not.Null);
            modalWindow.Close();
        }

        [Test]
        public void GetControlFromModalWindowWhenSessionActiveTest()
        {
            LaunchModalWindow();
            var modalWindow = MainWindow.ModalWindow("GetMultiple", InitializeOption.NoCache.AndIdentifiedBy("ModalForm"));
            Assert.That(modalWindow, Is.Not.Null);
            modalWindow.Close();
        }

        [Test]
        public void ThrowsWhenNotFoundTest()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(s => s.FindWindowTimeout = 1000))
            {
                Assert.That(() => { MainWindow.ModalWindow("foo"); },
                   Throws.TypeOf<AutomationException>().With.Message.EqualTo("Could not find modal window with title: foo"));
            }
        }

        private void LaunchModalWindow()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
        }
    }
}