using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace TestStack.White.Drawing
{
    internal class ScreenRectangle
    {
        Form form = new Form();
        internal ScreenRectangle(Rect rectangle)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.Left = 0;
            form.Top = 0;
            form.Width = 1;
            form.Height = 1;
            form.BackColor = Color.Red;
            form.Opacity = 0.8;
            form.Visible = true;

            //Set popup style
            int num1 = TestStack.White.WindowsAPI.NativeWindow.GetWindowLong(form.Handle, -20);
            TestStack.White.WindowsAPI.NativeWindow.SetWindowLong(form.Handle, -20, num1 | 0x80);

            TestStack.White.WindowsAPI.NativeWindow.SetWindowPos(form.Handle, new IntPtr(-1), Convert.ToInt32(rectangle.X), Convert.ToInt32(rectangle.Y),
                Convert.ToInt32(rectangle.Width), Convert.ToInt32(rectangle.Height), 0x10);
        }
        public void Show()
        {
            TestStack.White.WindowsAPI.NativeWindow.ShowWindow(form.Handle, 8);
        }
        public void Hide()
        {
            form.Hide();
        }
    }

    internal class FrameRectangle
    {
        private ScreenRectangle leftRectangle;
        private ScreenRectangle topRectangle;
        private ScreenRectangle rightRectangle;
        private ScreenRectangle bottomRectangle;
        private ScreenRectangle[] rectangles;
        private int width = 3;

        public FrameRectangle(Rect boundingRectangle)
        {
            leftRectangle = new ScreenRectangle(new Rect(boundingRectangle.X - width, boundingRectangle.Y - width, width, boundingRectangle.Height + 2*width));
            topRectangle = new ScreenRectangle(new Rect(boundingRectangle.X, boundingRectangle.Y - width, boundingRectangle.Width, width));
            rightRectangle = new ScreenRectangle(new Rect(boundingRectangle.X + boundingRectangle.Width, boundingRectangle.Y - width, width, boundingRectangle.Height + 2*width));
            bottomRectangle = new ScreenRectangle(new Rect(boundingRectangle.X, boundingRectangle.Y + boundingRectangle.Height, boundingRectangle.Width, width));
            rectangles = new ScreenRectangle[] { leftRectangle, topRectangle, rightRectangle, bottomRectangle };
        }
        public void Highlight()
        {
            rectangles.ToList().ForEach(x => x.Show());
            Thread.Sleep(1000);
            rectangles.ToList().ForEach(x => x.Hide());
        }
    }
}
