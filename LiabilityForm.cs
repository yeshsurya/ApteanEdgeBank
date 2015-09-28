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
    public partial class LiabilityForm : Form
    {
        Liability Liable = new Liability();
        UserDAO dao = new UserDAO();
        int Customer_ID;
        public LiabilityForm()
        {
            InitializeComponent();
        }

        private void Create_Liability_Account_Click(object sender, EventArgs e)
        {
            Customer_ID = Convert.ToInt32(customerIDBox.Text);
            Liable.createDB(Customer_ID);
        }

        private void Check_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Customer_ID = Convert.ToInt32(customerIDBox.Text);
                Liable.checkID(Customer_ID);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Wrong Format : " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
