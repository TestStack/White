using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using TestStack.White.Configuration;

namespace TestStack.White.Drawing
{
    internal class ScreenRectangle
    {
        private readonly Form form = new Form();

        internal ScreenRectangle(Color color, Rect rectangle)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.Left = 0;
            form.Top = 0;
            form.Width = 1;
            form.Height = 1;
            form.BackColor = color;
            form.Opacity = 0.8;
            form.Visible = false;

            // Set popup style
            var num1 = WindowsAPI.NativeWindow.GetWindowLong(form.Handle, -20);
            WindowsAPI.NativeWindow.SetWindowLong(form.Handle, -20, num1 | 0x80);

            // Set position
            WindowsAPI.NativeWindow.SetWindowPos(form.Handle, new IntPtr(-1), Convert.ToInt32(rectangle.X), Convert.ToInt32(rectangle.Y),
                Convert.ToInt32(rectangle.Width), Convert.ToInt32(rectangle.Height), 0x10);
        }

        internal virtual void Show()
        {
            WindowsAPI.NativeWindow.ShowWindow(form.Handle, 8);
        }

        internal virtual void Hide()
        {
            form.Hide();
            form.Dispose();
        }
    }

    internal class FrameRectangle
    {
        private readonly ScreenRectangle[] rectangles;
        const int Width = 3;

        internal FrameRectangle(Color color, Rect boundingRectangle)
        {
            // Using 4 rectangles to display each border
            var leftBorder = new ScreenRectangle(color, new Rect(boundingRectangle.X - Width, boundingRectangle.Y - Width, Width, boundingRectangle.Height + 2 * Width));
            var topBorder = new ScreenRectangle(color, new Rect(boundingRectangle.X, boundingRectangle.Y - Width, boundingRectangle.Width, Width));
            var rightBorder = new ScreenRectangle(color, new Rect(boundingRectangle.X + boundingRectangle.Width, boundingRectangle.Y - Width, Width, boundingRectangle.Height + 2 * Width));
            var bottomBorder = new ScreenRectangle(color, new Rect(boundingRectangle.X, boundingRectangle.Y + boundingRectangle.Height, boundingRectangle.Width, Width));
            rectangles = new[] { leftBorder, topBorder, rightBorder, bottomBorder };
        }

        internal virtual void Highlight()
        {
            rectangles.ToList().ForEach(x => x.Show());
            Thread.Sleep(CoreAppXmlConfiguration.Instance.HighlightTimeout);
            rectangles.ToList().ForEach(x => x.Hide());
        }
    }
}
