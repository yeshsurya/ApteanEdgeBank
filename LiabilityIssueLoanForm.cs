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
    public partial class LiabilityIssueLoanForm : Form
    {
        Liability liable = new Liability();
        float amount;
        int accountID;
        Liability_IssueLoan_Account nextform = new Liability_IssueLoan_Account();
        public LiabilityIssueLoanForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void LiabilityIssueLoanForm_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            accountID = Convert.ToInt32(textBox1.Text);
            amount = Convert.ToInt32(textBox2.Text);
           
            if (radioButton1.Checked)
            {
                double b = liable.issueLoan(accountID, amount);
            }
            else
                if (radioButton2.Checked)
                {
                    nextform.ShowDialog();
                    liable.issueLoanAccount(nextform.accountID, amount);
                    liable.issueLoan(accountID, amount);
                }
                else
                    MessageBox.Show("Choose some options");

               
            
        }

     
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }
