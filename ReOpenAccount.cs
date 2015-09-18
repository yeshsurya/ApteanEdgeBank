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
    public partial class ReOpenAccount : Form
    {
        string CustomerID;
        UserDAO dataAccess = new UserDAO();
        DataTable dataTable = new DataTable();
        public ReOpenAccount()
        {
            InitializeComponent();
        }

        private void ReOpenAccount_Load(object sender, EventArgs e)
        {
            dataTable = dataAccess.GetData(@"use ApteanEdgeBank select Customer.FirstName,CustomerAccount.CustomerID,Account.AccountID,Account.AccountType,AccountBalance,Account.DateOfOpening,DateOfClosing
 from Account inner join CustomerAccount
on 
Account.AccountID=CustomerAccount.AccountID
inner join Customer
on
Customer.CustomerID = CustomerAccount.CustomerID
where Account.DateOfClosing is not null", UserDAO.connectionString);
        }

        private void customerIDBox_TextChanged(object sender, EventArgs e)
        {
            CustomerID = customerIDBox.Text;
        }

        private void customerIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToString(dataTable.Rows[i]["CustomerID"]) == CustomerID)
                {
                    listBox1.Items.Add(Convert.ToString(dataTable.Rows[i]["AccountID"]));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectdAccountID = Convert.ToString(listBox1.SelectedItem);
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the account to be ReOpened");
            }
            else
            {
                dataAccess.InsertData(@"use ApteanEdgeBank update Account
set DateOfClosing=null
where AccountID =" + selectdAccountID, UserDAO.connectionString);
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                var ele = listBox1.Items.IndexOf(listBox1.SelectedItem);
                var search = Convert.ToString(listBox1.SelectedItem);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (Convert.ToString(dataTable.Rows[i]["AccountID"]) == search)
                    {
                        label3.Text = "Account Type : " + Convert.ToString(dataTable.Rows[i]["AccountType"]);
                        label4.Text = "Balance :$ " + Convert.ToString(dataTable.Rows[i]["AccountBalance"]);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
