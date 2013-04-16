using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media;

namespace WpfTestApplication
{
    public class CustomItem : UIElement
    {
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(CustomItem));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(CustomItem));

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(CustomItem));

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Blue, 2.0), new Rect(X, Y, 100.0, 20.0));

            base.OnRender(drawingContext);
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomItemAutiomationPeer(this);
        }
    }
}