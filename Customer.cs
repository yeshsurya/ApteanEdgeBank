using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace ApteanEdgeBank
{
    public class Customer
    {
          //int customerID;
         string firstName;
         //string middleName;
         string lastName;
         DateTime dateOfJoining;
         DateTime dateOfBirth;
         string ContactID = null;
        
        
        

        //constructor
        public void AddNewCutomer(string firstNameP,  string lastNameP,DateTime dateOfBirthP)
        {
            firstName = firstNameP;
            //middleName = middleNameP;
            lastName = lastNameP;
            dateOfBirth = dateOfBirthP.Date;
            dateOfJoining = DateTime.Now.Date;
            UserDAO dbAccess = new UserDAO();
            string myQuery = @"use ApteanEdgeBank insert into Customer (FirstName,LastName,DateOfJoining,DateOfBirth) values('" + firstNameP + "'" + "," + "'" + lastNameP + "'" + "," + "cast(getdate() as date)" + "," + "'" + dateOfBirth.Date.ToShortDateString() + "')" ;
           // System.Windows.Forms.MessageBox.Show(myQuery);
            dbAccess.InsertData(myQuery, UserDAO.connectionString);
            //System.Windows.Forms.MessageBox.Show(myQuery);
            System.Windows.Forms.MessageBox.Show("Customer Added successfully");
        }
        public Customer() { }

        public bool CheckCustomerByID(int customerId)
        {
            UserDAO dao = new UserDAO();
            DataTable customerTable = new DataTable();
            string myQuery = "select * from Customer where CustomerID=" + customerId;
            string connectionstring = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
            customerTable = dao.GetData(myQuery, connectionstring);
            if (customerTable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        public bool DoCustomerExists(string Fname, string Lname, string dateOfBirth)  // returns true if customer already exists in the database else returns false
        {

            DataTable temp = new DataTable();
            UserDAO dataAccess = new UserDAO();
            string query = "use ApteanEdgeBank select * from Customer";
            temp = dataAccess.GetData(query, UserDAO.connectionString);
            int i = 0;
            for (; i < (temp.Rows.Count); i++)
            {
                if (Fname == (string)temp.Rows[i]["FirstName"] && Lname == (string)temp.Rows[i]["LastName"] && dateOfBirth == Convert.ToString(temp.Rows[i]["DateOfBirth"]))
                    return true;
                else
                    continue;

            }
            return false;

        }
        public void AddContactNumber(string ContactNumber)
        {
            DataTable temp = new DataTable();
            UserDAO dataAccess = new UserDAO();
            Int64? customerID=null;
            string query = "use ApteanEdgeBank select * from Customer";
            temp = dataAccess.GetData(query, UserDAO.connectionString);
            
            int i = 0;
            for (; i < (temp.Rows.Count); i++)
            {
                if (firstName == (string)temp.Rows[i]["FirstName"] && lastName == (string)temp.Rows[i]["LastName"] && dateOfBirth.ToString() == Convert.ToString(temp.Rows[i]["DateOfBirth"]))
                { customerID = (Int64)temp.Rows[i]["CustomerID"]; break; }
                else
                    continue;

            }
            if (customerID != null)
            {
                dataAccess.InsertData("use ApteanEdgeBank insert into CustomerContact (CustomerID) values(" + customerID + ")", UserDAO.connectionString);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Fatal Error: Customer ID not generated ");
            }
            temp.Clear();
            temp = dataAccess.GetData("use ApteanEdgeBank select * from CustomerContact",UserDAO.connectionString);
            i = 0;
            for (; i < (temp.Rows.Count); i++)
            {
                if (customerID == (Int64)temp.Rows[i]["CustomerID"])
                { ContactID = temp.Rows[i]["CustomerContactID"].ToString(); break; }
                else
                    continue;

            }
            if (ContactID != null)
            {
               // System.Windows.Forms.MessageBox.Show(ContactID);
                dataAccess.InsertData("use ApteanEdgeBank insert into CustomerContactDetails (CustomerContactID,CustomerContactNumber) values(" + ContactID + "," + ContactNumber + ")", UserDAO.connectionString);
            }
            else
                System.Windows.Forms.MessageBox.Show("Fatal Error: Contact ID not generated");



        }
        public void AddContactNumber2(string ContactNumber2)
        {
            UserDAO dataAccess = new UserDAO();
            if (ContactID != null)
            {
                // System.Windows.Forms.MessageBox.Show(ContactID);
                dataAccess.InsertData("use ApteanEdgeBank insert into CustomerContactDetails (CustomerContactID,CustomerContactNumber) values(" + ContactID + "," + ContactNumber2 + ")", UserDAO.connectionString);
            }
            else
                System.Windows.Forms.MessageBox.Show("Fatal Error: Contact ID not generated");
        }

    }
}
