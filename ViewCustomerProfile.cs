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
    public partial class ViewCustomerProfile : Form
    {
        public ViewCustomerProfile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int res;
            if(textBox1.Text.Length==0)
                MessageBox.Show("Please enter the Customer ID");
            if(textBox1.Text.Length!=4)
                MessageBox.Show("Invalid Customer ID");
            if(!int.TryParse(textBox1.Text,out res))
            {
                MessageBox.Show("Only Digits are allowed");
            }
            if(!(int.Parse(textBox1.Text)>=1233))
            {
               MessageBox.Show("Invalid Customer ID");
            }
            UserDAO user = new UserDAO();
            DataTable dataTable = new DataTable ();
            dataTable = user.GetData("use ApteanEdgeBank select * from customer where CustomerID=" + textBox1.Text,UserDAO.connectionString);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No records Found");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDAO user = new UserDAO();
            DataTable dataTable = new DataTable();
            dataTable = user.GetData("use ApteanEdgeBank select * from customer where FirstName=" + "'"+textBox2.Text+"'", UserDAO.connectionString);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No records Found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserDAO user = new UserDAO();
            DataTable dataTable = new DataTable();
            dataTable = user.GetData("use ApteanEdgeBank select * from customer where LastName=" + "'" + textBox3.Text + "'", UserDAO.connectionString);
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No records Found");
            }
        }
    }
}
