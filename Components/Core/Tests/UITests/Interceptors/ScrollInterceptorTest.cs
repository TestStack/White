using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.Interceptors
{
    [TestFixture, WinFormCategory]
    public class ScrollInterceptorTest : CoreTestTemplate
    {
        protected override string CommandLineArguments
        {
            get { return "ControlOutside"; }
        }

        [Test]
        public void GetItemOutsideWindowButWithoutScroll()
        {
            using (Window window = application.GetWindow("FormWithoutScrollAndItemOutside"))
            {
                ListBox listBox = window.Get<ListBox>("listBox1");
                Assert.AreNotEqual(null, listBox);
                Assert.AreEqual(0, listBox.Items.Count);
            }
        }
    }
}