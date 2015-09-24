using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ListOfCustomers nextForm = new ListOfCustomers();
           // this.Hide();
            nextForm.ShowDialog();
           // this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_New_Customer cnc =new  Create_New_Customer();
           // this.Hide();
            cnc.ShowDialog();
           // this.Close();
        }

        private void sortByCustomerIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListOfCustomers newForm = new ListOfCustomers(false); // false for sorting by CustomerID
            newForm.ShowDialog();

        }

        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListOfCustomers nextForm = new ListOfCustomers(true);  // true to sort by Name
            nextForm.ShowDialog();
            
        }

        private void viewCustomerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCustomerProfile nextForm = new ViewCustomerProfile();
            nextForm.ShowDialog();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
            NewAccount nextForm = new NewAccount();
            nextForm.ShowDialog();

        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAccountDetails nextForm = new ListAccountDetails();
            nextForm.ShowDialog();
        }

        private void closeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAccount nextForm = new CloseAccount();
            nextForm.ShowDialog();
        }

        private void reOpenAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReOpenAccount nextForm = new ReOpenAccount();
            nextForm.ShowDialog();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit nextForm = new Deposit();
            nextForm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Customer_Profile nextForm = new Update_Customer_Profile();
            nextForm.ShowDialog();
        }

        private void readCustomerAccountListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReadCustomerAccountList nextForm = new ReadCustomerAccountList();
            nextForm.ShowDialog();
        }

        private void withDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw nextForm = new Withdraw();
            nextForm.ShowDialog();
        }
    }
}
