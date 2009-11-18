using System.Windows.Forms;

namespace SampleApplication
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            createCustomer.LinkClicked += CreateCustomerClicked;
            searchCustomer.LinkClicked += SearchCustomers;
            searchMovies.LinkClicked += SearchMovies_OnLinkClicked;
        }

        private void SearchMovies_OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SearchMovies().ShowDialog();
        }

        private void CreateCustomerClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateCustomerStep1 step1 = new CreateCustomerStep1();
            step1.StartPosition = FormStartPosition.CenterParent;
            step1.Show();
        }

        private void SearchCustomers(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SearchCustomer().ShowDialog();
        }
    }
}