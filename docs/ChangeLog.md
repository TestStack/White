---
layout: layout
title: Change Log
order: 9
---

## Version 0.11.0
### Namespace Change
White Namespace changed from White.Core to TestStack.White

Run `Fix-WhiteNamespaces` in the nuget powershell console to automatically fix up namespace errors

### Documentation Site 
Documentation available at [http://teststack.azurewebsites.net/](http://teststack.azurewebsites.net/)

 - **Enhancement**: x64 Support added. You can now compile your project as AnyCPU!
 - **Enhancement**: Improved API of Slider
 - **Enhancement**: Better Custom controls support for WPF
 - **Fixed**: Cannot find multiline textbox in Win32 apps
 - **Fixed**: Unable to Find Win32 modal window
 - **Fixed**: Drag/Drop sometimes pausing until the mouse is moved
 - **Fixed**: Better expanding/collapsing of Win32TreeView
 - **Fixed**: Expandable lists now restore their previous expansion (after the items have been retrieved), if `ComboBoxItemsPopulatedWithoutDropDownOpen` is set to false
 - **Fixed**: Automating GridView for non-English locals
 - **Fixed**: Heaps of other little bugs fixed around selection/scrolling fixed
 - **Fixed**: Unable to click one Menu items twice
 - **BREAKING**: ModalWindow now throws when the window cannot be found
 - **BREAKING**/Enhancement: **MultiLineTextBox no longer exists**, simply use TextBox
 - **TestStack.White.ScreenObjects** released on NuGet

Thanks to all the contributors who helped make v0.11.0. 

## Version 0.10.3
 - Some small updates to WPF Get extension methods
 - Further tooltip fixes

## Version 0.10.2
 - Made ListItem selection more reliable

## Version 0.10.1
 - Fix: Tooltips can now be found as expected
 - Retry.ForDefault method now reads it's default timeout from White's configuration
 - New Configuration value 'FindWindowTimeout' which is defaulted to 30 seconds
 - Added ability to take screenshots of the desktop:
    - `Desktop.CaptureScreenshot()` returns a Bitmap
    - `Desktop.TakeScreenshot(string filename, ImageFormat imageFormat)` saves the screenshot to file

## Version 0.10.0
 - BREAKING: Removed Log4net, now using Castle's logging abstractions. See https://github.com/TestStack/White/wiki/log4net-Removal
 - BREAKING: SearchCriteria.ByControlType now takes WindowsFramework rather than string
 - BREAKING: WindowsFramework members renamed to Is[Framework] from [Framework]
 - Fix: Lots of combobox updates/fixes
 - Fix: AsContainer() could throw a NullReferenceException
 - Fix: Checkbox fixes
 - Fix: Added support for WPF DatePicker
 - All exceptions are now serialisable

Version 0.10.0 removed the log4net dependency in TestStack.White, we now rely on [Castle.Core's Logging abstractions](http://old.castleproject.org/services/logging/index.html).

By default White uses the `ConsoleFactory` which will cause all logging to be directed to the console, which most unit test frameworks and build servers will pick up. 

To set your own simply override the logger factory in White's configuration.

    CoreAppXmlConfiguration.Instance.LoggerFactory = new Log4netFactory();

By removing this hard dependency you can use whatever logging framework you would like with White.

## Version 0.9.3
 - **BREAKING**: White is now compiled as x86 (fixes issues when run in x64 process)
 - **BREAKING**: White will no longer throw TargetInvocationExceptions in some cases, instead it will throw the real, unwrapped exception
 - Added support for swapping mouse buttons (for left handed users/system setup) - Accessible via configuration

## Version 0.9.2
 - **BREAKING**: UIItem.Get now throws an AutomationException when the UI Element is not found
 - **Change**: UIItem.Get now auto retries to fetch the item
 - **FIX**: Added small delay when fetching menu items (to compensate for menu animation in newer versions of windows)
 - **FIX**: AttachOrLaunch method now can accept a full Path.