using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;

namespace TestStack.White.UnitTests.AutomationElementSearch
{
    [TestFixture]
    public class AutomationSearchConditionFactoryTests
    {
        [Test]
        public void GetWindowSearchConditionsWhenProcessIdIsValidTest()
        {
            var conditions = new AutomationSearchConditionFactory().GetWindowSearchConditions(1);
            Assert.That(conditions, Has.Count.EqualTo(2));
            Assert.That(conditions[0].Condition, Is.TypeOf<AndCondition>());
            Assert.That(conditions[1].Condition, Is.TypeOf<AndCondition>());
        }

        [Test]
        public void GetWindowSearchConditionsWhenProcessIdIsInvalidTest()
        {
            var conditions = new AutomationSearchConditionFactory().GetWindowSearchConditions(0);
            Assert.That(conditions, Has.Count.EqualTo(2));
            Assert.That(conditions[0].Condition, Is.TypeOf<PropertyCondition>());
            Assert.That(conditions[1].Condition, Is.TypeOf<PropertyCondition>());
        }
    }
}