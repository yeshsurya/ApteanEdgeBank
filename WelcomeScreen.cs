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
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Bank Manager");
            comboBox1.Items.Add("Bank Employee");
            textBox1.PasswordChar = '*';
            textBox1.Text = "Aptean";
            textBox2.Text = "Aptean";
            comboBox1.Text = "Bank Manager";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Aptean" && textBox2.Text == "Aptean" && comboBox1.SelectedIndex == 0 || comboBox1.Text=="Bank Manager")
            {
                BankManagerDashboard nextForm = new BankManagerDashboard();
                this.Hide();
                nextForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(" Authentication Failed");
            }
           // if (comboBox1.SelectedIndex == 0)
                

        }
    }
}
