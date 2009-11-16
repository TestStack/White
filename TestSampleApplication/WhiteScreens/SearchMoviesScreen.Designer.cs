using Core.UIItems;
using Core.UIItems.WindowItems;
using Repository;

namespace TestSampleApplication.WhiteScreens
{
    public partial class SearchMoviesScreen : Repository.AppScreen
    {
        private Core.UIItems.WinFormTextBox nameTextbox;
        private Core.UIItems.Label nameLabel;
        private Core.UIItems.WinFormTextBox directorTextbox;
        private Core.UIItems.Label directorLabel;
        private Core.UIItems.Button search;
        private Core.UIItems.TableItems.Table foundMovies;
        private Core.UIItems.Button select;
        protected SearchMoviesScreen()
        {
        }
        public SearchMoviesScreen(Core.UIItems.WindowItems.Window window, Repository.ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }
    }
}