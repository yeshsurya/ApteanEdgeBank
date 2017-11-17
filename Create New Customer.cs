using System;
using System.Linq;
using System.Windows.Forms;

namespace ApteanEdgeBank
{
    public partial class CreateNewCustomer : Form
    {
        private readonly Customer _customer = new Customer();
        private bool _validFlag;
        private int _count;

        public CreateNewCustomer()
        {
            InitializeComponent();
        }

        private bool DoValidation()
        {
            if (TextBoxFirstName.Text.Equals(string.Empty) || TextBoxBirthDate.Text.Equals(string.Empty) ||
                TextBoxLastName.Text.Equals(string.Empty) || TextBoxContactNumber.Text.Equals(string.Empty))
            {
                MessageBox.Show(@"Please fill all the fields", @"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        private void addTupleButton_Click(object sender, EventArgs e)
        {
            var years = DateTime.Now.Year - DateTime.Parse(TextBoxBirthDate.Text).Year;
            if (checkBox1.Checked)
                years = 18;

            try
            {
                if (DoValidation())
                {
                    if (years < 18)
                        MessageBox.Show(@"The age should be atleast 18 years ");
                    else
                        _validFlag = true;


                    var firstName = TextBoxFirstName.Text;
                    var lastName = TextBoxLastName.Text;
                    var dateOfBirth = TextBoxBirthDate.Text;
                    var contactNumber = TextBoxContactNumber.Text;

                    if (!_customer.DoCustomerExists(firstName, lastName, dateOfBirth))
                        if (_validFlag)
                        {
                            _customer.AddNewCutomer(firstName, lastName, DateTime.Parse(dateOfBirth));
                            _customer.AddContactNumber(contactNumber);
                        }
                        else
                        {
                            MessageBox.Show(@"Invalid Customer Entry : Please check the entered data fields");
                        }
                    else
                        MessageBox.Show(@"Customer Already Exists");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Something went wrong. Problem - {ex.Message} ", @"ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) => TextBoxBirthDate.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
        

        private void Create_New_Customer_Load(object sender, EventArgs e)
        {
            monthCalendar1.Hide();
            button1.Hide();
        }

        private void dateOfBirthBox_TextChanged(object sender, EventArgs e) => monthCalendar1.Show();
        
        private void dateOfBirthBox_Click(object sender, EventArgs e) => monthCalendar1.Show();
       

        //never used
       /* private void middleNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxFirstName.Text.Count() > 20)
            {
                MessageBox.Show(@"Length of FirstName can't be greater than 20");
                TextBoxFirstName.Clear();
            }
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            if (_count == 0)
            {
                if (TextBoxContactNumber.Text.Count() > 0)
                {
                    MessageBox.Show("Please enter the number in box and press this button");
                    TextBoxContactNumber.Clear();
                    _count++;
                }
            }
            else
            {
                var secondNumber = TextBoxContactNumber.Text;
                _customer.AddContactNumber2(secondNumber);
                MessageBox.Show(@"Contact Added successfully");
            }
        }

        private void contactNumberBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Back && e.KeyChar != (char) Keys.Delete && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void contactNumberBox_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxContactNumber.Text.Length > 10)
            {
                TextBoxContactNumber.Clear();
                MessageBox.Show(@"Please Enter valid 10 digit mobile number",@"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dateOfBirthBox_TabIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void dateOfBirthBox_CursorChanged(object sender, EventArgs e) => monthCalendar1.Show();

        private void dateOfBirthBox_KeyPress(object sender, KeyPressEventArgs e) => monthCalendar1.Show();

        private void dateOfBirthBox_Enter(object sender, EventArgs e) => monthCalendar1.Show();
    }
}
