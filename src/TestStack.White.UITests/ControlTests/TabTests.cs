using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TabTests : WhiteUITestBase
    {
        private Tab tab;

        public TabTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            tab = MainWindow.Get<Tab>("ControlsTab");
        }

        [Test]
        public void FindTest()
        {
            Assert.That(tab, Is.Not.Null);
        }

        [Test]
        public void AssertChildrenCountTest()
        {
            Assert.That(tab.TabCount, Is.EqualTo(Framework == WindowsFramework.Wpf ? 4 : 5));
        }

        [Test]
        public void ShouldSelectTabPageTest()
        {
            tab.SelectTabPage(0);
            Assert.That(tab.SelectedTab.Name, Is.EqualTo("List Controls"));
            tab.SelectTabPage(1);
            Assert.That(tab.SelectedTab.Name, Is.EqualTo("Input Controls"));
        }

        [Test]
        public void ShouldSelectTabPageWithNameTest()
        {
            tab.SelectTabPage("List Controls");
            Assert.That(tab.SelectedTab.Name, Is.EqualTo("List Controls"));
            tab.SelectTabPage("Input Controls");
            Assert.That(tab.SelectedTab.Name, Is.EqualTo("Input Controls"));
        }

        [Test]
        public void TabWithReverseDisplayOrderTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            MainWindow.Get<Button>("ReverseTabOrderButton").Click();
            var controlsTab = MainWindow.Get<Tab>("ControlsTab");
            controlsTab.SelectTabPage(2);
            Assert.That(controlsTab.SelectedTab.Name, Is.EqualTo("Other Controls"));
            controlsTab.SelectTabPage(1);
            Assert.That(controlsTab.SelectedTab.Name, Is.EqualTo("Input Controls"));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void FindControlsInsideTabTest()
        {
            tab.SelectTabPage(1);
            var selectedTab = tab.SelectedTab;
            Assert.That(selectedTab, Is.Not.Null);
            Assert.That(selectedTab.Get<TextBox>("TextBox"), Is.Not.Null);
        }
    }
}