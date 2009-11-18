using System;
using System.Windows.Forms;
using SampleApplication.Domain;

namespace SampleApplication
{
    //TODO: Currency can be used to add complexity to app
    public partial class CreateCustomerStep1 : Form
    {
        public CreateCustomerStep1()
        {
            InitializeComponent();
            nextButton.Click += NextButtonClicked;
        }

        private void NextButtonClicked(object sender, EventArgs e)
        {
            messageLabel.Text = string.Empty;
            int age;
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "/Name cannot be empty";
            }
            if (!int.TryParse(ageTextBox.Text, out age))
            {
                messageLabel.Text += "/Age should be a valid number";
            }

            if (!string.IsNullOrEmpty(messageLabel.Text)) return;

            Customer customer = new Customer();
            customer.Name = nameTextBox.Text;
            customer.Age = int.Parse(ageTextBox.Text);
            Close();
            CreateCustomerStep2 step2 = new CreateCustomerStep2(customer);
            step2.StartPosition = FormStartPosition.CenterParent;
            step2.Show();
        }
    }
}