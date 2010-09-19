using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.Finders
{
    [TestFixture, NormalCategory]
    public class SearchCriteriaAppliesToTest : ControlsActionTest
    {
        [Test]
        public void Applies()
        {
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("buton").AndControlType(typeof(Button));
            IUIItem button = window.Get(searchCriteria);
            Assert.AreEqual(true, searchCriteria.AppliesTo(button.AutomationElement));
            button = window.Get<Button>("launchModal");
            Assert.AreEqual(false, searchCriteria.AppliesTo(button.AutomationElement));
        }
    }
}