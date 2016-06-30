using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace TestStack.White.Factory
{
    public abstract class ChildWindowFactory
    {
        protected readonly AutomationElementFinder Finder;

        protected static readonly List<ISpecializedWindowFactory> SpecializedWindowFactories = new List<ISpecializedWindowFactory>();

        protected ChildWindowFactory(AutomationElementFinder finder)
        {
            Finder = finder;
        }

        /// <summary>
        /// The modal window.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="option">
        /// The option.
        /// </param>
        /// <param name="windowSession">
        /// The window session.
        /// </param>
        /// <returns>
        /// The <see cref="Window"/>.
        /// </returns>
        public virtual Window ModalWindow(string title, InitializeOption option, WindowSession windowSession)
        {
            var message = "Could not find modal window with title: " + title;
            var modalWindowElement = this.WaitTillFound(() => this.Finder.FindWindow(title, 0), message);
            return Create(modalWindowElement, option, windowSession);
        }

        /// <summary>
        /// The modal window.
        /// </summary>
        /// <param name="searchCriteria">
        /// The search criteria.
        /// </param>
        /// <param name="option">
        /// The option.
        /// </param>
        /// <param name="windowSession">
        /// The window session.
        /// </param>
        /// <returns>
        /// The <see cref="Window"/>.
        /// </returns>
        public virtual Window ModalWindow(SearchCriteria searchCriteria, InitializeOption option, WindowSession windowSession)
        {
            var message = "Could not find modal window with SearchCriteria: " + searchCriteria;
            var modalWindowElement = this.WaitTillFound(() => this.Finder.FindWindow(searchCriteria), message);
            return Create(modalWindowElement, option, windowSession);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <param name="option">
        /// The option.
        /// </param>
        /// <param name="windowSession">
        /// The window Session.
        /// </param>
        /// <exception cref="UIItemSearchException">
        /// The application type is not supported by White
        /// </exception>
        /// <returns>
        /// The <see cref="Window"/>.
        /// </returns>
        internal static Window Create(AutomationElement element, InitializeOption option, WindowSession windowSession)
        {
            var specializedWindowFactory = SpecializedWindowFactories.Find(factory => factory.DoesSpecializeInThis(element));
            if (specializedWindowFactory != null)
            {
                return specializedWindowFactory.Create(element, option, windowSession);
            }

            var windowsFramework = WindowsFrameworkExtensions.FromFrameworkId(element.Current.FrameworkId);
            if (windowsFramework == WindowsFramework.WinForms)
            {
                return new WinFormWindow(element, option, windowSession);
            }

            if (windowsFramework == WindowsFramework.Wpf || windowsFramework == WindowsFramework.Xaml)
            {
                return new WPFWindow(element, WindowFactory.Desktop, option, windowSession);
            }

            if (windowsFramework == WindowsFramework.Win32)
            {
                return new Win32Window(element, WindowFactory.Desktop, option, windowSession);
            }

            throw new UIItemSearchException($"{windowsFramework} is not supported yet.");
        }

        /// <summary>
        /// Waits till found.
        /// </summary>
        /// <param name="find">The find function.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        protected virtual AutomationElement WaitTillFound(Func<AutomationElement> find, string message)
        {
            var element = Retry.For(find, CoreAppXmlConfiguration.Instance.FindWindowTimeout());
            if (element == null)
            {
                throw new AutomationException(message, Debug.GetAllWindows());
            }

            return element;
        }
    }
}