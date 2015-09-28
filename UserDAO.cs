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
    public class UserDAO
    {
        public static string connectionString = "Data Source=WS003LT1529PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        SqlConnection conn = null;
        string myQuery = null;
        SqlCommand cmd = null;
       //SqlDataReader resultSet = null;

        DataTable dt = new DataTable();

        public void getConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                System.Windows.Forms.MessageBox.Show("Connection Successfull");

            }
            catch (SqlException e)
            {

                System.Windows.Forms.MessageBox.Show("Exception" + e);
            }

        }      //returns Connection successfull message box on successfull connection


        public DataTable ListCustomers()
        {

            try
            {
                getConnection();
                myQuery = "select FirstName,LastName from Customer order by FirstName ";
                cmd = new SqlCommand(myQuery, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("General Exception" + e);
            }


            return dt;
        }   // returns DataTable containing List of customers FirstName and LastName


        public bool AddNewCustomer(string Fname, string Lname, string dateOfBirth) //first and last three are null
        {

            try
            {
                myQuery = "use ApteanEdgeBank insert into customer (FirstName,LastName,DateOfJoining,DateOfBirth) values(" + "'" + Fname + "'" + "," + "'" + Lname + "'" + "," + "cast(getdate() as date)" + "," + "'" + dateOfBirth + "'" + ")"; //insert into Customer (FirstName,LastName,DateOfJoining,DateOfBirth)
                InsertData(myQuery, connectionString);
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception" + ex.Message);
                return false;
            }
            return true;
        }
        public DataTable GetData(string myQuery, string connectionString)   // data returned for the myQery will be returned as a DataTable
        {
            try
            {
                //create connection
                SqlConnection myConnection = new SqlConnection(connectionString);

                //Create the command and tell you will provide a SQL query
                SqlCommand cmd = new SqlCommand(myQuery, myConnection);

                //create adapter
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                //open the connection
                myConnection.Open();

                //fill data in command
                myAdapter.Fill(dt);

                //close the connection
                myConnection.Close();

                //return the dataTable
                return dt;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
                return dt;

            }


        }
        public void InsertData(string myQuery, string connectionString)
        {
            //create connection
            try
            {
                SqlConnection myConnection = new SqlConnection(connectionString);

                //Create the command and tell you will provide a SQL query
                SqlCommand cmd = new SqlCommand(myQuery, myConnection);

                //create adapter
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);

                //open the connection
                myConnection.Open();

                //fill data in command
                myAdapter.Fill(dt);

                //close the connection
                myConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }

        public int Check_Customer_Id(int CustomID)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myQuery = "Select CustomerID from Customer where CustomerID = " + CustomID;
                cmd = new SqlCommand(myQuery, conn);
                int test = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return test;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("General SQL Exception : " + ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception : " + ex.Message);
                return 0;

            }
            finally
            {
                conn.Close();
            }



        }

        public int Check_Liable_Account(int CustomID)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myQuery = "Select AccountID from Liability_Account_New11 where CustomerID = " + CustomID;
                cmd = new SqlCommand(myQuery, conn);
                int test = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                return test;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
            catch (FormatException ex)
            {
                System.Windows.Forms.MessageBox.Show("wrong format exception : " + ex.Message);
                return 0;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("SQL Exception : " + ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }

        }



        public bool Add_New_Liable_Customer(int customID) //first and last three are null
        {

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myQuery = "use ApteanEdgeBank insert into Liability_Account_New11 (CustomerID) values(" + customID + ")";
                InsertData(myQuery, connectionString);
                float amount = 0.01F;
                myQuery = "use ApteanEdgeBank update Liability_Account_New11 set [AccountBalance]= " + amount + " where CustomerID= " + customID;
                InsertData(myQuery, connectionString);
                return true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception : " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception :" + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool Add_Amount_LiableAccount(float amount, int accountID)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myQuery = "use ApteanEdgeBank update Liability_Account_New11 set [AccountBalance]= " + amount + " where AccountID= " + accountID;
                InsertData(myQuery, connectionString);
              
                double interest;
                interest = amount * .05;
                myQuery = "use ApteanEdgeBank update Liability_Account_New11 set [Interest] =" + interest + " where AccountID= " + accountID;
                InsertData(myQuery, connectionString);

                
                return true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception : " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception :" + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

      //  public 

        public float Check_Account_Liable(int accounttID)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                myQuery = "use ApteanEdgeBank select AccountBalance from Liability_Account_New11 where AccountID =" + accounttID;
                cmd = new SqlCommand(myQuery, conn);
                System.Windows.Forms.MessageBox.Show(cmd.ExecuteScalar().ToString());
                double? test = double.Parse(cmd.ExecuteScalar().ToString());
                

                if(test >1)
                {
                    return 2;
                }
                else
                    return 1;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception : " + ex.Message);
                return 2;
            }
            catch(NullReferenceException ex)
            {
               System.Windows.Forms.MessageBox.Show("Null Exception : " + ex.Message);
                return 2;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception : " + ex.Message);
                return 2;
            }
            finally
            {
                conn.Close();
            }

        }

        public void Issue_Loan_Account(int accountID, float balance)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                DataTable dataTable = new DataTable();
                bool foundFlag = false;
                dataTable = GetData("use ApteanEdgeBank select * from Account", UserDAO.connectionString);
                ListOfCustomers newForm = new ListOfCustomers();
            
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {


                if (Convert.ToString(dataTable.Rows[i]["AccountID"]) == Convert.ToString(accountID))
                {
                    foundFlag = true;
                }

            }
                if ( foundFlag == true)
                {
                    myQuery = "Use ApteanEdgeBank update Account set [AccountBalance] = AccountBalance + " + balance + " where AccountID= " + accountID;
                    InsertData(myQuery, connectionString);
                }
                
                    
            }
            catch(SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception : " + ex.Message);
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception :" + ex.Message);
               
            }
            finally
            {
                conn.Close();
            }

            
        }


        public string CustomID { get; set; }
    }




}
