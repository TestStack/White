namespace SampleApplication.Domain
{
    public class Customer
    {
        private string name;
        private int age;
        private int id;
        private string phoneNumber;

        public Customer(int id, string name, int age, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.age = age;
            this.id = id;
        }

        public Customer() {}

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        protected bool Equals(Customer customer)
        {
            if (customer == null) return false;
            return id == customer.id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Customer);
        }

        public override int GetHashCode()
        {
            return id;
        }
    }
}