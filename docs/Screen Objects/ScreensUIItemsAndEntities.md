Lets have another look closely at the CreateCustomerStep1Screen's FillAndNext method.

		public virtual CreateCustomerStep2Screen FillAndNext(Customer customer)
		{
		    nameTextBox.BulkText = customer.Name;
		    ageTextBox.BulkText = customer.Age;
		    nextButton.Click();
		    return screenRepository.Get<CreateCustomerStep2Screen>("Create Customer Step2", InitializeOption.NoCache);
		}

In this method we are populating the text boxes with the properties of customer. The information needed to do this already present in textbox variable name and customer field variable name. Which means that we can follow a convention based approach to do this transparently. Before doing this, we have to take care of naming convention, which is specific to AUT. White allows you do this.

The screen code would change to:

		public virtual CreateCustomerStep2Screen FillAndNext_UsingAutomaticPopulate(Customer customer)
		{
		    Populate(new VideoLibraryFieldMap(), customer);
		    nextButton.Click();
		    return screenRepository.Get<CreateCustomerStep2Screen>("Create Customer Step2", InitializeOption.NoCache);
		}

Customer class should extend from Repository.EntityMapping.Entity class.
The Populate method on AppScreen class needs an implementation of FieldMap interface.

		public class VideoLibraryFieldMap : FieldMap
		{
		    public virtual string GetFieldNameFor(string controlName, Type controlType)
		    {
		        if (controlType.IsSubclassOf(typeof(TextBox)) || controlType.Equals(typeof(TextBox)))
		        {
		            return controlName.ToLower().Replace("textbox", string.Empty);
		        }
		        return string.Empty;
		    }
		}

As a practice I would also go ahead and write unit test for above method. The feedback for such unit tests is faster and I can utilize them in future when I want to add more logic to my FieldMap. This is what my unit test would look like:

		[TestFixture]
		public class VideoLibraryFieldMapTest
		{
		    [Test]
		    public void GetFieldNameFor()
		    {
		        VideoLibraryFieldMap fieldMap = new VideoLibraryFieldMap();
		        Assert.AreEqual("name", fieldMap.GetFieldNameFor("nameTextbox", typeof(TextBox)));
		    }
		}
		
**Note:** The entity mapping code is likely to change soon