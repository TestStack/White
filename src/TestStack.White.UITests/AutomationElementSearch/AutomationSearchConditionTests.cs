using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.AutomationElementSearch
{
	[TestFixture(WindowsFramework.WinForms)]
	[TestFixture(WindowsFramework.Wpf)]
	public class AutomationSearchConditionTests : WhiteUITestBase
	{
		public AutomationSearchConditionTests(WindowsFramework framework)
			 : base(framework)
		{
		}

		[Test]
		public void BothOrConditionsAreFalseTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("X").Condition,
						AutomationSearchCondition.ByName("X").Condition);
			var bothOrConditionsAreFalse = new AutomationSearchCondition(twoConditions);
			bool result = bothOrConditionsAreFalse.Satisfies(button.AutomationElement);
			Assert.That(result, Is.False);
		}
		[Test]
		public void FirstOrConditionIsTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("ButtonWithTooltip").Condition,
						AutomationSearchCondition.ByName("X").Condition);
			var firstOrConditionIsTrue = new AutomationSearchCondition(twoConditions);
			bool result = firstOrConditionIsTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.True);
		}
		[Test]
		public void SecondOrConditionIsTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("X").Condition,
						AutomationSearchCondition.ByName("Button with Tooltip").Condition);
			var secondOrConditionIsTrue = new AutomationSearchCondition(twoConditions);
			bool result = secondOrConditionIsTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.True);
		}
		[Test]
		public void BothOrConditionsAreTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("ButtonWithTooltip").Condition,
						AutomationSearchCondition.ByName("Button with Tooltip").Condition);
			var bothOrConditionsAreTrue = new AutomationSearchCondition(twoConditions);
			bool result = bothOrConditionsAreTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.True);
		}

		[Test]
		public void BothAndConditionsAreFalseTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new AndCondition(
						AutomationSearchCondition.ByAutomationId("X").Condition,
						AutomationSearchCondition.ByName("X").Condition);
			var bothOrConditionsAreFalse = new AutomationSearchCondition(twoConditions);
			bool result = bothOrConditionsAreFalse.Satisfies(button.AutomationElement);
			Assert.That(result, Is.False);
		}
		[Test]
		public void FirstAndConditionIsTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new AndCondition(
						AutomationSearchCondition.ByAutomationId("ButtonWithTooltip").Condition,
						AutomationSearchCondition.ByName("X").Condition);
			var firstAndConditionIsTrue = new AutomationSearchCondition(twoConditions);
			bool result = firstAndConditionIsTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.False);
		}
		[Test]
		public void SecondAndConditionIsTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new AndCondition(
						AutomationSearchCondition.ByAutomationId("X").Condition,
						AutomationSearchCondition.ByName("Button with Tooltip").Condition);
			var secondAndConditionIsTrue = new AutomationSearchCondition(twoConditions);
			bool result = secondAndConditionIsTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.False);
		}
		[Test]
		public void BothAndConditionsAreTrueTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var twoConditions = new AndCondition(
						AutomationSearchCondition.ByAutomationId("ButtonWithTooltip").Condition,
						AutomationSearchCondition.ByName("Button with Tooltip").Condition);
			var bothAndConditionsAreTrue = new AutomationSearchCondition(twoConditions);
			bool result = bothAndConditionsAreTrue.Satisfies(button.AutomationElement);
			Assert.That(result, Is.True);
		}

		[Test]
		public void ComplexOrConditionTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var comboBox = MainWindow.Get<ComboBox>("EditableComboBox");
			var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
			var checkedListBox = MainWindow.Get<ListBox>("CheckedListBox");
			var typeConditions = new OrCondition(
						AutomationSearchCondition.ByControlType(ControlType.Image).Condition,
						AutomationSearchCondition.ByControlType(ControlType.List).Condition);
			var nameOrIdConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("EditableComboBox").Condition,
						AutomationSearchCondition.ByName("CheckedListBoxTests").Condition);
			var complexOrCondition = new AutomationSearchCondition(new OrCondition(typeConditions, nameOrIdConditions));
			bool resultForButton = complexOrCondition.Satisfies(button.AutomationElement);
			bool resultForComboBox = complexOrCondition.Satisfies(comboBox.AutomationElement);
			bool resultForListBox = complexOrCondition.Satisfies(listBox.AutomationElement);
			bool resultForCheckedListBox = complexOrCondition.Satisfies(checkedListBox.AutomationElement);
			Assert.That(resultForButton, Is.False);
			Assert.That(resultForComboBox, Is.True);
			Assert.That(resultForListBox, Is.True);
			Assert.That(resultForCheckedListBox, Is.True);
		}
		[Test]
		public void ComplexAndConditionTest()
		{
			var button = MainWindow.Get<Button>("ButtonWithTooltip");
			var comboBox = MainWindow.Get<ComboBox>("EditableComboBox");
			var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
			var checkedListBox = MainWindow.Get<ListBox>("CheckedListBox");
			var typeConditions = new OrCondition(
						AutomationSearchCondition.ByControlType(ControlType.Button).Condition,
						AutomationSearchCondition.ByControlType(ControlType.ComboBox).Condition);
			var nameOrIdConditions = new OrCondition(
						AutomationSearchCondition.ByAutomationId("ListBoxWithVScrollBar").Condition,
						AutomationSearchCondition.ByName("Button with Tooltip").Condition);
			var complexAndCondition = new AutomationSearchCondition(new AndCondition(typeConditions, nameOrIdConditions));
			bool resultForButton = complexAndCondition.Satisfies(button.AutomationElement);
			bool resultForComboBox = complexAndCondition.Satisfies(comboBox.AutomationElement);
			bool resultForListBox = complexAndCondition.Satisfies(listBox.AutomationElement);
			bool resultForCheckedListBox = complexAndCondition.Satisfies(checkedListBox.AutomationElement);
			Assert.That(resultForButton, Is.True);
			Assert.That(resultForComboBox, Is.False);
			Assert.That(resultForListBox, Is.False);
			Assert.That(resultForCheckedListBox, Is.False);
		}
	}
}