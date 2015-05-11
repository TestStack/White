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
        private WindowsFramework windowsFramework;

        private const int SmallScrollCount = 6;
        private double smallChange;
        private double SmallChange ()
        {
            double value = 0.0;
            if (windowsFramework == WindowsFramework.Wpf)
                value = smallChange;
            else if (windowsFramework == WindowsFramework.WinForms)
                if (SmallScrollCount % 2 == 0)
                {
                    value = (SmallScrollCount * 1.5) / SmallScrollCount;
                }
                else
                {
                    value = ((smallChange * SmallScrollCount) + 2) / SmallScrollCount;
                }

            return value;
        }

        private const int LargeScrollCount = 4;
        private double largeChange;
        private double LargeChange ()
        {
            double value = 0.0;
            if (windowsFramework == WindowsFramework.Wpf)
                value = largeChange;
            else if (windowsFramework == WindowsFramework.WinForms)
                if (LargeScrollCount % 2 == 0)
                {
                    value = (LargeScrollCount * 9.5) / LargeScrollCount;
                }
                else
                {
                    value = ((largeChange * LargeScrollCount) + 2) / LargeScrollCount;
                }

            return value;
        }



        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            windowsFramework = framework;
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
            for (int scrollCount = 0; scrollCount < SmallScrollCount; scrollCount++)
                vScrollBar.ScrollDown();

            Assert.Equal(currentValue + (SmallChange() * SmallScrollCount), vScrollBar.Value, 3);
        }

        void ShouldScrollDownLarge()
        {
            double currentValue = vScrollBar.Value;
            for (int scrollCount = 0; scrollCount < LargeScrollCount; scrollCount++)
                vScrollBar.ScrollDownLarge();

            Assert.Equal(currentValue + (LargeChange() * LargeScrollCount), vScrollBar.Value, 3);
        }

        void ShouldScrollUp()
        {
            vScrollBar.SetToMaximum();
            double maxValue = 0.0;

            if (windowsFramework == WindowsFramework.Wpf)   
                maxValue = vScrollBar.Value;
            else if (windowsFramework == WindowsFramework.WinForms)
                maxValue = vScrollBar.Value - 1;

            for (int scrollCount = 0; scrollCount < SmallScrollCount; scrollCount++)
                vScrollBar.ScrollUp();

            Assert.Equal(maxValue - (SmallChange() * SmallScrollCount), vScrollBar.Value, 3);
        }

        void ShouldScrollUpLarge()
        {
            var currentValue = vScrollBar.Value;

            for (int scrollCount = 0; scrollCount < LargeScrollCount; scrollCount++)
                vScrollBar.ScrollUpLarge();

            Assert.Equal(currentValue - (LargeChange() * LargeScrollCount), vScrollBar.Value, 3);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}
