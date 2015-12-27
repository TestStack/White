using NUnit.Framework;
using System;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class NativeWindowTests : WhiteUITestBase
    {
        public NativeWindowTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void BackgroundColorTest()
        {
            var colorref = new COLORREF { R = 200 };
            Console.WriteLine(colorref.R);

            var nativeWindow = new NativeWindow(new IntPtr(MainWindow.Get<TextBox>("TextBox").AutomationElement.Current.NativeWindowHandle));
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);

            //nativeWindow = new NativeWindow(MainWindow.Get<Image>("image").Bounds.Center());
            //Console.WriteLine(nativeWindow.BackgroundColor);
            //Console.WriteLine(nativeWindow.TextColor);

            nativeWindow = new NativeWindow(MainWindow.Get<Button>("ButtonWithTooltip").Bounds.ImmediateInteriorEast());
            Console.WriteLine(nativeWindow.BackgroundColor);
            Console.WriteLine(nativeWindow.TextColor);
        }
    }
}