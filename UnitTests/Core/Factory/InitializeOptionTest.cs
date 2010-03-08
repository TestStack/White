using System.IO;
using NUnit.Framework;
using White.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace White.UnitTests.Core.Factory
{
    [TestFixture, WinFormCategory]
    public class InitializeOptionTest
    {
        [Test]
        public void IdentifiedByCreatesAFile()
        {
            File.Delete("foo.xml");
            Application application = Application.Launch(TestConfiguration.WinFormsTestAppLocation);
            try
            {
                Window window = application.GetWindow("Form1", InitializeOption.NoCache.AndIdentifiedBy("Foo"));
                window.Get<Button>("buton").Click();
            }
            finally
            {
                application.Kill();
                application.ApplicationSession.Save();
            }
            Assert.AreEqual(true, File.Exists("foo.xml"));
        }
    }
}