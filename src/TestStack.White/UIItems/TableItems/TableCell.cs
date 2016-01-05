using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UIItems.TableItems
{
    //BUG There is better support for ComboBox cells, try it out
    public class TableCell : UIItem
    {
        protected TableCell() {}
        public TableCell(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        //BUG: Document use of TableCell.Value method
        //BUG: Fix table which doesn't have header in it
        public virtual object Value
        {
            get
            {
                object value = Property(ValuePattern.ValueProperty);
                return UIItemIdAppXmlConfiguration.Instance.TableCellNullValue.Equals(value) ? string.Empty : value;
            }
            set
            {
                actionListener.ActionPerforming(this);
                var valuePattern = GetPattern<ValuePattern>();
                if (value is string)
                {
                    Click();
                    valuePattern.SetValue(string.Empty);
                    keyboard.Send((string) value, actionListener);
                    keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.TAB, actionListener);
                }
                else
                {
                    if (!Value.Equals(value.ToString()))
                    {
                        Click();
                        valuePattern.SetValue(value.ToString());
                    }
                }
            }
        }

        public override void Click()
        {
            GetPattern<InvokePattern>().Invoke();
        }

        public override void RightClick()
        {
            new TooltipSafeMouse(mouse).RightClickOutsideToolTip(this, actionListener);
        }

        public override void DoubleClick()
        {
            new TooltipSafeMouse(mouse).DoubleClickOutsideToolTip(this, actionListener);
        }
    }
}