using SampleApplication.Domain;

namespace SampleApplication
{
    public class ApplicationContext
    {
        private static Movie selectedMovie;

        public static Movie SelectedMovie
        {
            get { return selectedMovie; }
            set { selectedMovie = value; }
        }
    }
}