##NOTE: This section needs revisiting and is likely out of date

Configuration
White configuration is done in App.config file. You need to setup configSections, sectionGroup and section. Here is an example of how to do this, with the default values for them. In case any property value is not specified these values would be used. 

	<configSections>
	    <sectionGroup name="NUnit">
	      <section name="TestRunner" type="System.Configuration.NameValueSectionHandler"/>
	      <section name="ProgramMode" type="Debug"/>
	    </sectionGroup>
	    <sectionGroup name="White">
	      <section name="Core" type="System.Configuration.NameValueSectionHandler"/>
	   </sectionGroup>
	</configSections>
	
	<White>
	    <Core>
	      <add key="WorkSessionLocation" value="." />
	      <add key="PopupTimeout" value="5000" />
	      <add key="SuggestionListTimeout" value="3000" />
	      <add key="BusyTimeout" value="5000" />
	      <add key="WaitBasedOnHourGlass" value="true" />
	      <add key="UIAutomationZeroWindowBugTimeout" value="5000" />
	      <add key="TooltipWaitTime" value="3000" />
	      <add key="DragStepCount" value="4" />
	    </Core>
	</White>

### WorkSessionLocation
Location where the WindowItemsMap is stored as xml. WindowItemsMap is create to Speed up performance by Position based search.

### PopupTimeout, TooltipWaitTime, SuggestionListTimeout, BusyTimeout, WaitBasedOnHourGlass, UIAutomationZeroWindowBugTimeout, TooltipWaitTime
Checkout, [Wait handling](/White/Advanced%20Topics/Waiting.html)

### ComboBoxItemsPopulatedWithoutDropDownOpen
In certain situations the combo box item properties are not reflected in the Automation Elements unless the combo box Drop down is opened once. This poses problem for white to do actions which require white to search for items by text. In order to get around this situation white always opens and closes the Drop down when a combo box item is constructed. This can have slight performance over head and can be annoying. This configuration property can be used to avoid doing this. As in most cases such problems don't exist, the default value for this configuration is true.

### RawElementBasedSearch
Read [Search depth](/White/Advanced%20Topics/SearchDepth.html).

### MaxElementSearchDepth
Read [Search depth](/White/Advanced%20Topics/SearchDepth.html). Applicable only when RawElementBasedSearch=true.

### MoveMouseToGetStatusOfHourGlass
In order to check whether application is busy (processing the last action or not) white moves the mouse to top-left-corner of screen. This doesn't work in few cases, when application is not maximized and top left corner takes the mouse outside the application window, when the application under test controls the mouse pointer appearance based on its position. In such cases this property can set to false.

### DragStepCount
When using drag and drop this specifies the number of steps in which drag should be performed. Default value is one step, which means that mouse location is changed from source to destination in one go.

### DoubleClickInterval
White doesn't have any sleep for between two clicks of a mouse. But such waits can be introduced using this property. White also uses this property to ensure that the drag and drop operations do not result in double click. The value is in milliseconds.

All of these properties can be configured via program as well. Sample code which in order to read/update these values. The configured values are logged when you run white programs.

	Console.WriteLine(CoreAppXmlConfiguration.Instance.PopupTimeout);
	CoreAppXmlConfiguration.Instance.TooltipWaitTime = 100;

WorkSessionLocation specifies the location for storing UIItem position file
For description of other properties look at the Wait Handling section