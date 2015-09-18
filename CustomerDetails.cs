using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ApteanEdgeBank
{
    public partial class CustomerDetails : Form
    {
        DataTable dt1 = new DataTable();
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UserDAO udao = new UserDAO();
            udao.getConnection();
            //string myQuery;
            
            //dt1 = GetData("Select FirstName, LastName from Person.Person");
            //dataGridView1.DataSource = bindingSource1;
            //bindingSource1.DataSource = dt1; 

        }
        public DataTable GetData(string myQuery)
        {
            //create connection
            SqlConnection myConnection = new SqlConnection(UserDAO.connectionString);

            //Create the command and tell you will provide a SQL query
            SqlCommand cmd = new SqlCommand(myQuery, myConnection);

            //create adapter
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

            //open the connection
            myConnection.Open();

            //fill data in command
            myAdapter.Fill(dt1);

            //close the connection
            myConnection.Close();

            //return the dataTable
            return dt1;
        }

    }
}
