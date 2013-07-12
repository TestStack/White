using System.Windows.Automation;
using TestStack.White.WebBrowser.Silverlight;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

namespace TestStack.White.WebBrowser
{
    public class BrowserWindow : Win32Window
    {
        private SilverlightDocument silverlightDocument;
        protected BrowserWindow() { }

        public BrowserWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) { }

        public virtual SilverlightDocument SilverlightDocument
        {
            get
            {
                if (silverlightDocument == null)
                {
                    var finder = new AutomationElementFinder(AutomationElement);

                    var silverlightControl = Retry.For(
                        () =>
                        {
                            var automationSearchCondition = AutomationSearchCondition
                                .ByControlType(ControlType.Window)
                                .OfName("Silverlight Control");

                            return finder.Descendant(automationSearchCondition);
                        },
                        CoreAppXmlConfiguration.Instance.BusyTimeout());

                    if (silverlightControl == null)
                    {
                        var message = string.Format("Could not find Silverlight document after waiting for {0}. " +
                            "Timeout value configured by BusyTimeout in White/Core", CoreAppXmlConfiguration.Instance.BusyTimeout);
                        throw new UIItemSearchException(message);
                    }

                    silverlightDocument = new SilverlightDocument(silverlightControl, this, InitializeOption.NoCache, WindowSession);
                }
                return silverlightDocument;
            }
        }
    }
}
