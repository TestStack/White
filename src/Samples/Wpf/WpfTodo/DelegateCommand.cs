// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the DelegateCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo
{
    using System;

    /// <summary>
    ///     The delegate command.
    /// </summary>
    public class DelegateCommand : DelegateCommand<object>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        public DelegateCommand(Action executeMethod)
            : base(o => executeMethod())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand" /> class.
        /// </summary>
        /// <param name="executeMethod">The execute method.</param>
        /// <param name="canExecuteMethod">The execute method flag.</param>
        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : base(o => executeMethod(), o => canExecuteMethod())
        {
        }
    }
}