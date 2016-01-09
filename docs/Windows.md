---
layout: layout
title: Working with Windows
order: 3
---

## Getting window
### Application Windows
	List<Window> windows = application.GetWindows(); //Returns a list of all main windows in belonging to an application. It doesn't return modal windows.
	Window mainWindow = application.GetWindow("main"); //Returns a window with provided title.

### Desktop Windows
	List<Window> windows = Desktop.Instance.Windows(); //Returns a list of all main windows on the desktop. It doesn't return modal windows.

### Modal windows
	Window mainWindow = application.GetWindow("main");
	List<Window> modalWindows = mainWindow.ModalWindows(); //list of all the modal windows belong to the window.
	Window childWindow = mainWindow.ModalWindow("child"); //modal window with title "child"
	childWindow.IsModal; //returns true
	window.MessageBox can also be used for getting a message box window, which is special modal window.

### Mdi child window
Use it to find a MDI child belonging to a window.

	Window window = Desktop.Instance.Windows().Find(obj => obj.Title.Contains("Microsoft Visual Studio"));
	if (window == null) return;
	window.MdiChild(SearchCriteria.ByControlType(ControlType.Pane).AndByText("FooObject.cs"));

Since there is no single standard for creating MDI child windows, the method takes SearchCriteria, hence giving you the control of how to find child window. (Use [UIA Verify](https://uiautomationverify.codeplex.com/) for looking at the UIAutomation tree of the window.)

## Performing special operations on a window

### Attached Keyboard and mouse
provides a keyboard or mouse which would wait for the window to be idle after every action. All the actions possible on the mouse and keyboard are supported by these.

### Tooltip
any window, including it child controls can have only one visible tooltip at a time, hence this method is available on the window object.

	string message = window.ToolTip;
	
In some applications the tool tip is associated to an error provider which looks like ![Windows](../img/White/Windows.png). 

When mouse is hovered on it, a message is shown as tooltip. This need not be implemented by user as it is pretty standard behaviour and white provides it out of the box. If the message is set on the error provider for ComboBox then:

	var comboBox = window.Get<ComboBox>("komboBox");
	string message = comboBox.ErrorProviderMessage(window);

### Closing the window
Window object implements IDisposable interface, so that it can be used with the using block. Also, dispose is same as close. One can also check whether a window was closed or not. When a window.Close() is called white would try to close it using the WindowPattern provided by UIAutomation. In case this pattern is not implemented then white would make use of the close in the title bar to close it.

	window.Close(); //by default it waits while the window is busy.
	bool isClosed = window.IsClosed; //isClosed would be true

### Tool bar
Typical a window has zero or one tool bar. But it is possible to have more than one present on a window. Most likely scenario works as a special case of generic scenario in white.

	ToolStrip toolStrip1 = window.GetToolStrip("toolStripId1");
	// if there is only one then one can also do following to achieve the same
	toolStrip1 = window.ToolStrip;
	//ToolStrip is a UIItemContainer so child items can be found from it by call get methods.
	Button button = toolStrip1.Get<Button>("toolButton");

### WaitWhileBusy
It makes the window wait till the user input cannot be provided as it is busy performing background tasks. This method need not be called as all operations on UIItems explicitly call this at the end of every action. This method wouldn't cause wait indicated as hour glass, since this is controlled by application. But this is taken care of explicitly inside white but is not exposed to the user. Waiting based on hour glass is the default approach which can be turned off. [Configuration](/White/Configuration.html)

### Menu
A window can contain multiple menu bars. White supports working with multiple and since having single menu bar is so common it provides a convenience method for it.

	List<MenuBar> menuBars = window.MenuBars;
	MenuBar menuBar = window.MenuBar; //use it to get the only menu bar.

### Display state
A window can be in three display states: maximize, minimized and restored. `DisplayState` property on window provides this. `Core.UIItems.WindowItems.DisplayState` enum can be used to specify the state to a window.
Whether or not a window is the top most window at time can be retrieved by `IsCurrentlyActive` property.
