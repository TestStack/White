White provides support for all the controls which comes with standard .NET libraries. This support is partially just abstraction over UIAutomation and window messages. So, in case of third party controls like DevExpress, PureComponents etc, there are no standard UIItem implementation in white which you can use out of the box. The reason being the automation element structure beneath is unique to each of them. These Custom UI Item can be plugged in to white.
While implementing these you might face issues. Some known issues and possible resolution is provided below. Soon we would have a sample for each of them available here:

## Do not rely on UISpy
UISpy comes along with .NET SDK. Please do not trust UISpy, it doesn't tell everything even for standard controls. You can use LogStructure() method to see what is present inside the control. This method is available on all the UIItems including window. It prints out the entire UIA tree which is helpful, if you are having problem finding UIItems. The structure would be logged in log file (and console if configured) as configured in log4net Configuration.
A lot of people on the white forums have been successful with http://www.codeplex.com/UIAutomationVerify for the same.

## Silverlight
Some of the controls http://msdn.microsoft.com/en-us/library/cc645045(VS.95).aspx?ppud=4 which come with silverlight do not have built-in support for UIAutomation. Hence white cannot recognize them. 

## Focusing the UIItem
...using Focus method, sometimes activates the UIAutomation to fetch the internal elements.