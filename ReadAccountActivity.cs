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
    public partial class ReadAccountActivity : Form
    {
        public ReadAccountActivity()
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
            DataTable activityLog = new DataTable();
            activityLog = Ledger.ReadAccountActivity(Convert.ToInt32(textBox1.Text));
            dataGridView1.DataSource = bindingSource1;
            bindingSource1.DataSource = activityLog;
            if (activityLog.Rows.Count <= 0)
            {
                MessageBox.Show("No Records found!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
