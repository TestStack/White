using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class GroupBoxTests : WhiteUITestBase
    {
        public GroupBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void FindTest()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            Assert.That(groupBox, Is.Not.Null);
        }

        [Test]
        public void GetItemTest()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            var button = groupBox.Get<Button>("ButtonWithTooltip");
            Assert.That(button, Is.Not.Null);
        }
    }
}