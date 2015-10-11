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
        string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";

        public abstract int Create(string accType,DateTime open,double balance);
        public abstract void Deposit(double amount,int accId);
        public void Withdraw(double amount,int accID)
        {
            UserDAO dao=new UserDAO();
            DataTable dt=new DataTable();
            //string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            BankGeneralAccount bg = new BankGeneralAccount();
            dt=dao.GetData("Select AccountBalance from Account where AccountID="+accID,connectionstring);
            Balance=Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
            Balance = Balance - amount;
            if (Balance > 0)
            {
                string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accID;
                
                //UserDAO dao = new UserDAO();
                bg.BgaWithdraw(amount);
                dao.UpdateData(myQuery, connectionstring);
                AccountActivityLedger Ledger = new AccountActivityLedger();
                Ledger.AddAccountActivity(accID, "Withdraw",amount, DateTime.Now);
                MessageBox.Show("Amount withdraw Successful!");

            }
            //string myQuery="up
            else
                MessageBox.Show("Your balance is too low!");
        }
        public static void Close(int accId)
        {
           UserDAO dao=new UserDAO();
            DataTable dt=new DataTable();
            BankGeneralAccount bg = new BankGeneralAccount();
            string queryString="Select * from Account where AccountID="+accId;
            try
            {
                /*Balance = 0;
                dateClosed = DateTime.Now;
                Console.WriteLine("Account closed on {0}", dateClosed.ToShortDateString());*/
                dt = dao.GetData(queryString, UserDAO.connectionString);
                if (Convert.ToDouble(dt.Rows[0]["AccountBalance"]) != 0.0)
                {
                   DialogResult result= MessageBox.Show("Your account balance is greater than 0! The balance must be 0 to close an account. Would you like to clear your account balance?","Account Balance is not 0!",MessageBoxButtons.YesNo);
                   if (result == DialogResult.Yes)
                   {
                       //set closing date for the account. Deduct the remaining balance from bank general account and set the current balance to 0
                       dao.InsertData(@"use ApteanEdgeBank update Account
set DateOfClosing= cast(getdate() as date)
where AccountID =" + accId, UserDAO.connectionString);
                       bg.BgaWithdraw(Convert.ToDouble(dt.Rows[0]["AccountBalance"]));
                       dao.UpdateData("update Account set AccountBalance=0 where AccountID=" + accId, UserDAO.connectionString);
                   }
                }
                else
                {
                    dao.InsertData(@"use ApteanEdgeBank update Account
set DateOfClosing= cast(getdate() as date)
where AccountID =" + accId, UserDAO.connectionString);
                }
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Account closure failed!");
            }
        }

        public static void Reopen(int accId,double reopeningBalance)
        {
            UserDAO dao = new UserDAO();
            DataTable dt = new DataTable();
            BankGeneralAccount bg = new BankGeneralAccount();
            string queryString = "Select * from Account where AccountID=" + accId;
            try
            {
                dao.InsertData(@"use ApteanEdgeBank update Account
set DateOfClosing=null
where AccountID =" + accId, UserDAO.connectionString);
                dao.UpdateData("update Account set AccountBalance=" + reopeningBalance + "where AccountID=" + accId, UserDAO.connectionString);
                bg.BgaDeposit(reopeningBalance);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show("Account reopen failed!");
            }
        }
        
        public bool CheckAccountExistence(int accID)
        {
            UserDAO dao = new UserDAO();
            DataTable accTable = new DataTable();
            string myQuery = "select * from Account where AccountID=" + accID;
            //string connectionstring="Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
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
        string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";

        public override int Create(string accType,DateTime open,double balance)
        {
           /* accountID=ID;
            dateOpened=open;
            Balance=balance;
            Console.WriteLine("Chequing Acoount:");
            Console.WriteLine("Account ID:{0}\nDate Opened:{1}\nBalance:{2}", accountID, dateOpened, Balance);*/

            string myQuery = "insert into Account values("+accType+","+balance+","+"'"+open+"'"+","+"null"+")";
           // string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            BankGeneralAccount bg = new BankGeneralAccount();
            UserDAO dao = new UserDAO();
            dao.InsertData(myQuery, connectionstring);
            bg.BgaDeposit(balance);
            DataTable dataTable = dao.GetData("use ApteanEdgeBank select max(AccountID) as max from Account", UserDAO.connectionString);
            int AccountID = Convert.ToInt32(dataTable.Rows[0]["max"]);
            return AccountID;
            //dao.InsertData("use ApteanEdgeBank insert into CustomerAccount values(" + CustomerID + "," + AccountID + ")", UserDAO.connectionString);
        }
        
        public override void Deposit(double amount,int accId)
    {
        UserDAO dao=new UserDAO();
        DataTable dt=new DataTable();
        //string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        BankGeneralAccount bg = new BankGeneralAccount();
        dt=dao.GetData("Select AccountBalance from Account where AccountID="+accId,connectionstring);
        Balance=Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
        Balance=Balance+amount;
        string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accId;

        //UserDAO dao = new UserDAO();
        dao.UpdateData(myQuery, connectionstring);
        bg.BgaDeposit(amount);
        AccountActivityLedger Ledger = new AccountActivityLedger();
        Ledger.AddAccountActivity(accId, "Deposit", amount, DateTime.Now);
    }

        // To make sure that only one account of each type exists
        public bool DoesChequingAccountExist(int customerID)
        {
            UserDAO dao = new UserDAO();
            DataTable customerAccounts = new DataTable();
            int chequingAccount = 0;
            string query = "Select * from Account where AccountID in (select AccountID from CustomerAccount where CustomerID=" + customerID + ")";
            //string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            customerAccounts = dao.GetData(query, connectionstring);
            foreach (DataRow row in customerAccounts.Rows)
            {
                if (Convert.ToString(row["AccountType"]) == "CA")
                {
                    chequingAccount++;
                }
            }
            if (chequingAccount == 0)//if there is no chequing account for customer
            {
                return false;//there is no CA for this customer
            }

            return true;//this customer already has a chequing account
        }

    }

    public class TaxFreeSavingsAccount:Account    
    {
        string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
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
               // string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
                BankGeneralAccount bg = new BankGeneralAccount();
                UserDAO dao = new UserDAO();
                dao.InsertData(myQuery, connectionstring);
                bg.BgaDeposit(balance);
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
        //string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        BankGeneralAccount bg = new BankGeneralAccount();
        dt = dao.GetData("Select AccountBalance from Account where AccountID=" + accID, connectionstring);
        Balance = Convert.ToDouble(dt.Rows[0]["AccountBalance"]);
        if ((Balance + amount) <= 5000)
        {

            Balance = Balance + amount;
            string myQuery = "Update Account set AccountBalance=" + Balance + " where AccountID="+accID;

            //UserDAO dao = new UserDAO();
            dao.UpdateData(myQuery, connectionstring);
            bg.BgaDeposit(amount);
            AccountActivityLedger Ledger = new AccountActivityLedger();
            Ledger.AddAccountActivity(accID, "Deposit", amount, DateTime.Now);
            MessageBox.Show("Amount deposited successfully!");
        }

        else
        {
            MessageBox.Show("Balance greater than limit!");
        }
            
    }

        public bool DoesTFSAccountExist(int customerID)
        {
            UserDAO dao = new UserDAO();
            DataTable customerAccounts = new DataTable();
            int TFSAccount = 0;
            string query = "Select * from Account where AccountID in (select AccountID from CustomerAccount where CustomerID=" + customerID + ")";
           // string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            customerAccounts = dao.GetData(query, connectionstring);
            foreach (DataRow row in customerAccounts.Rows)
            {
                if (Convert.ToString(row["AccountType"]) == "TFS")
                {
                    TFSAccount++;
                }
            }
            if (TFSAccount == 0)//if there is no TFS account for customer
            {
                return false;//there is no TFS for this customer
            }

            return true;//this customer already has a TFS account
        }
       

    }
}
