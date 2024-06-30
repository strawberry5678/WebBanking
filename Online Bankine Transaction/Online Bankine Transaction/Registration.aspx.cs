/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Registration page for the user to enter thier detials 
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Online_Bankine_Transaction.Repo;
using System.Xml.Linq;

namespace Online_Bankine_Transaction
{
    public partial class Registration : System.Web.UI.Page
    {

       SqlConnection con;// Declaration of SqlConnection object
        SqlCommand cmd;// Declaration of SqlCommand object
        SqlDataReader reader;  // Declaration of SqlDataReader object


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // If the page is not being loaded in response to a postback
                lblAccountNumber.Text = displayAccountNumber();// Call to displayAccountNumber method to set account number label text



            }




        }

        // Method to generate the next available account number
        string displayAccountNumber()
        {



            // Establishing connection to the database using the connection string from Common class
            //string con = ConnectionString.BankingConnString.ToString();
            con = new SqlConnection(Common.GetConnectionString());
            // SQL command to select the next available account number by incrementing the maximum existing account number
            cmd = new SqlCommand(@"Select 'ABC20220000' + CAST(  MAX(  CAST(  SUBSTRING(AccountNumber, 12, 50  ) AS INT)) +1 AS VARCHAR)
                        AS AccountNumber from Account", con);


            con.Open();// Opening database connection
            reader =cmd.ExecuteReader(); // Executing SQL command and storing result in SqlDataReader
            string accountNumber = string.Empty;// Initializing account number variable
            while (reader.Read()) // Loop through each record in the result
            {
                accountNumber = reader["AccountNumber"].ToString();// Assigning account number value

            }

            reader.Close();
            con.Close();
            return accountNumber;// Returning the generated account number




        }




       
   

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                // Establishing connection to the database using the connection string from Common class
                con = new SqlConnection(Common.GetConnectionString());
                SqlCommand cmdSelect = new SqlCommand(@"SELECT Username FROM Account WHERE Username = @Username");


                // Adding parameter to SQL command to prevent SQL injection

                cmdSelect.Parameters.AddWithValue("@Username", txtUsername.Text);

                con.Open();
                cmdSelect.Connection = con;
                cmdSelect.ExecuteNonQuery();
                reader = cmdSelect.ExecuteReader();
               

                if (reader.Read()) // If a record with the same username already exists
                {
                    error.InnerText = "User name already exist. ";
                }
                else { 
                    int securityID = ddlSecurityQuestion.SelectedIndex;
                    securityID += 1;

                    con = new SqlConnection(Common.GetConnectionString());
                    cmd = new SqlCommand(@"Insert into Account(AccountNumber, AccountType, Username,Gender,Email,Address,SecurityQuestionId,Answer,Amount,Password) 
                                            values(@AccountNumber, @AccountType, @Username,@Gender,@Email,@Address,@SecurityQuestionId,@Answer, @Amount, @Password)", con);

                    con.Open();
                    // Adding parameters to SQL command to prevent SQL injection
                    cmd.Parameters.AddWithValue("@AccountNumber", lblAccountNumber.Text);
                    cmd.Parameters.AddWithValue("@AccountType", lblAccountType.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", ddlGender.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@SecurityQuestionId", securityID);
                    cmd.Parameters.AddWithValue("@Answer", txtAnswer.Text.Trim());
                    cmd.Parameters.AddWithValue("@Amount", Convert.ToInt32(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    cmd.Connection = con;  
                    cmd.ExecuteNonQuery(); // Executing SQL command to insert new account into database

                    Response.Redirect("Login.aspx"); ; // Redirecting user to login page after successful registration
                }
               
            }
            catch (Exception msg)// Catching any exceptions that occur during registration process
            {
                error.InnerText = msg.Message;// Displaying error message
            }
            

            try
            {

                // Establishing connection to the database using the connection string from Common class
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {

                    Response.Redirect("Login.aspx", false); // Redirecting user to login page


                }
                else
                {
                    error.InnerText = "Invalid input.";
                }

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {

                    error.InnerText = "User name already exist. ";

                }


                else
                {

                    Response.Write("<script>alert('Error-  " + ex.Message + " ');</script>");
                }
            }

            finally
            {
                con.Close();
            }

         }



        


    protected void btnCancel_Click(object sender, EventArgs e)
    {
            Response.Redirect("Login.aspx");  // Redirecting user to login page


        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
