using System.Collections.Generic;
using System.Drawing;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ColorTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            RunTest(BorderColour);
            RunTest(DisplayAsImage);
        }

        void BorderColour()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            Color color = blueTextBox.BorderColor;
            Assert.Equal(100, color.R);
            Assert.Equal(100, color.G);
            Assert.Equal(100, color.B);
        }

        void DisplayAsImage()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            Bitmap bitmap = blueTextBox.VisibleImage;
            Color color = bitmap.GetPixel(3, 3);
            Assert.Equal(color.B, color.B);
            Assert.Equal(color.G, color.G);
            Assert.Equal(color.R, color.R);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}