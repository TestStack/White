using Core.UIItems;
using Core.UIItems.WindowItems;
using Repository;

namespace TestSampleApplication.WhiteScreens
{
    public partial class Dashboard : Repository.AppScreen
    {
        private Core.UIItems.Hyperlink createCustomer;
        private Core.UIItems.Hyperlink searchCustomer;
        private Core.UIItems.Hyperlink searchMovies;
        protected Dashboard()
        {
        }
        public Dashboard(Core.UIItems.WindowItems.Window window, Repository.ScreenRepository screenRepository)
            :
                base(window, screenRepository)
        {
        }
    }
}