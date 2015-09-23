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
    public partial class Create_New_Customer : Form
    {

        Customer nw = new Customer();
        bool validFlag = false;
        int count = 0;
        public Create_New_Customer()
        {
            InitializeComponent();
        }

        private void addTupleButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                        if(firstNameBox.Text.Count()<2 || lastNameBox.Text.Count()<2)
                            throw(new Exception());

                        int years = DateTime.Now.Year - DateTime.Parse(dateOfBirthBox.Text.ToString()).Year;
                        if (checkBox1.Checked == true)
                            years = 18;
                      //  MessageBox.Show(years.ToString());
                        if (years < 18)
                            MessageBox.Show("The age should be atleast 18 years ");
                        else
                            validFlag = true;


                        string FirstName = firstNameBox.Text;
                        string LastName = lastNameBox.Text;
                        //string MiddleName = middleNameBox.Text;
                        string DateOfBirth = dateOfBirthBox.Text;
                        string ContactNumber = contactNumberBox.Text;
                        if (!nw.DoCustomerExists(FirstName, LastName, DateOfBirth))
                        {
                            if (validFlag)
                            {
                                nw.AddNewCutomer(FirstName, LastName, DateTime.Parse(DateOfBirth));
                                nw.AddContactNumber(ContactNumber);
                            }
                            else
                            { MessageBox.Show("Invalid Customer Entry : Please check the entered data fields"); }
                        }
                        else
                        {
                            MessageBox.Show("Customer Already Exists");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + ":Fields can't be null");
                    }
            
            
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            dateOfBirthBox.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            
           // MessageBox.Show(dateOfBirthBox.Text);
        }

        private void Create_New_Customer_Load(object sender, EventArgs e)
        {
            monthCalendar1.Hide();
            button1.Hide();
        }

        private void dateOfBirthBox_TextChanged(object sender, EventArgs e)
        {

            monthCalendar1.Show();
        }

        private void dateOfBirthBox_Click(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void middleNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (firstNameBox.Text.Count() > 20)
            { MessageBox.Show("Length of FirstName can't be greater than 20");
            firstNameBox.Clear();
            }
            if (firstNameBox.Text.Count() == 0)
            {
                MessageBox.Show("Please Enter FirstName");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secondNumber;
            if (count == 0)
            {
                if (contactNumberBox.Text.Count() > 0)
                {
                    MessageBox.Show("Please enter the number in box and press this button");
                    contactNumberBox.Clear();
                    count++;
                }
            }
            else
            {
                secondNumber = contactNumberBox.Text;
                nw.AddContactNumber2(secondNumber);
                MessageBox.Show("Contact Added successfully");
            }
        }

        private void contactNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back && e.KeyChar  !=  (char)Keys.Delete && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            

        }

        private void contactNumberBox_TextChanged(object sender, EventArgs e)
        {
            if (contactNumberBox.Text.Length > 10)
            {
                contactNumberBox.Clear();
                MessageBox.Show("Please Enter valid 10 digit number");
            }

        }

        private void dateOfBirthBox_TabIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void dateOfBirthBox_CursorChanged(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void dateOfBirthBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            monthCalendar1.Show();
        }

        private void dateOfBirthBox_Enter(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }
    }
}
