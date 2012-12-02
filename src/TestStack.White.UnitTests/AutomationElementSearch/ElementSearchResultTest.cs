using System.Windows.Automation;
using NUnit.Framework;
using White.Core.AutomationElementSearch;

namespace White.Core.UnitTests.AutomationElementSearch
{
    [TestFixture]
    public class ElementSearchResultTest
    {
        [Test]
        public void AllResultsFoundForMany()
        {
            var result = ElementSearchResult.ForMany();
            Assert.AreEqual(false, result.AllResultsFound);
            result.Add(AutomationElement.FocusedElement);
            Assert.AreEqual(false, result.AllResultsFound);
        }

        [Test]
        public void AllResultsFoundForOne()
        {
            var result = ElementSearchResult.ForOne();
            Assert.AreEqual(false, result.AllResultsFound);
            result.Add(AutomationElement.FocusedElement);
            Assert.AreEqual(true, result.AllResultsFound);
        }
    }
}