namespace WpfTestApplication
{
    public class Person
    {
        public Person(string name, string country, bool alive, string display, string details)
        {
            Name = name;
            Country = country;
            Alive = alive;
            Display = display;
            Details = details;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public bool Alive { get; set; }
        public string Display { get; set; }
        public string Details { get; set; }
    }
}