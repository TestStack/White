## Making Tests more Readable
Lets start with an example of which creates a customer.

		[Test]
		public void Create()
		{
		    Application application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
		    Window window = application.GetWindow("Dashboard", InitializeOption.NoCache);
		    Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
		    createCustomerLink.Click();
		    Window step1 = application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
		    step1.Get<TextBox>("nameTextBox").BulkText = "Rakesh Kumar";
		    step1.Get<TextBox>("ageTextBox").BulkText = "26";
		    step1.Get<Button>("nextButton").Click();
		    Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
		    step2.Get<TextBox>("phoneNumberTextBox").BulkText = "123213213";
		    step2.Get<Button>("submitButton").Click();
		    application.Kill();
		}

This test works fine. There is slight problem i.e. if the test fails (because application changed e.g.), then the application would remain open after the test. To ensure that it happens we can use NUnit's TearDown method. 
Also If I have to write another test which tests whether I can create a customer without any name or not, I would be doing some of the same things in it. NUnit provides way of extracting these to a method which is executed before and after every test. Lets see how our test looks with that in place
So the example becomes like this.

		Application application;
		Window window;
		
		[SetUp]
		public void SetUp()
		{
		    application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
		    window = application.GetWindow("Dashboard", InitializeOption.NoCache);
		}
		
		[TearDown]
		public void CloseApplication()
		{
		    if (application != null) application.Kill();
		}
		
		[Test]
		public void Create()
		{
		    Window step1 = LaunchCreateCustomer();
		    FillStep1(step1, "Rakesh Kumar", "26");
		    Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
		    step2.Get<TextBox>("phoneNumberTextBox").BulkText = "123213213";
		    step2.Get<Button>("submitButton").Click();
		}
		
		[Test]
		public void CreateCustomer_WithoutName()
		{
		    Window step1 = LaunchCreateCustomer();
		    FillStep1(step1, "Rakesh Kumar", "26");
		    Label messageLabel = step1.Get<Label>("messageLabel");
		    Assert.AreEqual("/Age should be a valid number", messageLabel.Text);
		}
		
		private void FillStep1(Window step1, string name, string age)
		{
		    step1.Get<TextBox>("nameTextBox").BulkText = name;
		    step1.Get<TextBox>("ageTextBox").BulkText = age;
		    step1.Get<Button>("nextButton").Click();
		}
		
		private Window LaunchCreateCustomer()
		{
		    Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
		    createCustomerLink.Click();
		    return application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
		}

Setup method (as it has the SetUpAttribute on it) would be executed before every test. Also common stuff between two tests has been extracted into a method.
From the point of organizing the tests I would put these two tests in a class (TestFixture in NUnit terminology) like CreateCustomerTest.

![RefactoringToUseScreenObjects](../images/ScreenObjects/RefactoringToUseScreenObjects.png)

## Reusing code across different tests
We have written test for create customer. Lets write a test for searching a customer.

		[TestFixture]
		public class SearchCustomerTest : VideoLibraryTest
		{
		    [Test]
		    public void SearchByName()
		    {
		        Window searchWindow = LaunchSearchCustomer();
		        searchWindow.Get<TextBox>("nameTextBox").Text = "Suman";
		        searchWindow.Get<Button>("search").Click();
		        Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);
		    }
		
		    [Test]
		    public void SearchByAge()
		    {
		        Window searchWindow = LaunchSearchCustomer();
		        searchWindow.Get<TextBox>("ageTextBox").Text = "20";
		        searchWindow.Get<Button>("search").Click();
		        Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);            
		    }
		
		    private Window LaunchSearchCustomer()
		    {
		        Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
		        searchCustomerLink.Click();
		        return window.ModalWindow("Search Customer", InitializeOption.NoCache);
		    }
		}

Because the setup and teardown is same in this test and Customer Create Test and most like common to most of the other tests, it is extracted into the base class called VideoLibraryTest, which looks like this.

		public class VideoLibraryTest
		{
		    protected Application application;
		    protected Window window;
		
		    [SetUp]
		    public void SetUp()
		    {
		        application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
		        window = application.GetWindow("Dashboard", InitializeOption.NoCache);
		    }
		
		    [TearDown]
		    public void CloseApplication()
		    {
		        if (application != null) application.Kill();
		    }
		}


Lets write test for Issuing a movie to the customer.
Following test checks issuing movie to an existing customer.

		[TestFixture]
		public class IssueMovieTest : VideoLibraryTest
		{
		    [Test]
		    public void Issue_Movie_To_An_Existing_Customer()
		    {
		        Window searchWindow = LaunchSearchCustomer();
		        searchWindow.Get<TextBox>("nameTextBox").Text = "Suman";
		        searchWindow.Get<Button>("search").Click();
		
		        Hyperlink searchMoviesLink = window.Get<Hyperlink>("searchMovies");
		        searchMoviesLink.Click();
		        
		        Window searchMovieWindow = searchWindow.ModalWindow("Search Movies", InitializeOption.NoCache);
		        searchMovieWindow.Get<TextBox>("nameTextbox").Text = "Taare";
		        searchMovieWindow.Get<Button>("search").Click();
		        searchMovieWindow.Get<Button>("select").Click();
		
		        searchWindow.Get<Button>("ok").Click();
		    }
		
		    private Window LaunchSearchCustomer()
		    {
		        Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
		        searchCustomerLink.Click();
		        return window.ModalWindow("Search Customer", InitializeOption.NoCache);
		    }
		}


This test has a problem. There is code duplication between this test and the SearchCustomer test. The way customer is searched is shared between this test and the SearchCustomerTest. It is quite likely that some other tests might need to do the similar thing. We need to move this code to some common place which can be used between different tests. In other words, and not surprisingly, we need an abstraction here. The question to ask is where does this belong. Following OO principle (creating objects based on real world) we can arrive at objects which represents screens in the application.

Let see how our tests would look after introducing Screen Objects.

## Screen Objects
Our sample application has these screens: Dashboard, SearchCustomer, SearchMovie, CreateCustomerStep1 and CreateCustomerStep2. Lets see how screen objects for these look like.
Dashboard screen does two things. It launches search customer and search movie screens. Hence the DashboardScreen class looks like this:

		public class DashboardScreen
		{
		    private readonly Window window;
		    private readonly Application application;
		
		    public DashboardScreen(Window window, Application application)
		    {
		        this.window = window;
		        this.application = application;
		    }
		
		    public virtual SearchCustomerScreen LaunchSearchCustomer()
		    {
		        Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
		        searchCustomerLink.Click();
		        Window searchCustomerWindow = window.ModalWindow("Search Customer", InitializeOption.NoCache);
		        return new SearchCustomerScreen(searchCustomerWindow, application);
		    }
		
		    public virtual CreateCustomerStep1Screen LaunchCreateCustomer()
		    {
		        Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
		        createCustomerLink.Click();
		        Window step1Window = application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
		        return new CreateCustomerStep1Screen(step1Window, application);
		    }
		}

Similarly SearchCustomerScreen:

		public class SearchCustomerScreen
		{
		    private readonly Window window;
		    private readonly Application application;
		
		    public SearchCustomerScreen(Window window, Application application)
		    {
		        this.window = window;
		        this.application = application;
		    }
		
		    public virtual int Search(string name, string age)
		    {
		        window.Get<TextBox>("nameTextBox").Text = name;
		        window.Get<TextBox>("ageTextBox").Text = age;
		        window.Get<Button>("search").Click();
		        return window.Get<Table>("foundCustomers").Rows.Count;
		    }
		}

We have essentially put all the things which happen on a particular screen in corresponding class. These screen classes exposed what you can perform on them.
Using these screen objects, this is how our test looks like.

		[TestFixture]
		public class SearchCustomerTestUsingScreenObjectPattern : VideoLibraryTest
		{
		    [Test]
		    public void SearchByName()
		    {
		        DashboardScreen dashboardScreen = new DashboardScreen(window, application);
		        SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
		        int numberOfCustomers = searchCustomerScreen.Search("Suman", "");
		        Assert.AreEqual(1, numberOfCustomers);
		    }
		
		    [Test]
		    public void SearchByAge()
		    {
		        DashboardScreen dashboardScreen = new DashboardScreen(window, application);
		        SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
		        int numberOfCustomers = searchCustomerScreen.Search("", "20");
		        Assert.AreEqual(1, numberOfCustomers);
		    }
		}

Functional tests (like any other program) should be readable. The intent of test here is lot clearer than when test was dealing with the UIItems on the screen. This is what we have built.

![RefactoringToUseScreenObjects](../images/ScreenObjects/RefactoringToUseScreenObjects1.png)


We have now got to the point where we have written our own Screen Objects. White takes this further!
