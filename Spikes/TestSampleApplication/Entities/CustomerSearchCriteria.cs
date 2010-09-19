namespace TestSampleApplication.Entities
{
    public class CustomerSearchCriteria
    {
        private string name = "";
        private string age = "";

        public CustomerSearchCriteria() {}

        public CustomerSearchCriteria(string name, string age)
        {
            this.name = name;
            this.age = age;
        }

#region

        public string Name
        {
            get { return name; }
        }
        public string Age
        {
            get { return age; }
        }

#endregion

#region
        public CustomerSearchCriteria OfName(string name)
        {
            this.name = name;
            return this;
        }

        public CustomerSearchCriteria OfAge(string age)
        {
            this.age = age;
            return this;
        }
#endregion
    }
}