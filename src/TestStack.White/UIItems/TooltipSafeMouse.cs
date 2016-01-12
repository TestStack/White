using System.Threading;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    //TODO this problem can occur on ListView as well
    internal class TooltipSafeMouse
    {
        private readonly Mouse mouse;
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(TooltipSafeMouse));

        public TooltipSafeMouse(Mouse mouse)
        {
            this.mouse = mouse;
        }

        public virtual void RightClickOutsideToolTip(UIItem uiItem, IActionListener actionListener)
        {
            actionListener.ActionPerforming(uiItem);
            ToolTip toolTip = GetToolTip(uiItem, actionListener);
            if (toolTip == null)
            {
                //Because mouse has already been moved
                mouse.Click(MouseButton.Right, actionListener);
            }
            else
            {
                logger.Debug("Found tooltip RightClicking outside tooltip bounds");
                mouse.RightClick(toolTip.LeftOutside(uiItem.Bounds), actionListener);
            }
        }

        public virtual void DoubleClickOutsideToolTip(UIItem uiItem, IActionListener actionListener)
        {
            actionListener.ActionPerforming(uiItem);
            ToolTip toolTip = GetToolTip(uiItem, actionListener);
            if (toolTip == null)
                mouse.LeftDoubleClick(uiItem.Bounds.Center(), actionListener);
            else
            {
                logger.Debug("Found tooltip DoubleClicking outside tooltip bounds");
                mouse.LeftDoubleClick(toolTip.LeftOutside(uiItem.Bounds), actionListener);
            }
        }

        public virtual void ClickOutsideToolTip(UIItem uiItem, IActionListener actionListener)
        {
            actionListener.ActionPerforming(uiItem);
            ToolTip toolTip = GetToolTip(uiItem, actionListener);
            if (toolTip == null)
                mouse.LeftClick(uiItem.Bounds.Center(), actionListener);
            else
            {
                logger.Debug("Found tooltip Clicking outside tooltip bounds");
                mouse.LeftClick(toolTip.LeftOutside(uiItem.Bounds), actionListener);
            }
        }

        private ToolTip GetToolTip(UIItem uiItem, IActionListener actionListener)
        {
            mouse.LeftClick(uiItem.Bounds.Center());
            actionListener.ActionPerformed(Action.WindowMessage);
            Thread.Sleep(CoreAppXmlConfiguration.Instance.TooltipWaitTime);
            return ToolTip.GetFrom(uiItem.Bounds.Center());
        }
    }
}