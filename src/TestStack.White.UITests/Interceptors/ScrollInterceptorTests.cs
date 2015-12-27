using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.Interceptors
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ScrollInterceptorTests : WhiteUITestBase
    {
        public ScrollInterceptorTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void GetItemOutsideWindowButWithoutScrollTest()
        {
            using (var window = StartScenario("OpenFormWithoutScrollAndItemOutside", "FormWithoutScrollAndItemOutside"))
            {
                var listBox = window.Get<ListBox>("ListBox");
                Assert.That(listBox, Is.Not.Null);
                Assert.That(listBox.Items, Has.Count.EqualTo(0));
            }
        }
    }
}