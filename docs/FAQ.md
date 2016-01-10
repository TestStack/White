1. **Would there be support for Web Application testing?**  
Because there are already a lot of good tools which do this, developing it is not under consideration at this point of time. Look at Selenium, Sahi, Watir, Watin and Watij for testing web applications.

1. **Silverlight is more like rich client why should white not support it?**  
White Supports Silverlight, but currently there are no tests confirming it's stability. The Silverlight support definitely needs work (and tests), but is not a priority at the moment. 

1. **I am not able to find any items inside ToolStrip and MenuStrip (or DataGrid)**  
If you running NUnitConsole without /nothread option then you should try that out. [http://www.codeplex.com/white/WorkItem/View.aspx?WorkItemId=3603](http://www.codeplex.com/white/WorkItem/View.aspx?WorkItemId=3603)
Else,
There is a known issue with UIAutomation and ToolStrip/MenuStrip support. Please search for "UIAutomation menustrip" in google for more on this.
Try changing the ApartmentState to STA and see if that helps. In order to change this you would need to edit the app.config file for the test. See the Configuration page.

1. **I am unable to find window, primary UIItem or secondary UIItem, what might be wrong?**  
Please perform `LogStructure()` on the parent UIItem (i.e. Desktop, Window and PrimaryUIItem) to find out the descendant automation elements. Warning: while doing this at the desktop level please make sure you do not have too many un-necessary windows open as it might take a long time to log everything.

1. **I have multiple UIItems of the same type which has same id and text. How can I retrieve them?**  
In such cases generally the mechanism of indexing is preferable as that is how the user relates to them. It is explained here: (Getting Started)[/White/GettingStarted,html]

1. **I am using WPF and I have nested controls inside my control. Since this is not a standard control structure how do I automate this best with white.**  
Please have a look at the WPF Items section on UI Items page.

1.** I have to put sleeps and wait-for-conditions in my tests. What is the way to get around it?**  
Please read the Wait Handling to understand how white works. There are a lot of applications which are built without using wait cursor (hour glass) to provide user feedback when the application is busy. This is true in the initial stages of the project, where wait notification to use is done as an after thought. If wait feedback is provided right in the application under test then white would handle it as well. This should be done in the application not for automation but the user in first place. White currently doesn't handle custom wait cursors, this would be implemented in coming releases.

1. **Can white test run in the same process as the application?**  
No. White is not designed to work in this mode as this can cause threading issues. All in principle it is not a good idea to couple test code with application under test code as they would evolve independent from each other.

1. **My control (e.g. Button) is embedded inside a panel/group box. Do I need to first get hold of the containing control first and then get the button from it?**  
No you do not need to do that. You can directly get the button. This applies to all primary controls. See ControlTypeToUIItemMapping for list of primary UIItems.

1. **White support for office or any windows application.**  
White is based on UIAutomation for finding controls in a window. So the strength of automation support provided by white is equal to UIAutomation. This can be checked easily by using UISpy. The UIAutomation support is best on Windows 7, so you should use that when checking with UISpy. (e.g. ribbon controls are supported by UIAutomation). There is another route to automation if you intend to run a plugin inside the application. Since the plugin is .NET based you can leverage the power of Custom Commands to drive automation.

1. **If you are windows 7 and facing some issues automating menus**    
Then have a a look at following link: [http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=13821](http://www.microsoft.com/download/en/details.aspx?displaylang=en&id=13821)

1. **When the process I am testing crashes, I expect White to fail. How can I do this?**  
First off, you need to disable Windows Error Reporting, view [this GIST](https://gist.github.com/JakeGinnivan/5131363) for details  
Then if you handle the process exited event, you can check the error code and throw an exception to fail your test.

1. I** have asynchronous or background processes running in my app, how can I wait without using Thread.Sleep()**  
This is a complex subject with many scenarios and many solutions.
Head to the [Waiting](/White/Advanced%20Topics/Waiting.html) page for some help.

1. **What is the difference between System.Windows.Automation and the COM UIA Api?**  
White was written against the .net managed automation API (Refered to as SWA from now on) which is under the System.Windows.Automation namespace. This managed wrapper has custom behaviours over the COM Api, but does not support many new automation patterns added in Windows 7 & 8.
Read more [here](/White/Advanced%20Topics/UIAv3.html)

1. **I use my mouse left handed and have my mouse buttons swapped in Windows**  
Simply add the below code to your test setup
`CoreAppXmlConfiguration.Instance.InvertMouseButtons =                     !System.Windows.Forms.SystemInformation.MouseButtonsSwapped;`