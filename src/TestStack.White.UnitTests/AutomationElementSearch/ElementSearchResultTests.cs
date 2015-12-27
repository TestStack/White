using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;

namespace TestStack.White.UnitTests.AutomationElementSearch
{
    [TestFixture]
    public class ElementSearchResultTests
    {
        [Test]
        public void AllResultsFoundForManyTest()
        {
            var result = ElementSearchResult.ForMany();
            Assert.That(result.AllResultsFound, Is.False);
            result.Add(AutomationElement.FocusedElement);
            Assert.That(result.AllResultsFound, Is.False);
        }

        [Test]
        public void AllResultsFoundForOneTest()
        {
            var result = ElementSearchResult.ForOne();
            Assert.That(result.AllResultsFound, Is.False);
            result.Add(AutomationElement.FocusedElement);
            Assert.That(result.AllResultsFound, Is.True);
        }
    }
}