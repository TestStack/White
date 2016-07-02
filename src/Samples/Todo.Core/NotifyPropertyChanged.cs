// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotifyPropertyChanged.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the NotifyPropertyChanged type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Todo.Core
{
    using System.ComponentModel;

    /// <summary>
    ///     The notify property changed.
    /// </summary>
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        ///     The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     The on property changed.
        /// </summary>
        /// <param name="propertyName">
        ///     The property name.
        /// </param>
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler == null)
            {
                return;
            }

            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }
}