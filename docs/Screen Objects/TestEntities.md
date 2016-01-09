White supports the concept of Entities in your tests. Entities represent a *thing* in your application. This might be a Customer, and your application might have a new Customer Screen. 

At the moment the communication between screen and test is done by using strings. e.g.

		int numberOfCustomers = searchCustomerScreen.Search("Suman", "");

Lets looks at CreateCustomerTest

		DashboardScreen dashboardScreen = new DashboardScreen(window, application);
		CreateCustomerStep1Screen step1Screen = dashboardScreen.LaunchCreateCustomer();
		step1Screen.FillAndNext("Rakesh Kumar", "26");
		CreateCustomerStep2Screen step2Screen = new CreateCustomerStep2Screen(window, application);
		step2Screen.Fill("34343545");


Where the CreateCustomer screen classes are like this:

		public class CreateCustomerStep1Screen
		{
		    public CreateCustomerStep2Screen FillAndNext(string name, string age)
		    {
		        window.Get<TextBox>("nameTextBox").BulkText = name;
		        window.Get<TextBox>("ageTextBox").BulkText = age;
		        window.Get<Button>("nextButton").Click();
		        Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
		        return new CreateCustomerStep2Screen(step2, application);            
		    }
		}

		public class CreateCustomerStep2Screen
		{
		    public void Fill(string phoneNumber)
		    {
		        window.Get<TextBox>("phoneNumberTextBox").BulkText = phoneNumber;
		        window.Get<Button>("submitButton").Click();
		    }
		}

Name, age and phoneNumber are properties of a customer in our domain. If case of change in properties on customer, we would have to change the signature of the Fill methods on the Step1 and Step2 screen classes. More importantly while reading the test, the fact that we are trying to create a customer is not explicit. This is pretty simple to do though.

Lets create a Customer class which holds all its data.

		public class Customer
		{
		    private readonly string name;
		    private readonly string age;
		    private readonly string phoneNumber;
		
		    public Customer(string name, string age, string phoneNumber)
		    {
		        this.name = name;
		        this.age = age;
		        this.phoneNumber = phoneNumber;
		    }
		
		    public string Name
		    {
		        get { return name; }
		    }
		
		    public string Age
		    {
		        get { return age; }
		    }
		    
		    public string PhoneNumber
		    {
		        get { return phoneNumber; }
		    }
		}

And the screen class would change to:

		public class CreateCustomerStep1Screen
		{
		
		    public CreateCustomerStep2Screen FillAndNext(Customer customer)
		    {
		        window.Get<TextBox>("nameTextBox").BulkText = customer.Name;
		        window.Get<TextBox>("ageTextBox").BulkText = customer.Age;
		        window.Get<Button>("nextButton").Click();
		        Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
		        return new CreateCustomerStep2Screen(step2, application);
		    }
		}

The test now uses the Customer object

		[Test]
		public void Create()
		{
		    DashboardScreen dashboardScreen = new DashboardScreen(window, application);
		    Customer customer = new Customer("Rakesh Kumar", "26", "34343545");
		    CreateCustomerStep1Screen step1Screen = dashboardScreen.LaunchCreateCustomer();
		    step1Screen.FillAndNext(customer);
		    CreateCustomerStep2Screen step2Screen = new CreateCustomerStep2Screen(window, application);
		    step2Screen.Fill(customer);
		}

..and it is slightly more readable than the when we were passing strings. There are larger benefits which we would see in next chapters.

Our current design now looks like this.

![TestEntities](../../img/White/ScreenObjects/TestEntities.png)