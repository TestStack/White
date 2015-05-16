using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Scrolling;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class VScrollBarTest : WhiteTestBase
    {
        private ListBox listBox;
        private IVScrollBar vScrollBar;
        private double smallChange;
        private double largeChange;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            vScrollBar = listBox.ScrollBars.Vertical;
            vScrollBar.ScrollDown();
            smallChange = vScrollBar.Value;
            vScrollBar.ScrollUp();
            vScrollBar.ScrollDownLarge();
            largeChange = vScrollBar.Value;
            vScrollBar.ScrollUpLarge();
            if (vScrollBar.IsNotMinimum)
                vScrollBar.SetToMinimum();

            RunTest(ShouldGetVerticalScrollBar);
            RunTest(ShouldScrollDown);
            RunTest(ShouldScrollDownLarge);
            RunTest(ShouldScrollUp);
            RunTest(ShouldScrollUpLarge);
        }

        void ShouldGetVerticalScrollBar()
        {
            Assert.NotNull(vScrollBar);
        }

        void ShouldScrollDown()
        {
            double currentValue = vScrollBar.Value;
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            Assert.Equal(currentValue + (smallChange*5), vScrollBar.Value, 3);
        }

        void ShouldScrollDownLarge()
        {
            double currentValue = vScrollBar.Value;
            vScrollBar.ScrollDownLarge();
            vScrollBar.ScrollDownLarge();
            vScrollBar.ScrollDownLarge();
            Assert.Equal(currentValue + (largeChange*3), vScrollBar.Value, 3);
        }

        void ShouldScrollUp()
        {
            vScrollBar.SetToMaximum();
            double maxValue = vScrollBar.Value;
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            Assert.Equal(maxValue - (smallChange * 5), vScrollBar.Value, 3);
        }

        void ShouldScrollUpLarge()
        {
            var currentValue = vScrollBar.Value;
            vScrollBar.ScrollUpLarge();
            vScrollBar.ScrollUpLarge();
            vScrollBar.ScrollUpLarge();
            Assert.Equal(currentValue - (largeChange * 3), vScrollBar.Value, 3);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}
