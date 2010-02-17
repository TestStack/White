using System.Windows;
using System.Windows.Automation.Peers;

namespace White.CustomControls.Automation
{
    public interface IPeerFactory
    {
        AutomationPeer CreatePeer(FrameworkElement frameworkElement, ICustomCommandDeserializer customCommandDeserializer);
    }
}