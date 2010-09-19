using System.Collections.Generic;

namespace SampleApplication.Domain
{
    public class DataStore
    {
        private static readonly Customers customers = new Customers();
        private static readonly List<Movie> movies = new List<Movie>();

        static DataStore()
        {
            customers.Add(new Customer(1, "Anil", 25, "988435743"));
            customers.Add(new Customer(2, "Suman", 20, "435435345"));
            customers.Add(new Customer(3, "Raghav", 30, "4534534"));

            movies.Add(new Movie("Sholay", false, "Ramesh Sippy"));
            movies.Add(new Movie("Fire", false, "Deepa Mehta"));
            movies.Add(new Movie("Blue Umbrella", true, "Vishal Bharadwaj"));
            movies.Add(new Movie("Taare Zameen Par", true, "Aamir Khan"));
        }

        public static Customers Customers
        {
            get { return customers; }
        }

        public static List<Movie> Movies
        {
            get { return movies; }
        }
    }
}