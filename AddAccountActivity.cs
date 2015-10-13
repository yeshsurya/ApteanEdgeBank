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
    public partial class AddAccountActivity : Form
    {
        AccountActivityLedger Ledger = new AccountActivityLedger();
        public AddAccountActivity()
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Ledger.accountID = Convert.ToInt32(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = Convert.ToString(comboBox1.SelectedItem);
            Ledger.transactionType = s;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Delete))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Ledger.CheckAccountExistence(Ledger.accountID))
            {
                Ledger.AddAccountActivity(Ledger.accountID, Ledger.transactionType, Ledger.transactionAmount, Ledger.transactionDate);
                //double newBalance = Ledger.CalculateAccountBalance(Ledger.accountID);
                MessageBox.Show("Traction added successfully!");
                //double newBalance = Ledger.CalculateAccountBalance(Ledger.accountID);
               // label5.Text = label5.Text + newBalance.ToString();
            }
            else
            {
                MessageBox.Show("Account doesnt exist!");
                button1.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy.MM.dd HH:mm";
            Ledger.transactionDate = Convert.ToDateTime(dateTimePicker1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Ledger.transactionAmount = Convert.ToDouble(textBox2.Text);
        }

        private void AddAccountActivity_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double newBalance = Ledger.CalculateAccountBalance(Ledger.accountID);
            label5.Text = label5.Text + newBalance.ToString();
        }
    }
}
