using System;
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
            textBox_password.PasswordChar = '*';
            textBox_password.Text = @"Aptean";
            textBox_login.Text = @"Aptean";
        }

        private bool DoValidation()
        {
            if (comboBox1.Text.Equals(""))
            {
                MessageBox.Show(@"Please select appropriate Designation", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox_login.Text.Equals("") || textBox_password.Text.Equals(""))
            {
                MessageBox.Show(@"Please check your entered credentials",@"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DoValidation())
            {
                if (textBox_password.Text == @"Aptean" && textBox_login.Text == @"Aptean" && comboBox1.SelectedIndex == 0 ||
                    comboBox1.Text == @"Bank Manager")
                {
                    var nextForm = new BankManagerDashboard();
                    Hide();
                    nextForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show(@"Authentication Failed. ", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

    }
}
