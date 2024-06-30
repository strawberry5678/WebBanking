/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Reflects the amounts for credits . 
 */


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Bankine_Transaction
{
    public partial class myCredits : System.Web.UI.Page
    {
        SqlConnection con;// Declaration of SqlConnection object
        SqlCommand cmd; // Declaration of SqlCommand object
        SqlDataAdapter sda;  // Declaration of SqlDataAdapter object
        DataTable dt;    // Declaration of DataTable object


        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the page is being loaded in response to a postback

            if (IsPostBack)
            {


                // Check if the userId session variable is not set, indicating the user is not logged in
                if (Session["userId"] == null)
                {
                    // Redirect the user to the login page
                    Response.Redirect("Login.aspx");



                }
                // Call the getMyCredits method to fetch and display the user's credits
                getMyCredits();
            }
        }



        void getMyCredits()
        {
            try
            {
                con = new SqlConnection(Common.GetConnectionString());// Establishing connection to the databas
                cmd = new SqlCommand(@"Select a.AccountNumber ,a.Username,t.Amount,t.Remarks from [Transaction] t inner join Account a on t.ReceiverAccountId =a.AccountId where t.ReceiverAccountId = @ReceiverAccountId", con);// SQL query to retrieve user's credits
                cmd.Parameters.AddWithValue("@ReceiverAccountId", Session["userId"]); // Adding parameter to the SQL query
                sda = new SqlDataAdapter(cmd); // Initializing SqlDataAdapter with SqlCommand
                dt = new DataTable();  // Initializing DataTable
                sda.Fill(dt); // Filling DataTable with data from SqlDataAdapter
                gvMyCredits.DataSource = dt;   // Setting GridView's data source to the DataTable

                gvMyCredits.DataBind();  // Binding the data to the GridView



            }
            catch (Exception ex) // Catching any exceptions that occur during database operations
            {
                // Displaying error message in a script block
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");




            }



        }

    }
}