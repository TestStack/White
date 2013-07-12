using System.Drawing;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ColorTest : ControlsActionTest
    {
        private TextBox textBox;

        [SetUp]
        public void SetUp()
        {
            textBox = Window.Get<TextBox>("textBox");            
        }

        [Fact]
        public void Backgroud()
        {
            Color color = textBox.BorderColor;
            Assert.Equal(100, color.R);
            Assert.Equal(100, color.G);
            Assert.Equal(100, color.B);
        }

        [Fact]
        public void DisplayAsImage()
        {
            Bitmap bitmap = textBox.VisibleImage;
            Color color = bitmap.GetPixel(3, 3);
            Assert.Equal(Color.Blue.R, color.R);
            Assert.Equal(Color.Blue.G, color.G);
            Assert.Equal(Color.Blue.B, color.B);
        }
    }
}