using NUnit.Framework;
using White.Core.UIItems.Finders;

namespace White.Core.AutomationElementSearch
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
            Assert.AreEqual(new AutomationIdCondition("foo"), new AutomationIdCondition("foo"));
            Assert.AreNotEqual(new AutomationIdCondition("foo"), new AutomationIdCondition("foo1"));
            Assert.AreNotEqual(new AutomationIdCondition("foo"), new NameCondition("foo"));
        }
    }
}