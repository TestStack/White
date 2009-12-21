using NUnit.Framework;
using White.Core;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Finders;

namespace White.UnitTests.Core.AutomationElementSearch
{
    [TestFixture, NormalCategory]
    public class SearchConditionTest
    {
        [Test]
        public void TestToString()
        {
            const string name = "blah";
            string @string = AutomationSearchCondition.ByName(name).ToString();
            Assert.AreEqual(true, @string.Contains(name), @string);
        }

        [Test]
        public void Equals()
        {
            Assert.AreEqual(SearchConditionFactory.CreateForAutomationId("foo"), SearchConditionFactory.CreateForAutomationId("foo"));
            Assert.AreNotEqual(SearchConditionFactory.CreateForAutomationId("foo"), SearchConditionFactory.CreateForAutomationId("foo1"));
            Assert.AreNotEqual(SearchConditionFactory.CreateForAutomationId("foo"), SearchConditionFactory.CreateForName(("foo")));
        }
    }
}