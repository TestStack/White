using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests.Splitters
{
    [TestFixture]
    public class VerticalThumbTest : WhiteTestBase
    {
        protected override void RunTest(FrameworkId framework)
        {
            var window = OpenVerticalSliderWindow();
            using (new DelegateDisposable(() => CloseSliderWindow(window)))
            {
                RunTest(() => Find(window));
                RunTest(() => Slide(window));
            }
        }

        public void Find(Window window)
        {
            var thumb = window.Get<Thumb>("Splitter");
            Assert.AreNotEqual(null, thumb);
        }

        public void Slide(Window window)
        {
            var thumb = window.Get<Thumb>("Splitter");
            var originalY = thumb.Location.Y;
            thumb.SlideVertically(50);
            Assert.AreEqual(originalY + 50, thumb.Location.Y);
        }

        private void CloseSliderWindow(Window window)
        {
            window.Close();
        }

        private Window OpenVerticalSliderWindow()
        {
            MainWindow.Get<Button>("OpenVerticalSplitterButton").Click();
            return MainWindow.ModalWindow("VerticalGridSplitter");
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
        }
    }
}