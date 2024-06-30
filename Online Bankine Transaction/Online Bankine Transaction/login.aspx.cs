
/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Users uses his detials to login  or to select  forgotpassword
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace Online_Bankine_Transaction
{
    public partial class login : System.Web.UI.Page
    {

        SqlConnection con; // Declaration of SqlConnection object
        SqlCommand cmd;    // Declaration of SqlCommand object
        SqlDataReader reader;   // Declaration of SqlDataReader object
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Event handler for Register button click, redirects to registration page
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");

        }

        protected void lbForgotPassword(object sender, EventArgs e)
        {

            if (txtUsername.Text.Trim() == string.Empty)
            {
                // Display error message if username field is empty
                error.InnerText = "Invalid input.";
                txtUsername.Focus();


            }



            else
            {

                // Store the username in session variable and redirect to ForgotPassword page
                Session["forgotpassword"] = txtUsername.Text.Trim();
                Response.Redirect("ForgotPassword.aspx");


            }


        }


        protected void btnLoginClick1(object sender, EventArgs e)
        {

            // Store the username in session variable and redirect to ForgotPassword page
            // int i = 0;
            SqlConnection con = new SqlConnection(Common.GetConnectionString());
            // Creating SQL command to select user based on username and password
            SqlCommand cmd = new SqlCommand(@"Select * from Account where Username=@Username and Password=@Password");
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            try
            {
                //con.Open();
                reader = cmd.ExecuteReader();// Executing SQL command and storing result in SqlDataReader
                bool isTrue = false;

                while (reader.Read())// Loop through each record in the result
                {
                    isTrue = true;  // Set flag to true as user exists
                    Session["userId"] = reader["AccountId"].ToString();// Store user's account ID in session
                }
                if (isTrue) // If user exists

                {
                    Response.Redirect("PerformTransaction.aspx", false);

                }
                else
                {
                    error.InnerText = "Wrong username or password.";
                }

            }

            catch (Exception ex)  // Catching any exceptions that occur during login process
            {
                Response.Write("<script>alert('Error - " + ex.Message + " ');</script>"); // Displaying error message





            }
            finally
            {
                reader.Close();
                con.Close();// Displaying error message
            }


        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
         

      
