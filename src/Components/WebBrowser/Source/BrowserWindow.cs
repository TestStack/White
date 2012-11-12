using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.Sessions;
using White.Core.UIItems.WindowItems;
using White.WebBrowser.Silverlight;

namespace White.WebBrowser
{
    public class BrowserWindow : Win32Window
    {
        private SilverlightDocument silverlightDocument;
        protected BrowserWindow() {}

        public BrowserWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}

        public virtual SilverlightDocument SilverlightDocument
        {
            get
            {
                if (silverlightDocument == null)
                {
                    var finder = new AutomationElementFinder(automationElement);

                    var clock = new Clock(CoreAppXmlConfiguration.Instance.BusyTimeout);
                    Clock.Do perform =
                        () => finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.Window).OfName("Silverlight Control"));
                    Clock.Matched matched = obj => obj != null;
                    Clock.Expired expired =
                        delegate
                            {
                                throw new UIItemSearchException(
                                    string.Format(
                                        "Could not find Silverlight document after waiting for {0}. Timeout value configured by BusyTimeout in White/Core",
                                        CoreAppXmlConfiguration.Instance.BusyTimeout));
                            };
                    var element = (AutomationElement) clock.Perform(perform, matched, expired);

                    silverlightDocument = new SilverlightDocument(element, this, InitializeOption.NoCache, WindowSession);
                }
                return silverlightDocument;
            }
        }
    }
}
