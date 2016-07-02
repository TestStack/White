// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Action.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the Action type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestStack.White.UIItems.Actions
{
    using System.Collections.Generic;

    using TestStack.White.UIItems.WindowItems;

    /// <summary>
    /// The action.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// The window message.
        /// </summary>
        public static readonly Action WindowMessage = new Action(ActionType.WindowMessage);

        /// <summary>
        /// The scroll.
        /// </summary>
        public static readonly Action Scroll = new Action(ActionType.Scroll);

        /// <summary>
        /// The types.
        /// </summary>
        private readonly List<ActionType> types = new List<ActionType>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="actionTypes">
        /// The action types.
        /// </param>
        public Action(params ActionType[] actionTypes)
        {
            this.types.AddRange(actionTypes);
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        public virtual void Handle(Window window)
        {
            if (window.AutomationElement.Current.FrameworkId != WindowsFramework.Xaml.FrameworkId())
            {
                window.WaitWhileBusy();
            }

            if (this.types.Contains(ActionType.NewControls))
            {
                window.ReloadIfCached();
            }
        }
    }
}