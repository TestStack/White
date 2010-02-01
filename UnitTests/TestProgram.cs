using System;
using White.Core;
using White.Core.UIItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests
{
    public static class TestProgram
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var test = new ImageTestToBeRunFromConsole();
            test.TestClick();
        }
    }

    [WinFormCategory]
    public class ImageTestToBeRunFromConsole : ControlsActionTest
    {
        public void TestClick()
        {
            try
            {
                LaunchApplication();
                window.Get<Image>("image").Click();
            }
            finally
            {
                TextFixtureTearDown();
            }
        }
    }
}