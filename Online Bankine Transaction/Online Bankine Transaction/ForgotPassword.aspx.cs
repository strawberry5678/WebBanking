/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 *  The user an change his password or answer the security question 
 */





using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Bankine_Transaction
{
    public partial class ForgotPassword : System.Web.UI.Page 
    {

        SqlConnection con;  // Declaration of SqlConnection object
        SqlCommand cmd;    // Declaration of SqlCommand object
        SqlDataReader reader;    // Declaration of SqlDataReader object



        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                // If the page is not being loaded in response to a postback
                getUserSecurityQuestion();


            }



        }
        // Method to retrieve and display user's security question
        void getUserSecurityQuestion()
        {
            if (Session["forgotpassword"] != null)   // Check if forgotpassword session variable is set
            {
                
                con = new SqlConnection(Common.GetConnectionString());
                cmd = new SqlCommand(@"Select Username,SecurityQuestionName, Answer from Account inner join SecurityQuestion on Account.SecurityQuestionId = SecurityQuestion.SecurityQuestionId where Username =@Username");
                cmd.Parameters.AddWithValue("@Username", Session["forgotpassword"]);
                con.Open();
                cmd.Connection=con; cmd.ExecuteNonQuery();

                try
                {
                    //con.Open();
                    reader = cmd.ExecuteReader();// Execute SQL command and store result in SqlDataReader
                        bool isTrue = false;
                    while (reader.Read())   // Loop through each record in the result
                        {
                        isTrue = true;  // Set flag to true as user exists
                                        //lblUsername.Text = reader["Username"].ToString();
                            lblUsername.Text = Session["ForgotPassword"].ToString();// Display username
                            lblSecurityQuestion.Text = reader["SecurityQuestionName"].ToString();// Display security question
                            hdnAnswer.Value = reader["Answer"].ToString() ;


                      


                    }

                    if (!isTrue)// If user does not exist
                        {

                        error.InnerText = "Invalid input.";


                    }
                
                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('Error - " + ex.Message + " ' );</script>");

                }
                    finally  // Executed regardless of whether there's an exception or not
                    {


                    if(reader!= null) 
                    {

                        reader.Close();  // Close SqlDataReader


                        }



                    
                    
                }
                con.Close();// Close SqlDataReader






                }




        }

        protected void btnForgotPassword_Click1(object sender, EventArgs e)
        {
            if(txtAnswer.Text.Trim() == hdnAnswer.Value)  // Check if entered answer matches stored answer
            {

                Response.Redirect("ChangePassword.aspx");   // Redirect to ChangePassword page

            }

            else
            {
                error.InnerText = "Invalid inpput";// Display error message if answer is incorrect


            }
        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }


        // Event handler for "Cancel" button click, redirects to login page
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");  // Redirect to login page

        }

        protected void hdnAnswer_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}