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
    public partial class ListOfCustomers : Form
    {
        DataTable dataTable = new DataTable();
        public BindingSource bindingSource
        {
            set { bindingSource1 = value; }
            get { return bindingSource1; }
        }
       
        public ListOfCustomers()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1; UserDAO uao = new UserDAO();
            
            dataTable = uao.GetData("use ApteanEdgeBank select * from customer", UserDAO.connectionString);
            bindingSource1.DataSource = dataTable;

        }
        public ListOfCustomers(bool flag)  ///true for sort by Name and false for sort by customerID
        {
            if (flag)
            {
                InitializeComponent();
                dataGridView1.DataSource = bindingSource1; UserDAO uao = new UserDAO();
                //DataTable dataTable = new DataTable();
                dataTable = uao.GetData("use ApteanEdgeBank select * from customer order by FirstName", UserDAO.connectionString);
                bindingSource1.DataSource = dataTable;
            }
            else
            {
                InitializeComponent();
                dataGridView1.DataSource = bindingSource1; UserDAO uao = new UserDAO();
                //DataTable dataTable = new DataTable();
                dataTable = uao.GetData("use ApteanEdgeBank select * from customer order by CustomerID", UserDAO.connectionString);
                bindingSource1.DataSource = dataTable;
            }



        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UserDAO uao = new UserDAO();
            //DataTable dataTable = new DataTable();
            dataTable = uao.GetData("use ApteanEdgeBank select * from customer", UserDAO.connectionString);
            bindingSource1.DataSource = dataTable;
            

        }
    }
}
