using Core.UIItems;
using Core.UIItems.WindowItems;
using Repository;

namespace TestSampleApplication.WhiteScreens
{
    public partial class SearchCustomerScreen : Repository.AppScreen
    {
        private Core.UIItems.Button search;
        private Core.UIItems.Label nameLabel;
        private Core.UIItems.WinFormTextBox nameTextBox;
        private Core.UIItems.WinFormTextBox ageTextBox;
        private Core.UIItems.Label ageLabel;
        private Core.UIItems.TableItems.Table foundCustomers;
        private Core.UIItems.Button deleteButton;
        private Core.UIItems.Hyperlink searchMovies;
        private Core.UIItems.Label selectedMovieLabel;
        private Core.UIItems.Button ok;
        protected SearchCustomerScreen()
        {
        }
        public SearchCustomerScreen(Core.UIItems.WindowItems.Window window, Repository.ScreenRepository screenRepository)
            :
                base(window, screenRepository)
        {
        }
    }

}