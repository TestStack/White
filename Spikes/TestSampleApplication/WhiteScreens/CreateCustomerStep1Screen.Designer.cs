using Core.UIItems;
using Core.UIItems.WindowItems;
using Repository;

namespace TestSampleApplication.WhiteScreens
{
    public partial class CreateCustomerStep1Screen : AppScreen
    {
        private WinFormTextBox nameTextBox = null;
        private WinFormTextBox ageTextBox = null;
        private Button nextButton = null;
        private Button cancelButton = null;
        
        protected CreateCustomerStep1Screen() {}
        
        public CreateCustomerStep1Screen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}