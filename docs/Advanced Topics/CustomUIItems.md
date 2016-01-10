Fundamentally all UIItems are either elementary (Label, e.g. having no other item in it) or composed of other UI Items. In white there is in-built support for standard UIItems. These are called standard mainly because of their prevalent use and ready availability in development environments.
When we use "third party controls", this might not be enough. Even though these UI Items are still made up of elementary items and can be automated by finding them individually. But we might miss some abstraction while doing this. Also we need build a lot of things in these items ourselves which are already done in white for other items. This is where Custom UI Item would be useful.

Sample code of a Date control which consists of three text boxes for day, month and year. (See the inline comments)

	//Specify the ControlType which corresponds to the top level of Custom UI Item.
	//White needs this when finding this item inside the window.
	[ControlTypeMapping(CustomUIItemType.Pane)]
	public class MyDateUIItem : CustomUIItem
	{
	    // Implement these two constructors. The order of parameters should be same.
	    public MyDateUIItem(AutomationElement automationElement, ActionListener actionListener)
	        : base(automationElement, actionListener)
	    {
	    }
	
	    //Empty constructor is mandatory with protected or public access modifier.
	    protected MyDateUIItem() {}
	
	    //Sample method
	    public virtual void EnterDate(DateTime dateTime)
	    {
	         //Base class, i.e. CustomUIItem has property called Container. Use this find the items within this.
	         //Can also use SearchCriteria for find items
	        Container.Get<TextBox>("day").Text = dateTime.Day.ToString();
	        Container.Get<TextBox>("month").Text = dateTime.Month.ToString();
	        Container.Get<TextBox>("year").Text = dateTime.Year.ToString();
	    }
	}

This is how it can be used.
	MyDateUIItem myDateUIItem = window.Get<MyDateUIItem>("dateOfBirth");
	Assert.AreNotEqual(null, myDateUIItem);
	myDateUIItem.EnterDate(DateTime.Today);

If you have downloaded the source code you can find all of this in CustomItemTest.cs

### What do I need to do when the CustomUIItem type is not specified is not defined in the source code already?
These are the places where you need to make the change.
1. Add your type in CustomUIItemType
1. Add the mapping to UIAutomation ControlType

    mappings[CustomUIItemType.Table] = System.Windows.Automation.ControlType.Table;

### What happens to the extended controls? e.g. I extend TextBox in the code and use MyTextBox.
In such a case the it would remain as TextBox for white.
 
## Subclassing CustomUIItems
 - Since the object has to be constructed by white. You need to define the same constructors in the subclass.
 - The CustomUIItem type attribute should be redefined in the subclass.