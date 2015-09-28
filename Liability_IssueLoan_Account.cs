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
    public partial class Liability_IssueLoan_Account : Form
    {
        public int accountID;
        public Liability_IssueLoan_Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                {
                    accountID = Convert.ToInt32(textBox1.Text);
                }
                else
                    MessageBox.Show("First enter some value");
                this.Close();
            }
            catch(FormatException ex)
            {
                MessageBox.Show("format exception" + ex.Message);
            }
        }
    }
}
