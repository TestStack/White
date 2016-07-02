// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewTaskScreen.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the NewTaskScreen type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo.UITests.Screens
{
    using System;
    using System.Windows.Automation;

    using TestStack.White.ScreenObjects;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;

    /// <summary>
    ///     The new task screen.
    /// </summary>
    public class NewTaskScreen : Screen
    {
        /// <summary>
        ///     The create button.
        /// </summary>
        private readonly Button createButton = null;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewTaskScreen" /> class.
        /// </summary>
        /// <param name="window">
        ///     The window.
        /// </param>
        /// <param name="screenRepository">
        ///     The screen repository.
        /// </param>
        public NewTaskScreen(Window window, ScreenRepository screenRepository)
            : base(window, screenRepository)
        {
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public virtual string Description
        {
            get
            {
                return Window.Get<TextBox>("Description").Text;
            }

            set
            {
                Window.Get<TextBox>("Description").Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the due date.
        /// </summary>
        public virtual DateTime DueDate
        {
            get
            {
                var uiItem = Window.Get(SearchCriteria.ByAutomationId("DueDate"));
                var currentPropertyValue = uiItem.AutomationElement.GetCurrentPropertyValue(ValuePattern.ValueProperty);
                return (DateTime)currentPropertyValue;
            }

            set
            {
                var uiItem = Window.Get(SearchCriteria.ByAutomationId("DueDate"));
                uiItem.Enter(value.ToShortDateString());
            }
        }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public virtual string Title
        {
            get
            {
                return Window.Get<TextBox>("Title").Text;
            }

            set
            {
                Window.Get<TextBox>("Title").Text = value;
            }
        }

        /// <summary>
        ///     The create.
        /// </summary>
        public virtual void Create()
        {
            this.createButton.Click();
            this.WaitWhileBusy();
        }
    }
}