using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace White.Core.WindowsAPI
{
    //Credits: http://www.developerfusion.com/code/4630/capture-a-screen-shot/
    public class DisplayedItem
    {
        private readonly IntPtr windowHandle;
        private const int srccopy = 0x00CC0020;

        [DllImport("GDI32.dll")]
        private static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc,
                                         int dwRop);

        [DllImport("GDI32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("GDI32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("GDI32.dll")]
        private static extern bool DeleteDC(IntPtr hDC);

        [DllImport("GDI32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("GDI32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public DisplayedItem(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public virtual Bitmap GetVisibleImage()
        {
            var compatibleDeviceContext = IntPtr.Zero;
            var deviceContext = IntPtr.Zero;
            IntPtr bitmap = IntPtr.Zero;
            Image img;
            try
            {
                deviceContext = GetWindowDC(windowHandle);
                var rect = new Rect();
                GetWindowRect(windowHandle, ref rect);
                int width = rect.right - rect.left;
                int height = rect.bottom - rect.top;
                compatibleDeviceContext = CreateCompatibleDC(deviceContext);
                bitmap = CreateCompatibleBitmap(deviceContext, width, height);
                IntPtr @object = SelectObject(compatibleDeviceContext, bitmap);
                BitBlt(compatibleDeviceContext, 0, 0, width, height, deviceContext, 0, 0, srccopy);
                SelectObject(compatibleDeviceContext, @object);
            }
            finally
            {
                DeleteDC(compatibleDeviceContext);
                ReleaseDC(windowHandle, deviceContext);
                img = Image.FromHbitmap(bitmap);
                DeleteObject(bitmap);
            }

            return new Bitmap(img);
        }
    }
}