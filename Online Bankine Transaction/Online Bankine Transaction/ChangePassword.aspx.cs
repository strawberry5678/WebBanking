/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Common class containing common functionalities for the application
 */





using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





namespace Online_Bankine_Transaction
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con; // Declaration of SqlConnection object
        SqlCommand cmd; // Declaration of SqlCommand object

        protected void Page_Load(object sender, EventArgs e)
        {
            // This method is called when the page is loaded
            // No operations are performed in the Page_Load event handler in this code
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Check if the forgotpassword session variable is set
            if (Session["forgotpassword"] != null)
            {
                // Establish connection to the database
                con = new SqlConnection(Common.GetConnectionString());
                // SQL command to update the password for the given username
                cmd = new SqlCommand(@"Update Account set Password = @Password  where Username = @Username", con);
                cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text); // Add parameter for the new password
                cmd.Parameters.AddWithValue("@Password", Session["forgotpassword"]); // Add parameter for the username

                try
                {
                    con.Open(); // Open the database connection
                    int r = cmd.ExecuteNonQuery(); // Execute the SQL command and get the number of affected rows
                    if (r > 0) // If any rows are affected
                    {
                        Response.Redirect("Login.aspx", false); // Redirect the user to the login page
                    }
                    else
                    {
                        error.InnerText = "Invalid input."; // Display error message for invalid input
                    }
                }
                catch (Exception ex) // Catch any exceptions that occur during database operations
                {
                    // Display error message in a script block
                    Response.Write("<script>alert('Error - " + ex.Message + " ' );</script>");
                }
                finally
                {
                    con.Close(); // Close the database connection
                }
            }
            else // If forgotpassword session variable is not set
            {
                Response.Redirect("Login.aspx"); // Redirect the user to the login page
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx"); // Redirect the user to the ForgotPassword page when cancel button is clicked
        }

        protected void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}