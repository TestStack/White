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
        #region Automation

        /// <summary>
        /// Should be used only if white doesn't support the feature you are looking for.
        /// Knowledge of UIAutomation would be required. It would better idea to also raise an issue if you are using it.
        /// </summary>
        AutomationElement AutomationElement { get; }

        /// <summary>
        /// The <see cref="WindowsFramework"/> of the UI Item
        /// </summary>
        WindowsFramework Framework { get; }

        /// <summary>
        /// The <see cref="IActionListener"/> of the UI Item
        /// </summary>
        IActionListener ActionListener { get; }

        /// <summary>
        /// Uses the Raw View provided by UIAutomation to find elements within this UIItem. 
        /// RawView sometimes contains extra AutomationElements. 
        /// This is internal to white although made public. 
        /// Should be used only if the standard approaches dont work. 
        /// Also if you end up using it please raise an issue so that it can be fixed.
        /// Please understand that calling this method on any UIItem,
        /// which has a lot of child AutomationElements might result in very bad performance.
        /// </summary>
        /// <param name="searchCriteria"></param>
        /// <returns>null or found AutomationElement</returns>
        AutomationElement GetElement(SearchCriteria searchCriteria);

        #endregion

        #region State Properties

        /// <summary>
        /// Is UI Item Enabled
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Is UI Item Off Screen
        /// </summary>
        bool IsOffScreen { get; }

        /// <summary>
        /// Is UI Item Visible
        /// </summary>
        bool Visible { get; }

        /// <summary>
        /// Is UI Item Focussed
        /// </summary>
        bool IsFocussed { get; }

        /// <summary>
        /// The Status of the UI Item
        /// </summary>
        string ItemStatus { get; }

        /// <summary>
        /// Name of the UI Item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ID of the UI Item
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Primary Identification of the UI Item
        /// </summary>
        string PrimaryIdentification { get; }

        /// <summary>
        /// Access Key of the UI Item
        /// </summary>
        string AccessKey { get; }

        /// <summary>
        /// HelpText of the UI Item
        /// </summary>
        string HelpText { get; }

        /// <summary>
        /// <see cref="IScrollBars"/> of the UI Item
        /// </summary>
        IScrollBars ScrollBars { get; }

        #endregion

        #region Dimension Properties

        /// <summary>
        /// <see cref="Point"/> location of the UI Item
        /// </summary>
        Point Location { get; }

        /// <summary>
        /// <see cref="Rect"/> Bounds of the UI Item
        /// </summary>
        Rect Bounds { get; }

        /// <summary>
        /// <see cref="Point"/> ClickablePoint of the UI Item
        /// </summary>
        Point ClickablePoint { get; }

        #endregion

        #region Graphics

        /// <summary>
        /// <see cref="Color"/> of the UI Item Border
        /// </summary>
        Color BorderColor { get; }

        /// <summary>
        /// <see cref="Bitmap"/> representing the VisibleImage of the UI Item
        /// </summary>
        Bitmap VisibleImage { get; }

        /// <summary>
        /// Draw a Highlighting around the UI Item in the Color <see cref="Color.Red"/>
        /// </summary>
        void DrawHighlight();

        /// <summary>
        /// Draw a Highlighting around the UI Item in a specific color
        /// </summary>
        /// <param name="color">Color of the Highlighting</param>
        void DrawHighlight(Color color);

        /// <summary>
        /// Capture a <see cref="Bitmap"/> image of the UI Item
        /// </summary>
        Bitmap Capture();

        #endregion

        #region Interaction

        /// <summary>
        /// Focus the UI Item
        /// </summary>
        void Focus();

        /// <summary>
        /// Bring the UI Item to the Foreground
        /// </summary>
        /// <remarks>
        /// An alternative to use instead of Focus, might sometimes be more reliable
        /// </remarks>
        void SetForeground();
        
        /// <summary>
        /// Visit the UI Item
        /// </summary>
        /// <param name="windowControlVisitor">Window Control Visitor</param>
        void Visit(IWindowControlVisitor windowControlVisitor);

        /// <summary>
        /// Performs an Invoke on the <see cref="InvokePattern"/> Pattern of the UI Item
        /// </summary>
        /// <remarks>
        /// This is faster then a <see cref="Click()"/> on the UI Item.
        /// Can have some side effects that certain Click Events are bypassed.
        /// </remarks>
        void Invoke();

        /// <summary>
        /// Performs mouse click at the center of the UI Item
        /// </summary>
        void Click();

        /// <summary>
        /// Performs mouse double click at the center of the UI Item
        /// </summary>
        void DoubleClick();

        /// <summary>
        /// Performs a right mouse click at the center of the UI Item
        /// </summary>
        void RightClick();

        /// <summary>
        /// Performas a right mouse click at a defined <remarks>Point</remarks>
        /// </summary>
        /// <param name="point">Point to mouse right click</param>
        void RightClickAt(Point point);

        /// <summary>
        ///Perform keyboard action on this UI Item
        /// </summary>
        /// <param name="key"></param>
        void KeyIn(KeyboardInput.SpecialKeys key);

        /// <summary>
        /// Sets a value on this UI Item
        /// </summary>
        /// <param name="value">Value to set</param>
        void SetValue(object value);

        /// <summary>
        /// Enter a value on this UI Item
        /// </summary>
        /// <param name="value">Value to enter</param>
        /// <remarks>The <see cref="ValuePattern"/> must be supported by the UI Item for this to work</remarks>
        void Enter(string value);

        #endregion

        #region Recording

        /// <summary>
        /// Internal to white and intended to be used for white recording
        /// </summary>
        void UnHookEvents();

        /// <summary>
        /// Internal to white and intended to be used for white recording
        /// </summary>
        /// <param name="eventListener"></param>
        void HookEvents(IUIItemEventListener eventListener);

        #endregion

        #region Debugging

        /// <summary>
        /// Provides the Error on this UIItem. 
        /// This would return Error object when this item has ErrorProvider displayed next to it.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        string ErrorProviderMessage(Window window);

        /// <summary>
        /// Log Structure of the UI Item
        /// </summary>
        void LogStructure();

        #endregion

        #region Equality

        /// <summary>
        /// Check if the UI Item name matches a given name
        /// </summary>
        /// <param name="text">Name Value to match against</param>
        /// <returns>Returns <c>true</c> if matches, else <c>false</c></returns>
        bool NameMatches(string text);

        /// <summary>
        /// Compare the <see cref="AutomationProperty"/> from the UI Item against an object
        /// </summary>
        /// <param name="property">The <see cref="AutomationProperty"/> value to compare to</param>
        /// <param name="compareTo">The object to compare it to</param>
        /// <returns>Returns <c>true</c> if matches, else <c>false</c></returns>
        bool ValueOfEquals(AutomationProperty property, object compareTo);

        /// <summary>
        /// CHeck if the UI Item equals an object
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>Returns <c>true</c> if matches, else <c>false</c></returns>
        bool Equals(object obj);

        /// <summary>
        /// Get the HashCode of the UI Item
        /// </summary>
        /// <returns>The HashCode of the UI Item</returns>
        int GetHashCode();
        
        /// <summary>
        /// ToString overload for the UI Item
        /// </summary>
        /// <returns>The String representation of the UI Item</returns>
        string ToString();

        #endregion
    }
}