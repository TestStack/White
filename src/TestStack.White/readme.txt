White
-----
White is a framework for automating rich client applications based on Win32, WinForms, WPF, Silverlight and SWT (Java) platforms. 
It is .NET based and does not require the use of any proprietary scripting languages. 

Tests/automation programs using White can be written with whatever .NET language, IDE and tools you are already using. 

White provides a consistent object-oriented API, hiding the complexity of Microsoft's UIAutomation library (on which White is based) and windows messages.

Getting Started
---------------
Make sure your TEST project is compiled as x86. When White runs as an x64 process, some things don't work properly. 

To get around this, White is compiled as x86 and if you do not change your test project you will get a 'BadFormatException' when loading your tests.

Visit https://github.com/TestStack/White/wiki for more help and common FAQ.


Namespace Change
----------------
**White's namespace has changed to `TestStack.White`!**

When you upgrade type `Fix-WhiteNamespace` into your NuGet powershell console to perform the rename,
the replace will leave all modified files open, and output the results into the 'Find Results 2' window

Breaking Changes
----------------
 - log4net dependency removed, read more at https://github.com/TestStack/White/wiki/log4net-Removal
 - SearchCriteria.ByControlType now takes WindowsFramework rather than string
 - WindowsFramework members renamed to Is[Framework] from [Framework]

Common Resources
----------------
Github site: 
https://github.com/TestStack/White

Report Issues at (Please read Reporting Issues at https://github.com/TestStack/White/wiki/Reporting-Issues):
https://github.com/TestStack/White/issues

Discussion Group:
https://groups.google.com/forum/#!forum/teststack_white

Change Log:
http://docs.teststack.net/White/ChangeLog.html