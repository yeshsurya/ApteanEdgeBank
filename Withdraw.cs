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
    public partial class Withdraw : Form
    {
        string CustomerID;
        UserDAO dataAccess = new UserDAO();
        DataTable dataTable = new DataTable();
        public Withdraw()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CustomerID = textBox1.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            loadTable();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (Convert.ToString(dataTable.Rows[i]["CustomerID"]) == CustomerID)
                {
                    listBox1.Items.Add(Convert.ToString(dataTable.Rows[i]["AccountID"]));
                }
            }
        }

        private void loadTable()
        {
            dataTable = dataAccess.GetData(@"use ApteanEdgeBank select Customer.FirstName,CustomerAccount.CustomerID,Account.AccountID,Account.AccountType,AccountBalance,Account.DateOfOpening,DateOfClosing
 from Account inner join CustomerAccount
on 
Account.AccountID=CustomerAccount.AccountID
inner join Customer
on
Customer.CustomerID = CustomerAccount.CustomerID
where Account.DateOfClosing is null", UserDAO.connectionString);
        }

        public string GetAccountType(int accId)
        {
            UserDAO dao = new UserDAO();
            DataTable dt = new DataTable();
            string myQuery = "select * from Account where AccountID=" + accId;
            string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            dt = dao.GetData(myQuery, connectionstring);
            string Type = "";
            if (Convert.ToString(dt.Rows[0]["AccountType"]) == "CA")
            {
                Type = "CA";
                return Type;
            }
            else if (Convert.ToString(dt.Rows[0]["AccountType"]) == "TFS")
            {
                Type = "TFA";
                return Type;
            }
            else if (Convert.ToString(dt.Rows[0]["AccountType"]) == "LA")
            {
                Type = "LA";
                return Type;
            }
            else
            {
                return Type;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Withdraw_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectdAccountID = Convert.ToString(listBox1.SelectedItem);
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select the account to withdraw from");
            }
            else
            {
                /*dataAccess.InsertData(@"use ApteanEdgeBank update Account
set AccountBalance=AccountBalance+"+Convert.ToString(textBox1.Text)+@"where AccountID =" + selectdAccountID, UserDAO.connectionString);*/
                if (GetAccountType(Convert.ToInt32(selectdAccountID)) == "CA")
                {
                    Account A = new ChequingAccount();
                    A.Withdraw(Convert.ToDouble(textBox2.Text), Convert.ToInt32(selectdAccountID));
                    MessageBox.Show("Amount withdraw successfull!");
                }
                else if (GetAccountType(Convert.ToInt32(selectdAccountID)) == "TFS")
                {
                    Account A = new TaxFreeSavingsAccount();
                    A.Withdraw(Convert.ToDouble(textBox2.Text), Convert.ToInt32(selectdAccountID));
                    MessageBox.Show("Amount withdraw successfull!");
                }
                else
                {
                    MessageBox.Show("Amount could not be withdrawn!");
                }
            }

            textBox2.Clear();
        }
    }
}
