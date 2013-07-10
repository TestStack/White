using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using Xunit;

namespace White.Core.UnitTests.AutomationElementSearch
{
    public class ElementSearchResultTest
    {
        [Fact]
        public void AllResultsFoundForMany()
        {
            var result = ElementSearchResult.ForMany();
            Assert.Equal(false, result.AllResultsFound);
            result.Add(AutomationElement.FocusedElement);
            Assert.Equal(false, result.AllResultsFound);
        }

        [Fact]
        public void AllResultsFoundForOne()
        {
            var result = ElementSearchResult.ForOne();
            Assert.Equal(false, result.AllResultsFound);
            result.Add(AutomationElement.FocusedElement);
            Assert.Equal(true, result.AllResultsFound);
        }
    }
}