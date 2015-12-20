using NUnit.Framework;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Factory
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class InitializeOptionTests : WhiteUITestBase
    {
        public InitializeOptionTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            if (File.Exists("foo.xml"))
            {
                File.Delete("foo.xml");
            }
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            File.Delete("foo.xml");
        }

        [Test]
        public void IdentifiedByCreatesAFileTest()
        {
            File.Delete("foo.xml");
            var window = Application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("Foo"));
            window.Get<Button>("ButtonWithTooltip").Click();
            Application.ApplicationSession.Save();
            Assert.That(File.Exists("foo.xml"), Is.True);
        }
    }
}