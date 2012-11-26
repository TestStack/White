using System;
using NUnit.Framework;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.UITests.Testing;
using White.Core.WindowsAPI;

namespace White.Core.UITests.WindowsAPI
{
    [TestFixture, NormalCategory]
    public class NativeWindowTest : ControlsActionTest
    {
        [Test]
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