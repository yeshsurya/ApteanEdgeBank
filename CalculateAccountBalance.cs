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
    public partial class CalculateAccountBalance : Form
    {
        public CalculateAccountBalance()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountActivityLedger Ledger = new AccountActivityLedger();
            double accountBalance = Ledger.CalculateAccountBalance(Convert.ToInt32(textBox1.Text));
            label2.Text = label2.Text + Convert.ToString(accountBalance);
        }
    }
}
