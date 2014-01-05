using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using TestStack.White.Configuration;

namespace TestStack.White.Drawing
{
    internal class ScreenRectangle
    {
        private Form form = new Form();
        //TODO: Think about making color configurable
        private Color Color = Color.Red;

        internal ScreenRectangle(Rect rectangle)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ShowInTaskbar = false;
            form.TopMost = true;
            form.Left = 0;
            form.Top = 0;
            form.Width = 1;
            form.Height = 1;
            form.BackColor = this.Color;
            form.Opacity = 0.8;
            form.Visible = true;

            //Set popup style
            int num1 = TestStack.White.WindowsAPI.NativeWindow.GetWindowLong(form.Handle, -20);
            TestStack.White.WindowsAPI.NativeWindow.SetWindowLong(form.Handle, -20, num1 | 0x80);

            //Set position
            TestStack.White.WindowsAPI.NativeWindow.SetWindowPos(form.Handle, new IntPtr(-1), Convert.ToInt32(rectangle.X), Convert.ToInt32(rectangle.Y),
                Convert.ToInt32(rectangle.Width), Convert.ToInt32(rectangle.Height), 0x10);
        }

        internal virtual void Show()
        {
            TestStack.White.WindowsAPI.NativeWindow.ShowWindow(form.Handle, 8);
        }

        internal virtual void Hide()
        {
            form.Hide();
        }
    }

    internal class FrameRectangle
    {
        //Using 4 rectangles to display each border
        private ScreenRectangle leftBorder;
        private ScreenRectangle topBorder;
        private ScreenRectangle rightBorder;
        private ScreenRectangle bottomBorder;

        private ScreenRectangle[] rectangles;
        private int width = 3;

        internal FrameRectangle(Rect boundingRectangle)
        {
            leftBorder = new ScreenRectangle(new Rect(boundingRectangle.X - width, boundingRectangle.Y - width, width, boundingRectangle.Height + 2*width));
            topBorder = new ScreenRectangle(new Rect(boundingRectangle.X, boundingRectangle.Y - width, boundingRectangle.Width, width));
            rightBorder = new ScreenRectangle(new Rect(boundingRectangle.X + boundingRectangle.Width, boundingRectangle.Y - width, width, boundingRectangle.Height + 2*width));
            bottomBorder = new ScreenRectangle(new Rect(boundingRectangle.X, boundingRectangle.Y + boundingRectangle.Height, boundingRectangle.Width, width));
            rectangles = new ScreenRectangle[] { leftBorder, topBorder, rightBorder, bottomBorder };
        }

        internal virtual void Highlight()
        {
            rectangles.ToList().ForEach(x => x.Show());
            Thread.Sleep(CoreAppXmlConfiguration.Instance.HighlightTimeout);
            rectangles.ToList().ForEach(x => x.Hide());
        }
    }
}
