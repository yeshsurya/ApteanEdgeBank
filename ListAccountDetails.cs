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
    public partial class ListAccountDetails : Form
    {
        public ListAccountDetails()
        {
            InitializeComponent();
        }

        private void ListAccountDetails_Load(object sender, EventArgs e)
        {
            UserDAO dataAccess = new UserDAO();
            DataTable dataTable = new DataTable();
            dataTable = dataAccess.GetData(@"use ApteanEdgeBank select Customer.FirstName,CustomerAccount.CustomerID,Account.AccountID,Account.AccountType,AccountBalance,Account.DateOfOpening,DateOfClosing
 from Account inner join CustomerAccount
on 
Account.AccountID=CustomerAccount.AccountID
inner join Customer
on
Customer.CustomerID = CustomerAccount.CustomerID", UserDAO.connectionString);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = dataTable;
        }
    }
}
