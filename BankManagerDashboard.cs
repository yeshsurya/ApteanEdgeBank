using System;
using System.Windows.Forms;

namespace ApteanEdgeBank
{
    public partial class BankManagerDashboard : Form
    {
        public BankManagerDashboard()
        {
            InitializeComponent();
        }

        private void listCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ListOfCustomers();
            // this.Hide();
            nextForm.ShowDialog();
            // this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cnc = new CreateNewCustomer();
            // this.Hide();
            cnc.ShowDialog();
            // this.Close();
        }

        private void sortByCustomerIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newForm = new ListOfCustomers(false); // false for sorting by CustomerID
            newForm.ShowDialog();
        }

        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ListOfCustomers(true); // true to sort by Name
            nextForm.ShowDialog();
        }

        private void viewCustomerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ViewCustomerProfile();
            nextForm.ShowDialog();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
            var nextForm = new NewAccount();
            nextForm.ShowDialog();
        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ListAccountDetails();
            nextForm.ShowDialog();
        }

        private void closeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new CloseAccount();
            nextForm.ShowDialog();
        }

        private void reOpenAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ReOpenAccount();
            nextForm.ShowDialog();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new Deposit();
            nextForm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new Update_Customer_Profile();
            nextForm.ShowDialog();
        }

        private void readCustomerAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ReadCustomerAccountList();
            nextForm.ShowDialog();
        }

        private void withDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new Withdraw();
            nextForm.ShowDialog();
        }

        private void addAccountActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void readAccountActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new ReadAccountActivity();
            nextForm.Show();
        }

        private void calculateAccountBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new CalculateAccountBalance();
            nextForm.Show();
        }

        private void showBankBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nextForm = new BankAccountBalance();
            nextForm.Show();
        }
    }
}
