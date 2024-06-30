/*Author: Lungile Shongwe 
 * Date 26 Febraury 2023
 * The user can enter his the payee details and the amount the user wants to send .
 */



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Bankine_Transaction
{
    public partial class PerformTransaction : System.Web.UI.Page
    {
        SqlConnection con;   // Declaration of SqlConnection object
        SqlCommand cmd;    // Declaration of SqlCommand object
        SqlDataAdapter sda;  // Declaration of SqlDataAdapter object
        DataTable dt;       // Declaration of DataTable object
        SqlDataReader dr;   // Declaration of SqlDataReader object
        SqlTransaction transaction = null;  // Declaration of SqlTransaction object


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userId"] == null)
                                           {

                    Response.Redirect("login.aspx");


                }

                getAccountNumber();



            }







        }

        void getAccountNumber()
        {
            try
            {
                con = new SqlConnection(Common.GetConnectionString()); // Establish connection to the database
                cmd = new SqlCommand(@"Select AccountId ,AccountNumber from Account where AccountId = != @AccountId", con);   // SQL query to retrieve account numbers excluding the user's own account
                cmd.Parameters.AddWithValue("@AccountId", Session["userId"]);  // Adding parameter to the SQL query
                sda = new SqlDataAdapter(cmd);  // Initializing SqlDataAdapter SqlCommand
                dt = new DataTable();  // Initializing DataTable
                sda.Fill(dt);  // Filling DataTable with data from SqlDataAdapter
                ddlPayeeAccountNumber.DataSource = dt;  // Setting dropdown list's data source to the DataTable
                ddlPayeeAccountNumber.DataTextField = "AccountNumber";  // Setting the data field for text display
                ddlPayeeAccountNumber.DataValueField = "AccoumtId";   // Setting the data field for value retrieval
                ddlPayeeAccountNumber.DataBind();  // Binding the data to the dropdown list



            }
            catch (Exception ex)   // Catching any exceptions that occur during database operations
            {
                // Displaying error message in a script block
                Response.Write("<script>alert(' " + ex.Message + " ');</script>");




            }



        }





        protected void btnSend_Click(object sender, EventArgs e)
        {

            if (Session["userId"] != null) // Check if the user is logged in
            {

                con = new SqlConnection(Common.GetConnectionString());  // Establish connection to the database
                con.Open();  // Open the database connection
                try
                {
                    int r = 0; // Initialize variable to track the number of affected rows
                    Utils utils = new Utils();  // Creating an instance of the Utils class
                    int balanceAmount = utils.accountBalance(Convert.ToInt32(Session["userId"]));  // Retrieve user's account balance
                    if (Convert.ToInt32(txtAmount.Text.Trim()) <= balanceAmount) // Check if the transaction amount is less than or equal to the account balance
                    {


                        transaction = con.BeginTransaction();

                        cmd = new SqlCommand(@"Insert into [Transaction](SenderAccountId, ReceiverAccountId, MobileNo, Amount, TransactionType, Remarks)
                                            values (@SenderAccountId, @ReceiverAccountId, @MobileNo, @Amount, @TransactionType, @Remarks)", con, transaction); // SQL command to insert transaction details
                        cmd.Parameters.AddWithValue("@SenderAccountId", Session["userId"]); // Adding parameter for sender account ID
                        cmd.Parameters.AddWithValue("@ReceiverAccountId", ddlPayeeAccountNumber.SelectedValue); // Adding parameter for receiver account ID
                        cmd.Parameters.AddWithValue("@MobileNo", txtMobileNumber.Text.Trim()); // Adding parameter for mobile number
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text.Trim()); // Adding parameter for transaction amount
                        cmd.Parameters.AddWithValue("@TransactionType", "DR"); // Adding parameter for transaction type (debit)
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim()); // Adding parameter for transaction remarks
                        r = cmd.ExecuteNonQuery(); // Executing SQL command and getting the number of affected rows


                        // Update sender's account balance
                        UpdateSenderAccountBalance(Convert.ToInt32(Session["userId"]), balanceAmount, Convert.ToInt32(txtAmount.Text.Trim()), con, transaction);
                        UpdateReceiverAccountBalance(Convert.ToInt32(ddlPayeeAccountNumber.SelectedValue), Convert.ToInt32(txtAmount.Text.Trim()), con, transaction);
                        // Update receiver's account balance

                        transaction.Commit();// Commit the database transaction



                        r = 1;
                        if (r > 0)
                        {
                            // Redirect the user to the mydebits page
                            Response.Redirect("mydebits.aspx", false);


                        }

                        else
                        {

                            error.InnerText = "invalid Input";



                        }


                    }

                    else
                    {

                        error.InnerText = "Invalid Input";


                    }



                }

                catch (Exception)
                {

                    try
                    {

                        transaction.Rollback();


                    }
                    catch (Exception ex)
                    {

                        Response.Write("<script>alert('" + ex.Message + "');</script>");


                    }


                }
                finally
                {

                    con.Close();



                }

            

             }

    


        }




        void UpdateSenderAccountBalance(int _senderId, int _dbAmount, int _amount, SqlConnection SqlConnection, SqlTransaction sqlTransaction)
        {

            try
            {
                // Check if there are sufficient funds in the sender's account


                if (_dbAmount >= _amount)  // Deduct the transaction amount from the current balance
                {
                    _dbAmount -= _amount;
                    // Update the sender's account balance in the database
                    cmd = new SqlCommand("Update Account set Amount =@Amount where where AccountId= @AccountId", SqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("_dbAmount", _dbAmount);
                    cmd.Parameters.AddWithValue("@AccountId", _senderId);
                    cmd.ExecuteNonQuery();

                }


            }
            catch (Exception ex)

            {

                // Display error message if an exception occurs during the database operation
                Response.Write("<script.alert('" + ex.Message + "');</script>");

            }
        }





            void UpdateReceiverAccountBalance(int _receiverId, int _amount, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
            {

                int _dbAmount = 0; // Variable to store the receiver's account balance


            // Retrieve the receiver's current account balance from the database
            cmd = new SqlCommand("Select Amount  from Account where AccountId =@AccountId", sqlConnection, sqlTransaction);
                cmd.Parameters.AddWithValue("@AccountId", _receiverId);
                try
                {
                    dr = cmd.ExecuteReader(); // Execute the SQL command to retrieve the account balance


                while (dr.Read())
                {
                    _dbAmount = (int)dr["Amount"]; // Store the retrieved account balance

                    // Add the transaction amount to the receiver's account balance
                    _dbAmount += _amount;

                    // Update the receiver's account balance in the database
                    cmd = new SqlCommand("Update Account set Amount = @Amount where AccountId = @AccountId", sqlConnection, sqlTransaction);
                    cmd.Parameters.AddWithValue("@Amount", _dbAmount);
                    cmd.Parameters.AddWithValue("@AccountId", _receiverId);
                    cmd.ExecuteNonQuery(); // Execute the SQL command to update the receiver's account balance
                }

                dr.Close(); // Close the SqlDataReader


            }

                catch(Exception ex)
                {

                    Response.Write("<script>alert('" + ex.Message + "');<script>");

                }

            }

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {


            Response.Redirect("PerformTransaction.aspx");

        }
    }
}