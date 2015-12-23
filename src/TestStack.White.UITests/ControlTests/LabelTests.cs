using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class LabelTests : WhiteUITestBase
    {
        public LabelTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void TextTest()
        {
            var label = MainWindow.Get<Label>("DateTimePickerLabel");
            Assert.That(label.Text, Is.Not.Null);
        }

        [Test]
        public void FindTextBlockTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var label = MainWindow.Get<Label>("PasswordTextBlock");
            Assert.That(label, Is.Not.Null);
        }
    }
}