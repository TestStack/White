using NUnit.Framework;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UnitTests.AutomationElementSearch
{
    [TestFixture]
    public class SearchConditionTests
    {
        [Test]
        public void TestToString()
        {
            const string name = "blah";
            string str = AutomationSearchCondition.ByName(name).ToString();
            Assert.That(str, Does.Contain(name));
        }

        [Test]
        public void EqualsTests()
        {
            Assert.That(SearchConditionFactory.CreateForAutomationId("foo"), Is.EqualTo(SearchConditionFactory.CreateForAutomationId("foo")));
            Assert.That(SearchConditionFactory.CreateForAutomationId("foo"), Is.Not.EqualTo(SearchConditionFactory.CreateForAutomationId("foo1")));
            Assert.That(SearchConditionFactory.CreateForAutomationId("foo"), Is.Not.EqualTo(SearchConditionFactory.CreateForName(("foo"))));
        }
    }
}