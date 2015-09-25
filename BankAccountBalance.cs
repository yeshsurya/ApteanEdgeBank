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
    public partial class BankAccountBalance : Form
    {
        public BankAccountBalance()
        {
            InitializeComponent();
        }

        private void BankAccountBalance_Load(object sender, EventArgs e)
        {
            BankGeneralAccount bg = new BankGeneralAccount();
            bg.GetAccountBalance();
            label1.Text = label1.Text + Convert.ToString(bg.bgaBalance);
        }
    }
}
