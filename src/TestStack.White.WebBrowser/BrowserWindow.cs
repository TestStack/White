using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.SystemExtensions;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;
using TestStack.White.WebBrowser.Silverlight;

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
                                .WithName("Silverlight Control");

                            return finder.Descendant(automationSearchCondition);
                        },
                        CoreConfigurationLocator.Get().BusyTimeout.AsTimeSpan());

                    if (silverlightControl == null)
                    {
                        var message = string.Format("Could not find Silverlight document after waiting for {0}. " +
                            "Timeout value configured by BusyTimeout in White/Core", CoreConfigurationLocator.Get().BusyTimeout);
                        throw new UIItemSearchException(message);
                    }

                    silverlightDocument = new SilverlightDocument(silverlightControl, this, InitializeOption.NoCache, WindowSession);
                }
                return silverlightDocument;
            }
        }
    }
}
