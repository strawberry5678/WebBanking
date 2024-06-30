/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Relects banking statements  for debits .
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
    public partial class mydebits : System.Web.UI.Page
    {

        SqlConnection con; // Declaration of SqlConnection object
        SqlCommand cmd;  // Declaration of SqlCommand object
        SqlDataAdapter sda;   // Declaration of SqlDataAdapter object
        DataTable dt; // Declaration of DataTable object






        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the page is being loaded in response to a postback


            if (IsPostBack)
            {

                // Check if the userId session variable is not set, indicating the user is not logged in
                if (Session["userId"] == null)
                {
                    // Redirect the user to the login page if not logged in
                    Response.Redirect("Login.aspx");



                }
                // Call the getMyDebits method to fetch and display the user's debits
                getMyDebits();


            }



        }

        // Method to fetch and display the user's debits
        void getMyDebits()
        {
            try
            {
                con = new SqlConnection(Common.GetConnectionString());   // Establish connection to the database
                cmd = new SqlCommand(@"Select a.AccountNumber ,a.Username,t.Amount,t.Remarks from [Transaction] t inner join Account a on t.ReceiverAccountId =a.AccountId where t.SenderAccountId = @SenderAccountId", con);  // Establish connection to the database
                cmd.Parameters.AddWithValue("@SenderAccountId", Session["userId"]); // Adding parameter to the SQL query
                sda = new SqlDataAdapter(cmd);  // Initializing SqlDataAdapter with SqlCommand
                dt = new DataTable();// Initializing DataTable
                sda.Fill(dt); // Filling DataTable with data from SqlDataAdapter
                gvMyDebits.DataSource = dt;   // Setting GridView's data source to the DataTable

                gvMyDebits.DataBind();   // Binding the data to the GridView



            }
            catch (Exception ex)  // Catching any exceptions that occur during database operations
            {
                // Displaying error message in a script block
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");




            }



        }




    }
}