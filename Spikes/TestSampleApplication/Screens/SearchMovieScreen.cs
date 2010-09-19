using Core;
using Core.UIItems;
using Core.UIItems.WindowItems;
using TestSampleApplication.Entities;

namespace TestSampleApplication.Screens
{
    public class SearchMovieScreen
    {
        private readonly Window window;
        private Application application;

        public SearchMovieScreen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public void Search(MovieSearchCriteria criteria)
        {
            window.Get<TextBox>("nameTextbox").Text = criteria.Name;
            window.Get<TextBox>("directorTextbox").Text = criteria.Director;
            window.Get<Button>("search").Click();
            window.Get<Button>("select").Click();
        }

        public void Close()
        {
            window.Close();
        }
    }
}