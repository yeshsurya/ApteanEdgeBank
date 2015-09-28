using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApteanEdgeBank
{
    class Liability : ILiability_CheckID, ILiability_CreateDB, ILiability_IssueLoan_Cash, ILiability_IssueLoanAccount
    {
        UserDAO dao = new UserDAO();
        public int checkID(int CustomerID)
        {
            int d = dao.Check_Customer_Id(CustomerID);

            if (d != 0)
            {
                System.Windows.Forms.MessageBox.Show("Customer Exist");
            }
            else
                System.Windows.Forms.MessageBox.Show("First Add Customer Details");

            return d;
        }

        public bool createDB(int CustomerID)
        {
           
            int d = dao.Check_Customer_Id(CustomerID);

            if (d != 0)
            {
                int? y = dao.Check_Liable_Account(CustomerID);

                if (y == 0)
                {
                    bool b = dao.Add_New_Liable_Customer(CustomerID);
                    System.Windows.Forms.MessageBox.Show("Data Added successfully");
                    return b;
                    
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Account Already Exist");
                    return false;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("First Add Customer Details");
                return false;
            }
        }

        public double issueLoan(int accountID, float amount)
        {
            float x = dao.Check_Account_Liable(accountID);
        
            
            if (x == 1)
            {
                bool b = dao.Add_Amount_LiableAccount(amount, accountID );

                if (b == true)
                {
                    System.Windows.Forms.MessageBox.Show("Data added Successfully");
                }
                else
                    System.Windows.Forms.MessageBox.Show("Data cannot be added");

                return 2;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Data is already added OR some Exception is restricting the data to be added");
                return 0;
            }

        }

        public void issueLoanAccount(int accountID,float amount)
        {
            dao.Issue_Loan_Account(accountID, amount);

        }

    }
}
