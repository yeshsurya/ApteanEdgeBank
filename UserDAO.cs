using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ApteanEdgeBank
{
    class UserDAO
    {
        public static string connectionString = "Data Source=WS003LT1553PRD;Initial Catalog=ApteanEdgeBank;User=sa;Password=abc-123";
        SqlConnection conn = null;
        string myQuery = null;
        SqlCommand cmd = null;
       // SqlDataReader resultSet = null;
        
        DataTable dt = new DataTable();

        public void getConnection()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                System.Windows.Forms.MessageBox.Show("Connection Successfull");
                
            }
            catch (SqlException e )
            {

                System.Windows.Forms.MessageBox.Show("Exception"+e);
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
                System.Windows.Forms.MessageBox.Show("General Exception"+e);
            }


            return dt;
        }   // returns DataTable containing List of customers FirstName and LastName
        

        public bool AddNewCustomer(string Fname, string Lname, string dateOfBirth) //first and last three are null
        {
           
            try
            {
                
              
               
                myQuery = "use ApteanEdgeBank insert into customer (FirstName,LastName,DateOfJoining,DateOfBirth,MiddleName) values(" +"'"+ Fname + "'"+","+"'" + Lname +"'"+ "," + "cast(getdate() as date)" + "," +"'"+ dateOfBirth+"'" + ")"; //insert into Customer (FirstName,LastName,DateOfJoining,DateOfBirth)

                InsertData(myQuery, connectionString);

               
               

               
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Sql Exception"+ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("General Exception" + ex.Message);
                return false;
            }
            return true;
        }


        public DataTable GetData(string myQuery,string connectionString)   // data returned for the myQery will be returned as a DataTable
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

        public void UpdateData(string myQuery, string connectionString)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(connectionString);
                
                //Create the command and tell you will provide a SQL query
                SqlCommand cmd = new SqlCommand(myQuery, myConnection);
                //create adapter
                //int rows = cmd.ExecuteNonQuery();
              // SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                
                //open the connection
                myConnection.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show(rows + " Rows affected");
                }
                else
                {
                    MessageBox.Show("Update unsuccessful!");
                }
                //fill data in command
               //myAdapter.Fill(dt);

                //close the connection
                myConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


    }
}
