namespace TestSampleApplication.Entities
{
    public class MovieSearchCriteria
    {
        private string name;
        private string director;

        public MovieSearchCriteria(string name, string director)
        {
            this.name = name;
            this.director = director;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Director
        {
            get { return director; }
            set { director = value; }
        }
    }
}