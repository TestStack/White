// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusyAutomationBehaviour.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the BusyAutomationBehaviour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfTodo
{
    using System.Windows;
    using System.Windows.Automation;

    /// <summary>
    /// The busy automation behavior.
    /// </summary>
    public static class BusyAutomationBehaviour
    {
        /// <summary>
        /// The is application busy property.
        /// </summary>
        public static readonly DependencyProperty IsApplicationBusyProperty =
            DependencyProperty.RegisterAttached("IsApplicationBusy", typeof (bool), typeof (BusyAutomationBehaviour), new PropertyMetadata(OnChanged));

        /// <summary>
        /// The set is application busy.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetIsApplicationBusy(DependencyObject element, bool value)
        {
            element.SetValue(IsApplicationBusyProperty, value);
        }

        /// <summary>
        /// The get is application busy.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetIsApplicationBusy(DependencyObject element)
        {
            return (bool) element.GetValue(IsApplicationBusyProperty);
        }

        /// <summary>
        /// The on changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutomationProperties.SetHelpText(d, GetIsApplicationBusy(d) ? "Busy" : string.Empty);
        }
    }
}