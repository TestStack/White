using System;
using White.Core.UIA;
using NUnit.Framework;
using White.Core.Testing;
using White.Core.UIItems;

namespace White.Core.WindowsAPI
{
    [TestFixture, NormalCategory]
    public class NativeWindowTest : ControlsActionTest
    {
        [Test, Ignore]
        public void BackgroundColor()
        {
            var colorref = new COLORREF {R = 200};
            Console.WriteLine(colorref.R);

            var nativeWindow = new NativeWindow(new IntPtr(window.Get<TextBox>("textBox").AutomationElement.Current.NativeWindowHandle));
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);

            nativeWindow = new NativeWindow(window.Get<Image>("image").Bounds.Center());
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);

            nativeWindow = new NativeWindow(window.Get<Button>("buton").Bounds.ImmediateInteriorEast());
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);
        }
    }
}