### Pre-requisites
.NET 4.0 framework

## Getting Started
1. Install via NuGet  
`> install-package TestStack.White`
1. Have a look at the [WPF](https://github.com/TestStack/White/tree/master/src/Sample%20App/Wpf) or [WinForms](https://github.com/TestStack/White/tree/master/src/Sample%20App/WinForms) sample projects
1. Have a look at Whites UI Tests, White has automated tests for most controls to prevent regressions in the codebase. These serve as a great example of how to automate different controls. See [White's UI Tests](https://github.com/TestStack/White/tree/master/src/TestStack.White.UITests/ControlTests)
1. Download [http://uiautomationverify.codeplex.com/](http://uiautomationverify.codeplex.com/) which is an ESSENTIAL tool when doing UI Automation work.
1. Start writing tests, first off you require a unit testing framework like xUnit or nUnit. See below for a basic walkthrough
1. Join the mailing list at [https://groups.google.com/forum/#!forum/teststack_white](https://groups.google.com/forum/#!forum/teststack_white)
1. Report issues at [https://github.com/TestStack/White/issues?state=open](https://github.com/TestStack/White/issues?state=open)
1. If you would like to contribute back, read [Contributing](/Contributing.html) to learn how to get started contributing back!

## Writing your first test

### Start off with an empty test stub

In *MSTest*:

    [TestClass]
    public class MyTests
    {
        [TestMethod]
        public void MyFirstUITest()
        {
        }
    }

In *NUnit*:

    [TestFixture]
    public class MyTests
    {
       	[Test]
      	public void MyFirstUITest()
       	{
       	}
    }

In *xUnit*:

    public class MyTests
    {
    	[Fact]
        public void MyFirstUITest()
        {
        }
    }

### Get hold of a window
First you need to determine the correct path of the application you want to test. 

In *MSTest*: 

    var applicationDirectory = TestContext.TestDeploymentDir

In *NUnit*: 

    var applicationDirectory = TestContext.CurrentContext.TestDirectory;

Then you create a new instance of your application

    var applicationPath = Path.Combine(applicationPath, "foo.exe");
    Application application = Application.Launch(applicationPath);  
    Window window = application.GetWindow("bar", InitializeOption.NoCache);

White uses the UI Automation API (UIA) to find controls on a window. UIA communicates to a displayed window via window messages. This find is performed by iterating through all the controls in a window.

### Finding a UI Item and performing action

    Button button = window.Get<Button>("save");
    button.Click();

### Finding a UIItem based on SearchCriteria

    SearchCriteria searchCriteria = SearchCriteria
        	.ByAutomationId("name")
        	.AndControlType(typeof(TextBox))
        	.AndIndex(2);
    TextBox textBox = (TextBox) window.Get(searchCriteria);
    textBox.Text = "Anil";

## Reporting Issues
When reporting issues please include the following information:

 - The target framework (WPF, Winforms etc)
 - The version of White you are using
 - [Recommended] A failing test! **or**
 - [Recommended] A Gist with the code which is failing
 - The more information the better, we accept pull requests with failing tests and pull requests which fix the issue too!
