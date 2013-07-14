using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Scrolling;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class HScrollBarTest : WhiteTestBase
    {
        private IHScrollBar hScrollBar;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("MultiLineTextBox");
            textBox.Text = "hfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdfjkdshfkjds " +
                           "fhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdf " +
                           "jkdshfkjdsfhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfh " +
                           "dsfkjhsdfjkdshfkjdsfhsdkfhsdkfh";
            hScrollBar = textBox.ScrollBars.Horizontal;
            hScrollBar.SetToMinimum();
            hScrollBar.ScrollRightLarge();
            hScrollBar.ScrollLeftLarge();

            RunTest(ShouldGetHScrollBar);
            RunTest(ShouldScrollRight);
            RunTest(ShouldScrollRightLarge);
            RunTest(ShouldScrollLeft);
        }

        void ShouldGetHScrollBar()
        {
            Assert.NotNull(hScrollBar);
        }

        void ShouldScrollRight()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRight();
            Assert.True(hScrollBar.Value > initialValue);
        }

        void ShouldScrollRightLarge()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRightLarge();
            Assert.True(hScrollBar.Value > initialValue);
        }

        void ShouldScrollLeft()
        {
            hScrollBar.ScrollRightLarge();
            double valueBeforeScrollLeft = hScrollBar.Value;
            hScrollBar.ScrollLeft();
            Assert.True(valueBeforeScrollLeft > hScrollBar.Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}