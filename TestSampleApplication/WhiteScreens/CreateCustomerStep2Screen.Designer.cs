using Core.UIItems;
using Core.UIItems.WindowItems;
using Repository;

namespace TestSampleApplication.WhiteScreens
{
    public partial class CreateCustomerStep2Screen : AppScreen
    {
        private WinFormTextBox phoneNumberTextBox = null;
        private Button submitButton = null;
        protected CreateCustomerStep2Screen() {}
        public CreateCustomerStep2Screen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}
    }
}