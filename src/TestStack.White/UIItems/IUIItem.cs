using System.Drawing;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.Scrolling;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using Point = System.Windows.Point;

namespace TestStack.White.UIItems
{
    public interface IUIItem : IActionListener
    {
        /// <summary>
        ///     Should be used only if white doesn't support the feature you are looking for.
        ///     Knowledge of UIAutomation would be required. It would better idea to also raise an issue if you are using it.
        /// </summary>
        AutomationElement AutomationElement { get; }

        bool Enabled { get; }
        WindowsFramework Framework { get; }
        Point Location { get; }
        Rect Bounds { get; }
        string Name { get; }
        Point ClickablePoint { get; }
        string AccessKey { get; }
        string Id { get; }
        bool Visible { get; }
        string PrimaryIdentification { get; }
        IActionListener ActionListener { get; }
        IScrollBars ScrollBars { get; }
        bool IsOffScreen { get; }
        bool IsFocussed { get; }
        Color BorderColor { get; }
        Bitmap VisibleImage { get; }
        bool ValueOfEquals(AutomationProperty property, object compareTo);
        void RightClickAt(Point point);
        void RightClick();
        void Focus();

        /// <summary>
        ///     An alternative to use instead of Focus, might sometimes be more reliable
        /// </summary>
        void SetForeground();

        void Visit(IWindowControlVisitor windowControlVisitor);

        /// <summary>
        ///     Provides the Error on this UIItem. This would return Error object when this item has ErrorProvider displayed next
        ///     to it.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        string ErrorProviderMessage(Window window);

        bool NameMatches(string text);

        /// <summary>
        ///     Performs mouse click at the center of this item
        /// </summary>
        void Click();

        /// <summary>
        ///     Performs mouse double click at the center of this item
        /// </summary>
        void DoubleClick();

        /// <summary>
        ///     Perform keyboard action on this UIItem
        /// </summary>
        /// <param name="key"></param>
        void KeyIn(KeyboardInput.SpecialKeys key);

        bool Equals(object obj);
        int GetHashCode();
        string ToString();

        /// <summary>
        ///     Internal to white and intended to be used for white recording
        /// </summary>
        void UnHookEvents();

        /// <summary>
        ///     Internal to white and intended to be used for white recording
        /// </summary>
        /// <param name="eventListener"></param>
        void HookEvents(UIItemEventListener eventListener);

        void SetValue(object value);
        void LogStructure();

        /// <summary>
        ///     Uses the Raw View provided by UIAutomation to find elements within this UIItem. RawView sometimes contains extra
        ///     AutomationElements. This is internal to
        ///     white although made public. Should be used only if the standard approaches dont work. Also if you end up using it
        ///     please raise an issue
        ///     so that it can be fixed.
        ///     Please understand that calling this method on any UIItem which has a lot of child AutomationElements might result
        ///     in very bad performance.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>null or found AutomationElement</returns>
        AutomationElement GetElement(SearchCriteria searchCriteria);

        void Enter(string value);

        void DrawHighlight();
        void DrawHighlight(Color color);

        /// <summary>
        ///     Captures an image of the element
        /// </summary>
        Bitmap Capture();
    }
}