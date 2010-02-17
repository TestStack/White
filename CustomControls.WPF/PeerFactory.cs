using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.WPF.Peers;
using White.WPFCustomControls.Automation;

namespace White.CustomControls.WPF
{
    public class PeerFactory : IPeerFactory
    {
        public AutomationPeer CreatePeer(FrameworkElement frameworkElement, ICustomCommandDeserializer customCommandDeserializer)
        {
            if (frameworkElement is Button) return new WhiteWPFButtonPeer((Button) frameworkElement, customCommandDeserializer);
            return null;
        }
    }
}