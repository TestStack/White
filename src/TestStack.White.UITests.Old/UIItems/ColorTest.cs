using System.Drawing;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

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

        [Test]
        public void Backgroud()
        {
            Color color = textBox.BorderColor;
            Assert.AreEqual(100, color.R);
            Assert.AreEqual(100, color.G);
            Assert.AreEqual(100, color.B);
        }

        [Test]
        public void DisplayAsImage()
        {
            Bitmap bitmap = textBox.VisibleImage;
            Color color = bitmap.GetPixel(3, 3);
            Assert.AreEqual(Color.Blue.R, color.R);
            Assert.AreEqual(Color.Blue.G, color.G);
            Assert.AreEqual(Color.Blue.B, color.B);
        }
    }
}