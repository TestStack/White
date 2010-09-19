namespace SampleApplication.Domain
{
    public class Movie
    {
        private string name;
        private string director;
        private bool forMinors;

        public Movie(string name, bool forMinors, string director)
        {
            this.name = name;
            this.director = director;
            this.forMinors = forMinors;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool ForMinors
        {
            get { return forMinors; }
            set { forMinors = value; }
        }

        public string Director
        {
            get { return director; }
            set { director = value; }
        }
    }
}