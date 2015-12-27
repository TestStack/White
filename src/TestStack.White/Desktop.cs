using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White
{
    public class Desktop : UIItemContainer
    {
        public static readonly Desktop Instance = Create();
        private readonly AutomationElementFinder finder;

        private static Desktop Create()
        {
            return new Desktop(AutomationElement.RootElement, new NullActionListener(), InitializeOption.NoCache, new NullWindowSession());
        }

        private Desktop(AutomationElement automationElement, ActionListener actionListener, InitializeOption initializeOption,
                        WindowSession windowSession) : base(automationElement, actionListener, initializeOption, windowSession)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual ListItems Icons
        {
            get { return IconsList.Items; }
        }

        private ListControl IconsList
        {
            get
            {
                AutomationElement element =
                    finder.Child(new[]
                                     {
                                         AutomationSearchCondition.ByControlType(ControlType.Pane).WithName("Program Manager"),
                                         AutomationSearchCondition.ByControlType(ControlType.List).WithName("Desktop")
                                     });
                return new ListControl(element, new ProcessActionListener(element));
            }
        }

        public virtual void Drop(UIItem uiItem)
        {
            Mouse.DragAndDrop(uiItem, IconsList);
        }

        public virtual List<Window> Windows()
        {
            return WindowFactory.Desktop.DesktopWindows();
        }

        /// <summary>
        /// Captures a screenshot of the entire desktop, and returns the bitmap
        /// </summary>
        public static Bitmap CaptureScreenshot()
        {
            var screenCapture = new ScreenCapture();
            return screenCapture.CaptureDesktop();
        }

        /// <summary>
        /// Captures a screenshot of the provided boundary, and returns the bitmap
        /// </summary>
        /// <param name="bounds">Screen rectangle to capture</param>
        public static Bitmap CaptureScreenshot(Rect bounds)
        {
            var screenCapture = new ScreenCapture();
            return screenCapture.CaptureArea(bounds);
        }

        /// <summary>
        /// Takes a screenshot of the provided boundary, and saves it to disk
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="filename">The fullname of the file (including extension)</param>
        /// <param name="imageFormat"></param>
        public static void TakeScreenshot(Rect bounds, string filename, ImageFormat imageFormat)
        {
            var bitmap = CaptureScreenshot(bounds);
            bitmap.Save(filename, imageFormat);            
        }

        /// <summary>
        /// Takes a screenshot of the entire desktop, and saves it to disk
        /// </summary>
        /// <param name="filename">The fullname of the file (including extension)</param>
        /// <param name="imageFormat"></param>
        public static void TakeScreenshot(string filename, ImageFormat imageFormat)
        {
            var bitmap = CaptureScreenshot();
            bitmap.Save(filename, ImageFormat.Png);
        }
    }
}