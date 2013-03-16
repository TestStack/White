using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace White.Core
{
    /// <summary>
    /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
    /// </summary>
    public class ScreenCapture
    {
        // This code is a modified version of many similar classes along the same lines. There is no one source I can credit with this class

        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);

        public Bitmap CaptureScreenShot()
        {
            var sz = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            var hDesk = GetDesktopWindow();
            var hSrce = GetWindowDC(hDesk);
            var hDest = CreateCompatibleDC(hSrce);
            var hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
            var hOldBmp = SelectObject(hDest, hBmp);
            BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            var bmp = Image.FromHbitmap(hBmp);
            SelectObject(hDest, hOldBmp);
            DeleteObject(hBmp);
            DeleteDC(hDest);
            ReleaseDC(hDesk, hSrce);

            return bmp;
        }
    }
}