// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomItem.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the CustomItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTestApplication.Custom_controls
{
    using System.Windows;
    using System.Windows.Automation.Peers;
    using System.Windows.Media;

    /// <summary>
    ///     The custom item.
    /// </summary>
    public class CustomItem : UIElement
    {
        /// <summary>
        ///     The name property.
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.Register(
            "Name", 
            typeof(string), 
            typeof(CustomItem));

        public static readonly DependencyProperty XProperty = DependencyProperty.Register(
            "X", 
            typeof(double), 
            typeof(CustomItem));

        /// <summary>
        ///     The y property.
        /// </summary>
        public static readonly DependencyProperty YProperty = DependencyProperty.Register(
            "Y", 
            typeof(double), 
            typeof(CustomItem));

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }

            set
            {
                this.SetValue(NameProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        public double X
        {
            get
            {
                return (double)GetValue(XProperty);
            }

            set
            {
                SetValue(XProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        public double Y
        {
            get
            {
                return (double)GetValue(YProperty);
            }

            set
            {
                this.SetValue(YProperty, value);
            }
        }

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomItemAutiomationPeer(this);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Blue, 2.0), new Rect(X, Y, 100.0, 20.0));

            base.OnRender(drawingContext);
        }
    }
}