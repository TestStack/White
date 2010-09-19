using Repository.EntityMapping;

namespace TestSampleApplication.Entities
{
    public class Customer : Entity
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
}