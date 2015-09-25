using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ApteanEdgeBank
{
    public class BankGeneralAccount
    {
        public double bgaBalance;

        //constructor

        public BankGeneralAccount()
        { }

        //methods

        public void BgaDeposit( double amt)
        {
            UserDAO dao = new UserDAO();
            DataTable dt = new DataTable();
            string connectionstring = "Data Source=WS003LT1550PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            dt = dao.GetData("Select AccountBalance from BankGeneralAccount where AccountID=1000", connectionstring);
            bgaBalance = Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
            bgaBalance = bgaBalance + amt;
            string myQuery = "Update BankGeneralAccount set AccountBalance=" + bgaBalance + " where AccountID= 1000";

            //UserDAO dao = new UserDAO();
            dao.UpdateData(myQuery, connectionstring);
            
        }

        public void BgaWithdraw(double amt)
        {

            UserDAO dao = new UserDAO();
            DataTable dt = new DataTable();
            string connectionstring = "Data Source=WS003LT1550PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            dt = dao.GetData("Select AccountBalance from BankGeneralAccount where AccountID==1000", connectionstring);
            bgaBalance = Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
            bgaBalance = bgaBalance - amt;
            if (bgaBalance > 0)
            {
                string myQuery = "Update BankGeneralAccount set AccountBalance=" + bgaBalance + " where AccountID= 1000";

                //UserDAO dao = new UserDAO();
                dao.UpdateData(myQuery, connectionstring);

            }
            //string myQuery="up
            else
                System.Windows.Forms.MessageBox.Show("Insufficient Balance in Bank General Account");
        }

        public void Loan(double amt)
        {
            if (amt < bgaBalance)
            {
                bgaBalance = bgaBalance - amt;
                System.Windows.Forms.MessageBox.Show("Loan granted successfully");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Insufficient Balance in Bank General Account");
            }
        }
    }
}
