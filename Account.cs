using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApteanEdgeBank
{
    public abstract class Account
    {
        public int accountID;
        public string accountType;
        public DateTime dateOpened;
        public DateTime dateClosed;
        public double Balance;

        public abstract int Create(string accType,DateTime open,double balance);
        public abstract void Deposit(double amount,int accId);
        public void Withdraw(double amount,int accID)
        {
            UserDAO dao=new UserDAO();
            DataTable dt=new DataTable();
            string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            dt=dao.GetData("Select AccountBalance from Account where AccountID="+accID,connectionstring);
            Balance=Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
            Balance = Balance - amount;
            if (Balance > 0)
            {
                string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accID;
                
                //UserDAO dao = new UserDAO();
                dao.UpdateData(myQuery, connectionstring);

            }
            //string myQuery="up
            else
                MessageBox.Show("Your balance is too low!");
        }
        public void Close()
        {
            try
            {
                Balance = 0;
                dateClosed = DateTime.Now;
                Console.WriteLine("Account closed on {0}", dateClosed.ToShortDateString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Balance is greater than 0: {0}", e);
            }
        }
        
        public bool CheckAccountExistence(int accID)
        {
            UserDAO dao = new UserDAO();
            DataTable accTable = new DataTable();
            string myQuery = "select * from Account where AccountID=" + accID;
            string connectionstring="Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            accTable = dao.GetData(myQuery, connectionstring);
            if (accTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

       
    }

    public class ChequingAccount : Account
    {
 
        public override int Create(string accType,DateTime open,double balance)
        {
           /* accountID=ID;
            dateOpened=open;
            Balance=balance;
            Console.WriteLine("Chequing Acoount:");
            Console.WriteLine("Account ID:{0}\nDate Opened:{1}\nBalance:{2}", accountID, dateOpened, Balance);*/

            string myQuery = "insert into Account values("+accType+","+balance+","+"'"+open+"'"+","+"null"+")";
            string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            UserDAO dao = new UserDAO();
            dao.InsertData(myQuery, connectionstring);
            DataTable dataTable = dao.GetData("use ApteanEdgeBank select max(AccountID) as max from Account", UserDAO.connectionString);
            int AccountID = Convert.ToInt32(dataTable.Rows[0]["max"]);
            return AccountID;
            //dao.InsertData("use ApteanEdgeBank insert into CustomerAccount values(" + CustomerID + "," + AccountID + ")", UserDAO.connectionString);
        }
        
        public override void Deposit(double amount,int accId)
    {
        UserDAO dao=new UserDAO();
        DataTable dt=new DataTable();
        string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        dt=dao.GetData("Select AccountBalance from Account where AccountID="+accId,connectionstring);
        Balance=Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
        Balance=Balance+amount;
        string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accId;

        //UserDAO dao = new UserDAO();
        dao.UpdateData(myQuery, connectionstring);
    }

    }

    public class TaxFreeSavingsAccount:Account    
    {
    
        public double Limit;

        public TaxFreeSavingsAccount()
        {
            Limit=5000;
        }

        public override int Create(string accType,DateTime open,double balance)
        {
          if (balance <= Limit)
          {
                
                dateOpened = open;
                Balance = balance;
                string myQuery = "insert into Account values(" + accType + "," + balance + "," + "'" + open + "'" + "," + "null" + ")";
                string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
                UserDAO dao = new UserDAO();
                dao.InsertData(myQuery, connectionstring);
                DataTable dataTable = dao.GetData("use ApteanEdgeBank select max(AccountID) as max from Account", UserDAO.connectionString);
                int AccountID = Convert.ToInt32(dataTable.Rows[0]["max"]);
                return AccountID;
         }

         else
            {
                MessageBox.Show("Balance is greater than limit!");
                return 0;
            } 
        }
        
        public override void Deposit(double amount,int accID)
    {
        UserDAO dao = new UserDAO();
        DataTable dt = new DataTable();
        string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        dt = dao.GetData("Select AccountBalance from Account where AccountID=" + accID, connectionstring);
        Balance = Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
        if ((Balance + amount) < 5000)
        {

            Balance = Balance + amount;
            string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accID;

            //UserDAO dao = new UserDAO();
            dao.UpdateData(myQuery, connectionstring);
        }

        else
        {
            MessageBox.Show("Balance greater than limit!");
        }
            
    }
    }
}
