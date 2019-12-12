// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoItem.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the TodoItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Todo.Core
{
    using System;

    /// <summary>
    ///     The to-do item.
    /// </summary>
    public class TodoItem : NotifyPropertyChanged
    {
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the due date.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}