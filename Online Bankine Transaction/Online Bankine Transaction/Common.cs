using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * Common class containing common functionalities for the application
 */

namespace Online_Bankine_Transaction
{
   
    public class Common
    {
        // Static method to get the connection string from the web.config file
        public static string GetConnectionString()
        {
            // Retrieve the connection string named "BankingTransactionDBConnectionString" from the web.config file
            return ConfigurationManager.ConnectionStrings["BankingTransactionDBConnectionString"].ConnectionString;
        }
    }

    // Utils class containing utility methods for the application
    public class Utils
    {
        SqlConnection con; // Declaration of SqlConnection object
        SqlCommand cmd; // Declaration of SqlCommand object
        SqlDataAdapter sda; // Declaration of SqlDataAdapter object
        DataTable dt; // Declaration of DataTable object

        // Method to retrieve the account balance for a given user ID
        public int accountBalance(int userId)
        {
            int balanceAmount = 0; // Initialize variable to store the account balance

            try
            {
                con = new SqlConnection(Common.GetConnectionString()); // Establish connection to the database using the common method
                cmd = new SqlCommand(@"Select Amount from where  AccountId=@AccountId", con); // SQL query to retrieve the amount for the given account ID
                cmd.Parameters.AddWithValue("@AccountId", userId); // Add parameter for the account ID

                sda = new SqlDataAdapter(cmd); // Initialize SqlDataAdapter with the SqlCommand
                dt = new DataTable(); // Initialize DataTable
                sda.Fill(dt); // Fill DataTable with data from SqlDataAdapter

                // Check if the DataTable contains any rows and retrieve the balance amount
                balanceAmount = Convert.ToInt32(dt.Rows[0]["Amount"]) == 0 ? 0 : Convert.ToInt32(dt.Rows[0]["Amount"]);
            }
            catch (Exception ex) // Catch any exceptions that occur during database operations
            {
                // Display error message in the response using JavaScript alert
                System.Web.HttpContext.Current.Response.Write("<script>alert('Error - '" + ex.Message + ");</script>");
            }

            return balanceAmount; // Return the account balance
        }
    }
}