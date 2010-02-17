using System.Windows;
using System.Windows.Automation.Peers;

namespace White.WPFCustomControls.Automation
{
    public interface IPeerFactory
    {
        AutomationPeer CreatePeer(FrameworkElement frameworkElement, ICustomCommandDeserializer customCommandDeserializer);
    }
}