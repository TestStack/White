using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests.Splitters
{
    public class HorizontalThumbTest : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            var window = OpenHorizontalSliderWindow();
            using (new DelegateDisposable(() => CloseSliderWindow(window)))
            {
                RunTest(()=>Find(window));
                RunTest(()=>Slide(window));
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
            double originalX = thumb.Location.X;
            thumb.SlideHorizontally(50);
            Assert.AreEqual(originalX + 50, thumb.Location.X);
        }
        
        private void CloseSliderWindow(Window window)
        {
            window.Close();
        }

        private Window OpenHorizontalSliderWindow()
        {
            MainWindow.Get<Button>("OpenHorizontalSplitterButton").Click();
            return MainWindow.ModalWindow("HorizontalGridSplitter");
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            // yield return FrameworkId.Silverlight; Has some timing issues
        }
    }
}