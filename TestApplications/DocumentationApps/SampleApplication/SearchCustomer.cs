using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SampleApplication.Domain;

namespace SampleApplication
{
    public partial class SearchCustomer : Form
    {
        public SearchCustomer()
        {
            InitializeComponent();
            foundCustomers.ReadOnly = true;
            foundCustomers.AllowUserToAddRows = false;
            search.Click += SearchClicked;
            deleteButton.Click += DeleteButton_OnClick;
            searchMovies.LinkClicked += SearchMovies_OnLinkClicked;
        }

        private void DeleteButton_OnClick(object sender, EventArgs e)
        {
            if (foundCustomers.SelectedRows.Count == 0) return;

            Customer selectedCustomer = (Customer) foundCustomers.SelectedRows[0].Tag;
            DataStore.Customers.Remove(selectedCustomer);
        }

        private void SearchClicked(object sender, EventArgs e)
        {
            string nameCriteria = nameTextBox.Text;
            int enteredAge;
            bool ageEntered = int.TryParse(ageTextBox.Text, out enteredAge);
            List<Customer> customers = DataStore.Customers.FindAll(delegate(Customer obj)
                                                                  {
                                                                      return ageEntered && enteredAge.Equals(obj.Age) || 
                                                                             (!string.IsNullOrEmpty(nameCriteria) && obj.Name.Contains(nameCriteria));
                                                                  });
            DisplayCustomers(customers);
        }

        private void DisplayCustomers(List<Customer> customers)
        {
            foundCustomers.Rows.Clear();
            customers.ForEach(delegate(Customer obj)
                                  {
                                      foundCustomers.Rows.Add(obj.Name, obj.Age, obj.PhoneNumber);
                                      foundCustomers.Rows[foundCustomers.Rows.Count - 1].Tag = obj;
                                  });
        }

        private void SearchMovies_OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SearchMovies().ShowDialog();
            if (ApplicationContext.SelectedMovie != null)
                selectedMovie.Text = ApplicationContext.SelectedMovie.Name;
        }
    }
}