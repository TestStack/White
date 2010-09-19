using System;
using System.Windows.Forms;
using SampleApplication.Domain;

namespace SampleApplication
{
    public partial class CreateCustomerStep2 : Form
    {
        private readonly Customer customer;

        public CreateCustomerStep2()
        {
            InitializeComponent();
            submitButton.Click += SubmitButtonClicked;
        }

        public CreateCustomerStep2(Customer customer) : this()
        {
            this.customer = customer;
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            customer.PhoneNumber = phoneNumberTextBox.Text;
            DataStore.Customers.Add(customer);
            Close();
        }
    }
}