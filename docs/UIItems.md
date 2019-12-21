## UIItem Identification
Managed UI applications have a mechanism for identifying controls by specifying them names. These names are available for finding controls on using UIAutomation API. Name property used while developing application show up as AutomationId when using UIA API.
Un-managed applications donot have such feature. In these applications the controls are usually identified by text (white terminology) (name in UIA terminology).

Within a window any UIItem can be identified based combination following criteria.

1. **AutomationId** is the programmatic identifier specified by the AppDeveloper. In WinForm and WPF this is the name supplied to the control. This is not present for SWT and Win32 applications. (applies only to .NET applications WinForm, WPF, Silverlight.)
For managed applications:

		SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("btnOK");
		Button button = window.Get<Button>("btnOK"); //default search mechanism is by automation id
		button = window.Get<Button>(searchCriteria); // is same as above
		For un-managed applications:
		Button button = window.Get<Button>("OK"); //default search mechanism is by UIAutomation name
		button = window.Get<Button>(SearchCriteria.ByText("OK")); // same as above

2. **UIItem** type (e.g. Button, ComboBox)

		Button button = window.Get<Button>("btnOK"); //<Button> acts as criteria as well as the return type
		button = (Button) window.Get(SearchCriteria.ByAutomationId("btnOK").AndControlType(typeof(Button))); // same as above
3. **ControlType** is the ControlType defined in UIAutomation. Since this is same as above these shouldn't be a reason to use this

		button = (Button) window.Get(SearchCriteria.ByControlType(ControlType.Button).AndAutomationId("btnOK"));
4. **Text** is the additional property defined for accessibility purposes. This property maps to some attribute on UIItem which is visible on the control. Find the detailed map here:

		button = window.Get<Button>(SearchCriteria.ByText("OK")); //OK is the display text on the button.
This is much more readable from testing point of view, as it is obvious which button we are interested in. The problem is that in an evolving application the text changes more frequently than the automation id.

5. Zero based **Index** of UIItem in case multiple UIItems have same identification based on other parameters. Index is measured from top left corner of the window X first and Y second.

		// if there are two buttons with the same automation id.
		button = window.Get<Button>(SearchCriteria.ByAutomationId("btnOK").AndIndex(1));
6. Searching based on any UIA property. (Other properties can be found from the class AutomationElement)

		button = window.Get<Button>(SearchCriteria.ByNativeProperty(AutomationElement.AutomationIdProperty, "btnOK"));

The Get method on window can be used only to find PrimaryUIItems. All the primary UIItems are shown with Object Structure. The idea behind the API is to find the primary UIItems first and then work with their specific child items if any.

## ControlType to UIItem Mapping for Primary UIItems
White maps UIA control types to classes in White, to give you a familiar programming model and raise the abstraction level

![UIItems11](../img/White/UIItems11.png)


UIA ControlType |  White's UIItem   | Additional Info
------------------|------------------|------------------
List	                       | ListBox                 | The classname of ListView is misleading
DataGrid               | ListView               | ListView in WinForm
Edit                       | TextBox 
Text                      | Label
ComboBox         | ComboBox          | WPFComboBox,Win32ComboBox,WinFormComboBox
Slider                   | Slider
Button                 | Button
CheckBox           | CheckBox
Hyperlink            | Hyperlink
Tree                     | Tree
RadioButton       | RadioButton
Table                   | Table                     | DataGridView in WinForm maps to this
Document          | TextBox                 | MultilineTextBox no longer exists
Tab                      | Tab                        | TabControl in WinForm
ToolBar               | ToolStrip
MenuBar             | MenuBar
Menu                   | MenuBar
MenuItem           | Menu
ProgressBar         | ProgressBar
Spinner                | Spinner
Pane                     | PropertyGrid, DateTimePicker
StatusBar             | StatusStrip
Image                  | Image
TabPage              | TabItem
Custom               | TableHeader, TableRow
DataItem             | ListViewRow
ListItem               | ListItem
TreeItem             | TreeNode
Group                  | GroupBox
Thumb                | Thumb
TitleBar                | TitleBar                      |  use window.TitleBar to retrieve it
ToolTip               | ToolTip                      | use window. ToolTip to retrieve it

Secondary ControlTypes (Header, HeaderItem, ScrollBar, ListItem, TabItem) are not listed here.
ControlType.Window maps to Window but window is not a primary item

# Menu Bars
A menu bar is part of a window, while a pop-up menu can be shown on a window. Other than this difference, the two types of menus behave in a consistent way, as far as a user is concerned. Both of them are composed of click-able menu items.

First, let's look at how menu bar items and popup menu items can be retrieved so White can click on them.

	//POP UP MENU
	window.Get<ListBox>("listBoxWithPopup").RightClick();
	PopupMenu popupMenu = window.Popup;
	Menu level2Menu = popupMenu.Item("Root", "Level1", "Level2");
	level2Menu = popupMenu.ItemBy(SearchCriteria.ByText("Root"), SearchCriteria.ByText("Level1"), SearchCriteria.ByText("Level2")); //can use any other search criteria as well.
	
	//MENU BAR
	MenuBar menuBar = window.MenuBar;
	Menu level2Menu =  menuBar.MenuItem("Root", "Level1", "Level2");
	level2Menu = menuBar.MenuItemBy(SearchCriteria.ByText("Root"), SearchCriteria.ByText("Level1"), SearchCriteria.ByText("Level2")); //can use any other search criteria as well.

	level2Menu.Click();
	
"Root" is one of the menus in the first level, "Level1" is inside "Root" menu and "Level2" is inside "Level1". So on.
"Root", etc are text of the menu visible to user.

# Object Structure
Within window box, one can see all primary UIItems. This list is not complete but would give you an idea to understand the difference between primary and secondary controls.

![UIItems](../img/White/UIItems.png)  
![UIItems1](../img/White/UIItems1.png)

There is support for ListBox containing checkboxes. Use check and uncheck method.

Primary UIItems along with their secondary (child) UIItems

![UIItems2](../img/White/UIItems2.png)

![UIItems3](../img/White/UIItems3.png)

![UIItems4](../img/White/UIItems4.png)

![UIItems5](../img/White/UIItems5.png)

![UIItems6](../img/White/UIItems6.png)

![UIItems7](../img/White/UIItems7.png)

![UIItems8](../img/White/UIItems8.png)

![UIItems9](../img/White/UIItems9.png)

![UIItems10](../img/White/UIItems10.png)

# Examples
## List View
In order to select multiple rows in ListView use MultiSelect method.

	listView.Rows[0].Select();
	listView.Rows[1].MultiSelect(); //This would keep the 0th row selected as well
	
	ListBox
	listBox.Check("item1"); // in checked listBox, to check the item
	listBox.UnCheck("item1");
	ListItems items = listBox.Items; // get all the items
	listBox.Select("item1"); // select an item
	ListItem listItem = listBox.SelectedItem; // get a selected item
	
	ComboBox
	comboBox.Select("Arundhati Roy");
	ListItem listItem = comboBox.SelectedItem;

## Tree
Tree consists of TreeNodes. Each of the TreeNode object can contain further TreeNodes.
In order to select a TreeNode first find the node and call select method on it.

	TreeNode treeNode = tree.Node("Root", "Child1");
	treeNode.Select(); //Just selects the node without expanding it. Depending on your application logic this might also expand and collapse the node.
	treeNode.Expand(); //Expand the node and display child nodes belonging to this node.
	treeNode.Collapse(); //Collapse this node
	treeNode.IsExpanded; //Return the state expansion state

## DateTimePicker
Currently it supports only Date and not the time. Since there is no native support for DateTimePicker in UIAutomation for setting the value, White uses keyboard to set the value. When the value is set it enters the value, without opening the calendar. Hence it is important for it to know the DateFormat.
There are two ways to set the date.

	DateTimePicker dateTimePicker = window.Get<DateTimePicker>("dob");
	dateTimePicker.Date = DateTime.Now.AddMonth(1);

In this case DateTimePicker would use the configured DateFormat (in case no explicit configuration it uses default format based on the current culture).

	DateTimePicker dateTimePicker = window.Get<DateTimePicker>("dob");
	dateTimePicker.SetDate(DateTime.Now.AddMonth(1), DateFormat.YearDayMonth);

These are possible DateFormats:
DayMonthYear, DayYearMonth, MonthDayYear, MonthYearDay, YearMonthDay and YearDayMonth

### Configuring DateFormat
You need to set the DefaultDateFormat property in the configuration file under section Core. The possible values are:
"DayMonthYear", "DayYearMonth", "MonthDayYear", "MonthYearDay", "YearMonthDay" and "YearDayMonth"

## WPF Items
WPF allows the UI developer to compose controls of dynamic types. Since the control structure is not predictable in WPF, white's UIItem structure allows one to do the same while testing.
e.g. If ListItem has a text box

	// other imports
	using White.Core.UIItems.WPFUIItems; //add this using allows one use Get and GetMultiple methods on any UIItem
	namespace White.Core.UIItems.ListBoxItems
	{
	  [TestFixture]
	  public class WPFListBoxTest
	  {
	    [Test]
	    public void ListItemContainingTextbox()
	    {
	      // code to get the window object
	      var listBox = window.Get<ListBox>("listBox");
	      var listItem = (WPFListItem) listBox.Items.Find(item => "Foo".Equals(item.Text));
	      var textBox = listItem.Get<TextBox>(SearchCriteria.All);
	    }
	  }
	}

## Thumb
Used to control the splitter control, which can be slid by dragging the mouse.

	Thumb thumb = window.Get<Thumb>("splitter");
	thumb.SlideHorizontally(10); //move the splitter 10 pixels to the right
	thumb.SlideHorizontally(-15); //move the splitter 15 pixels to the left
	
	// in case of vertical splitter
	thumb.SlideVertically(10); //move the splitter 10 pixels down
	thumb. SlideVertically(-15); //move the splitter 15 pixels up

## GroupBox/Panel
Since GroupBox and Panel extend from UIItemContainer one can retrieve items from within groupbox or panel using:

	GroupBox groundBox = window.Get<GroupBox>("groupBox1");
	Button button = groupBox.Get<Button>("button1"); //provides button which is inside the group box
	groupBox.Get<Button>(SearchCriteria.ByText("OK")); //other search techniques available on window are also available here.

## ToolBar/ToolStrip
	ToolStrip toolStrip = window.Get< ToolStrip >("toolStrip1");

## WPF Expander Control
	// other imports
	using White.Core.UIItems.WPFUIItems; //add this using allows one use Get and GetMultiple methods on any UIItem
	namespace White.Core.UIItems.ListBoxItems
	{
	  [TestFixture]
	  public class UseExpanderControlTest
	  {
	    [Test]
	    public void Sample()
	    {
	      // code to get the window object
	      var expander = window.Get<GroupBox>("expander1"); //Expander control is really a GroupBox
	      var buttonToExpand = expander.Get<Button>("expanderButton1");
	      buttonToExpand.Click();
	    }
	  }
	}

It is recommended you create an abstraction for your expander. Since its structure is not a standard, white cannot provide the same.
