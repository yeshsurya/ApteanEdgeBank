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
    public partial class LiabilityReadDetailsForm : Form
    {
        public static string connectionString = "Data Source=WS003LT1529PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        SqlConnection conn = null;
        string myQuery = null;
        SqlCommand cmd = null;
        SqlDataReader rdr;

        public LiabilityReadDetailsForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(CustomerIDBox.Text);
            try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    myQuery = "Select * From Liability_Account_New11 where CustomerID =" + CustomerID;
                    cmd = new SqlCommand(myQuery, conn);
                    rdr = cmd.ExecuteReader();

                    bool temp = false;
                    while (rdr.Read())
                    {
                        textBox2.Text = (rdr["AccountID"].ToString());
                        textBox3.Text = (rdr["AccountBalance"].ToString());
                        textBox4.Text = (rdr["Interest"].ToString());
                        temp = true;
                    }

                    if (temp == false)
                    {
                        MessageBox.Show("Result Not Found : Account Does Not Exist!!!");
                    }


                }
                catch(SqlException ex)
                {
                MessageBox.Show("SqlException Exception" +ex.Message);
                }
              catch (NullReferenceException ex)
                {
                    MessageBox.Show("Null Exception" + ex.Message);
                }
              finally
                {
                    conn.Close();
                }


            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
