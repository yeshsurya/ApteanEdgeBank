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
    public partial class Update_Customer_Profile : Form
    {
        UserDAO dataAccess = new UserDAO();
        DataTable dataTable = new DataTable();
        DataTable dataTable_selected = new DataTable();
         
        
        public Update_Customer_Profile()
        {
            try
            {
                InitializeComponent();
                dataTable.Clear();
                dataTable = dataAccess.GetData("use ApteanEdgeBank select * from Customer", UserDAO.connectionString);
                dataGridView1.DataSource = bindingSource1;
                bindingSource1.DataSource = dataTable;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {  dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataTable.Clear();
                dataGridView1.DataSource = bindingSource1;

                dataTable = dataAccess.GetData("use ApteanEdgeBank select * from Customer", UserDAO.connectionString);
                bindingSource1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void Update_Customer_Profile_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Event for cell mouse click

           // MessageBox.Show("Cell Mouse Click Invoked");
            
            Point count = dataGridView1.CurrentCellAddress;
            int countt=count.Y;
            dataTable_selected = dataAccess.GetData("use ApteanEdgeBank select * from Customer where CustomerID=1233+"+countt.ToString(), UserDAO.connectionString);
            
           
          //  MessageBox.Show(countt.ToString());


            EditCustomerProfile nextForm = new EditCustomerProfile();
            nextForm.customerID = dataTable_selected.Rows[countt]["CustomerID"].ToString();
          // MessageBox.Show(nextForm.customerID);
            nextForm.firstName = dataTable_selected.Rows[countt]["FirstName"].ToString();
            nextForm.middleName = dataTable_selected.Rows[countt]["MiddleName"].ToString();
            nextForm.lastName = dataTable_selected.Rows[countt]["LastName"].ToString();
            nextForm.dateOfBirth = dataTable_selected.Rows[countt]["DateOfBirth"].ToString();
                
            //nextForm.customerID=dataTable
            nextForm.ShowDialog();

        }
    }
}
