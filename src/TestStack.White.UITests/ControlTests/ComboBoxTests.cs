using System.Collections.Generic;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class ComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("AComboBox");
            RunTest(CanSelectItem);
        }

        private void CanSelectItem()
        {
            ComboBoxUnderTest.Select("Test2");
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            return AllFrameworks();
        }
    }
}