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
    public partial class EditCustomerProfile : Form
    {
        bool validFlag = false;
        public string customerID;
        public string firstName;
        public string middleName;
        public string lastName;
        public string dateOfBirth;
        UserDAO dataAccess =new UserDAO();

        public EditCustomerProfile()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int years = DateTime.Now.Year - DateTime.Parse(dateOfBirthBox.Text.ToString()).Year;
            if (checkBox1.Checked == true)
                years = 18;
            //  MessageBox.Show(years.ToString());
            if (years < 18)
            { }
            else
                validFlag = true;
            firstName=firstNameBox.Text;
            middleName=midddleNameBox.Text;
            lastName=lastNameBox.Text;
            dateOfBirth=dateOfBirthBox.Text;
                
            if (validFlag == true)
            {
                dataAccess.InsertData(@"use ApteanEdgeBank
update Customer
set FirstName='"+firstName+"',"+"MiddleName='"+middleName+"',LastName='"+lastName+"',DateOfBirth='"+dateOfBirth+"'"+
"where CustomerID="+customerID, UserDAO.connectionString);
                MessageBox.Show("Cutomer ID:"+customerID+" updated successfully");
            }
            else
            {
                MessageBox.Show("Invalid Date of Birth");
            }


        }

        private void EditCustomerProfile_Load(object sender, EventArgs e)
        {
            monthCalendar1.Hide();
            firstNameBox.Text = firstName;
            midddleNameBox.Text = middleName;
            lastNameBox.Text = lastName;
            dateOfBirthBox.Text = dateOfBirth;
            label4.Text = "Cutomer ID :" + customerID;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateOfBirthBox.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        }

        private void dateOfBirthBox_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void firstNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Delete) && !(e.KeyChar==(char)Keys.Back)) 
            {
                e.Handled = true;
            }
        }

        private void midddleNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Delete) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void lastNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Delete) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void dateOfBirthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Delete) && !(e.KeyChar == (char)Keys.Back) )
            {
                e.Handled = true;
            }
        }

        private void dateOfBirthBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
