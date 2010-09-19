using System.Collections.Generic;
using Core;
using Core.Factory;
using Core.UIItems;
using Core.UIItems.TableItems;
using Core.UIItems.WindowItems;
using TestSampleApplication.Entities;

namespace TestSampleApplication.Screens
{
    public class SearchCustomerScreen
    {
        private readonly Window window;
        private readonly Application application;

        public SearchCustomerScreen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public virtual int Search(string name, string age)
        {
            NameTextBox().Text = name;
            window.Get<TextBox>("ageTextBox").Text = age;
            window.Get<Button>("search").Click();
            return window.Get<Table>("foundCustomers").Rows.Count;
        }

        public virtual List<Customer> Search(CustomerSearchCriteria criteria)
        {
            NameTextBox().Text = criteria.Name;
            window.Get<TextBox>("ageTextBox").Text = criteria.Age;
            window.Get<Button>("search").Click();
            TableRows rows = window.Get<Table>("foundCustomers").Rows;
            List<Customer> foundCustomers = new List<Customer>();
            rows.ForEach(delegate(TableRow obj)
                             {
                                 TableCells cells = obj.Cells;
                                 Customer customer = new Customer(cells["Name"].Value.ToString(), cells["Age"].Value.ToString(), cells["PhoneNumber"].Value.ToString());
                                 foundCustomers.Add(customer);
                             });
            return foundCustomers;
        }

        private TextBox NameTextBox()
        {
            return window.Get<TextBox>("nameTextBox");
        }

        public virtual SearchMovieScreen SearchMovies()
        {
            Hyperlink searchMoviesLink = window.Get<Hyperlink>("searchMovies");
            searchMoviesLink.Click();
            Window searchMovieWindow = window.ModalWindow("Search Movies", InitializeOption.NoCache);
            return new SearchMovieScreen(searchMovieWindow, application);
        }

        public virtual void Issue()
        {
            window.Get<Button>("ok").Click();
        }
    }
}