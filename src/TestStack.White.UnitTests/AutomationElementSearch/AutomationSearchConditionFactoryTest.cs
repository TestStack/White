using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using Xunit;

namespace White.Core.UnitTests.AutomationElementSearch
{
    public class AutomationSearchConditionFactoryTest
    {
        [Fact]
        public void GetWindowSearchConditionsWhenProcessIdIsValid()
        {
            List<AutomationSearchCondition> conditions = new AutomationSearchConditionFactory().GetWindowSearchConditions(1);
            Assert.Equal(2, conditions.Count);
            Assert.IsType<AndCondition>(conditions[0].Condition);
            Assert.IsType<AndCondition>(conditions[1].Condition);
        }

        [Fact]
        public void GetWindowSearchConditionsWhenProcessIdIsInvalid()
        {
            List<AutomationSearchCondition> conditions = new AutomationSearchConditionFactory().GetWindowSearchConditions(0);
            Assert.Equal(2, conditions.Count);
            Assert.IsType<PropertyCondition>(conditions[0].Condition);
            Assert.IsType<PropertyCondition>(conditions[1].Condition);
        }
    }
}