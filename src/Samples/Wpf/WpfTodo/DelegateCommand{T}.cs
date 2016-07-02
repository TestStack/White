// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand{T}.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   A command that calls the specified delegate when the command is executed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo
{
    using System;
    using System.Windows.Input;

    /// <summary>
    ///     A command that calls the specified delegate when the command is executed.
    /// </summary>
    /// <typeparam name="T">The command type.</typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /// <summary>
        ///     The can execute method.
        /// </summary>
        private readonly Func<T, bool> canExecuteMethod;

        /// <summary>
        ///     The execute method.
        /// </summary>
        private readonly Action<T> executeMethod;

        /// <summary>
        ///     The is executing.
        /// </summary>
        private bool isExecuting;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand{T}" /> class.
        /// </summary>
        /// <param name="executeMethod">
        ///     The execute method.
        /// </param>
        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DelegateCommand{T}" /> class.
        /// </summary>
        /// <param name="executeMethod">
        ///     The execute method.
        /// </param>
        /// <param name="canExecuteMethod">
        ///     The execute method flag.
        /// </param>
        protected DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if ((executeMethod == null) && (canExecuteMethod == null))
            {
                throw new ArgumentNullException(nameof(executeMethod), @"Execute Method cannot be null");
            }

            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        /// <summary>
        ///     The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        ///     The can execute.
        /// </summary>
        /// <param name="parameter">
        ///     The parameter.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        public bool CanExecute(T parameter)
        {
            if (this.canExecuteMethod == null)
            {
                return true;
            }

            return this.canExecuteMethod(parameter);
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="parameter">
        ///     The parameter.
        /// </param>
        public void Execute(T parameter)
        {
            this.executeMethod(parameter);
        }

        /// <summary>
        ///     The raise can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        ///     The can execute.
        /// </summary>
        /// <param name="parameter">
        ///     The parameter.
        /// </param>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        bool ICommand.CanExecute(object parameter)
        {
            return !this.isExecuting && this.CanExecute((T)parameter);
        }

        /// <summary>
        ///     The execute.
        /// </summary>
        /// <param name="parameter">
        ///     The parameter.
        /// </param>
        void ICommand.Execute(object parameter)
        {
            this.isExecuting = true;

            try
            {
                this.RaiseCanExecuteChanged();
                this.Execute((T)parameter);
            }
            finally
            {
                this.isExecuting = false;
                this.RaiseCanExecuteChanged();
            }
        }
    }
}