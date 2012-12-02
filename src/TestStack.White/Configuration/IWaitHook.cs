using White.Core.UIItems;

namespace White.Core.Configuration
{
    public interface IWaitHook
    {
        /// <summary>
        /// This callback would be provided whenever any action is performed using white. This is additional callback apart from regular waits based on window/process being busy.
        /// This provides additional oppurtunity to wait based application specific condition.
        /// </summary>
        /// <param name="uiItemContainer">Container in which action was performed, this applies only if the container explicity handles wait. 
        /// This is also called for window which handles wait. Other than window only SilverlightDocument handles the wait.
        /// In silverlight one would receive two callbacks one with window and other with SilverlightDocument</param>
        void WaitFor(UIItemContainer uiItemContainer);
    }
}