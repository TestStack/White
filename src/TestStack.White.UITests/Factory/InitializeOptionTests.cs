using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Factory
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class InitializeOptionTests : WhiteUITestBase
    {
        private string fooFilePath;

        public InitializeOptionTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            // Set the worksession path to the current assemblys directory
            var currentAssemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            CoreAppXmlConfiguration.Instance.WorkSessionLocation = new DirectoryInfo(currentAssemblyDirectory);

            fooFilePath = Path.Combine(currentAssemblyDirectory, "foo.xml");

            if (File.Exists(fooFilePath))
            {
                File.Delete(fooFilePath);
            }
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            File.Delete(fooFilePath);
        }

        [Test]
        public void IdentifiedByCreatesAFileTest()
        {
            File.Delete(fooFilePath);
            var window = Application.GetWindow("MainWindow", InitializeOption.NoCache.AndIdentifiedBy("Foo"));
            window.Get<Button>("ButtonWithTooltip").Click();
            Application.ApplicationSession.Save();
            Assert.That(File.Exists(fooFilePath), Is.True);
        }
    }
}