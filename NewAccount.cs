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
    public partial class NewAccount : Form
    {
        public string AccountType = null;
       public int CustomerID = 0;
       //public string initialBalance = null;
       public int AccountID = 0;


        public NewAccount()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length > 4)
            { MessageBox.Show("The customer ID cant exceed 4 Digits"); textBox1.Clear(); }
            char c = e.KeyChar;
            try
            {
                if (!char.IsDigit(c) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (CustomerAvailabilityCheck()) { MessageBox.Show("Customer Found"); }
            else { 
                MessageBox.Show("Customer Not Found, Please Create Customer First");
                button2.Enabled = false;
            }



            }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Delete) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            AccountType = "'CA'";

        }

        private void tfsAccount_CheckedChanged(object sender, EventArgs e)
        {
            AccountType = "'TFS'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustomerAvailabilityCheck())
            {


                CustomerID = Convert.ToInt32(textBox1.Text);
                //AccountID=0;
                if (AccountType == "'CA'")
                {
                    Account A = new ChequingAccount();
                    AccountID=A.Create(AccountType,DateTime.Now, Convert.ToDouble(textBox2.Text));
                    UserDAO udao = new UserDAO();
                    udao.InsertData("use ApteanEdgeBank insert into CustomerAccount values(" + CustomerID + "," + AccountID + ")", UserDAO.connectionString);
                    MessageBox.Show("Account added successfully!");
                }

                else if (AccountType == "'TFS'")
                {
                    Account A = new TaxFreeSavingsAccount();
                    AccountID = A.Create(AccountType, DateTime.Now, Convert.ToDouble(textBox2.Text));
                    UserDAO udao = new UserDAO();
                    udao.InsertData("use ApteanEdgeBank insert into CustomerAccount values(" + CustomerID + "," + AccountID + ")", UserDAO.connectionString);
                    MessageBox.Show("Account added successfully!");
                }
                else
                {
                    MessageBox.Show("Not a Valid account Type");
                }
                /*initialBalance = textBox2.Text;

                MessageBox.Show("Account Type is " + AccountType + "For Customer ID " + CustomerID + " With initial Balance " + initialBalance);
                UserDAO udao = new UserDAO();
                DataTable dataTable = new DataTable();
                udao.InsertData("use ApteanEdgeBank insert into Account (AccountType,AccountBalance,DateOfOpening,DateOfClosing) values(" + AccountType + "," + initialBalance + "," + "cast(getdate() as date),null)", UserDAO.connectionString);
                dataTable = udao.GetData("use ApteanEdgeBank select max(AccountID) as max from Account", UserDAO.connectionString);
                AccountID = Convert.ToString(dataTable.Rows[0]["max"]);*/

                
            }
            else
            {
                MessageBox.Show("Customer Not Fount, Please Create Customer First");
            }
           
        }
        private bool CustomerAvailabilityCheck()
        {
            /*UserDAO udao = new UserDAO();
            DataTable dataTable = new DataTable();
            bool foundFlag = false;
            string customerID = textBox1.Text;
            dataTable = udao.GetData("use ApteanEdgeBank select * from Customer", UserDAO.connectionString);
            ListOfCustomers newForm = new ListOfCustomers();
            
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {


                if (Convert.ToString(dataTable.Rows[i]["CustomerID"]) == customerID)
                {
                    foundFlag = true;
                }

            }
            if (foundFlag)
            {
                 return true;
            }
            else
            {
                 return false;
            }*/

            Customer cus = new Customer();
            if (cus.CheckCustomerByID(Convert.ToInt32(textBox1.Text)))
            {
                return true;
            }
            return false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewAccount_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateOfOpening_ValueChanged(object sender, EventArgs e)
        {

        }
        }
    }

