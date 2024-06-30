<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="PerformTransaction.aspx.cs" Inherits="Online_Bankine_Transaction.PerformTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">


    <table align="center">

        <tr>

            <td colspan="2" align="center">

                <h4>PerformTransaction</h4>

            </td>



        </tr>
        <tr>
            <td>

                <asp:Label ID="Label1" runat="server" Text="Payee Account NUmber "></asp:Label>



            </td>
            <td>
                <asp:DropDownList ID="ddlPayeeAccountNumber" runat="server"     Height="28px" Widtrh="208px"    AppendDataBoundItems="true">
                    <asp:ListItem     Value="0">Please select Account Number ></asp:ListItem>
                     </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAnswer"
                      SetFocusOnError="true" Display="Dynamic"  InitialValue="0" ></asp:RequiredFieldValidator>
               </td>
              </tr>
        <tr>
                            <td>
                <asp:Label ID="Label3" runat="server" Text="Payee Name"></asp:Label>
            </td>
                <td>
                          <asp:TextBox ID="txtPayeeName" runat="server" Height="28px" Width="200px" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPayeeName" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                  
                    <div>


<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPayeeName" ErrorMessage="Minimum payee name length must be 6 characters (alphanumeric)" ValidationExpression="^[a-zA-Z0-9\s]{6,15}$"></asp:RegularExpressionValidator>
                    </div>

                </td>
                </tr>
               













                <tr>
                            <td>
                <asp:Label ID="Label2" runat="server" Text="Mobile Number "></asp:Label>
            </td>
                <td>
                          <asp:TextBox ID="txtMobileNumber" runat="server" Height="28px" Width="200px" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                  
                    <div>


<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number must be 10 Digits" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                    </div>

                </td>
                </tr>




            <tr>

              <td>
             <asp:Label ID="Label11" runat="server" Text="Amount"></asp:Label>
                </td>
                     <td>
            <asp:TextBox ID="txtAmount" runat="server" Height="28px" Width="200px" TextMode="Number"  ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ControlToValidate="txtAmount" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAmount"
            etFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtAmount" ErrorMessage="Invalid email format"   ForeColor="Red" ControlValidate="txtAmount" SetFocusOnError="true"  Display
             ="Dynamic" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator>
              
</td>
</tr>






            <tr>

                  <td style="width:50%">
                 <asp:Label ID="Label10" runat="server" Text="Remarks"></asp:Label>
                     </td>
                     <td>
            <asp:TextBox ID="txtRemarks" runat="server" Height="28px" Width="200px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRemarks" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAnswer"
             SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

</td>
      </tr>




                    <tr>

                         <td align="center">
                    <asp:Button ID="btnSend" runat="server" Text="Send" Height="28px" OnClick="btnSend_Click"/>
           </td>
          <td>
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false"  />
          
           </td>
       </tr>
   <tr>

   

             <td colspan="2" style="height: 60px">
            <div id="error"  runat="server"  style="color:red">

            </div>

             </td>



       




    </table>






</asp:Content>
