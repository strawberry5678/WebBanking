<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Online_Bankine_Transaction.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align ="center">
        <tr>
            <td colspan ="2" align ="center">
                <h4>Registraion</h4>
            </td>
            </tr>
        <tr>

            <td style="width:50%">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>

                </td>
            <td>
                <asp:Label ID="lblAccountNumber"  runat="server"><</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:50%">
    <asp:Label ID="Label2" runat="server" Text="Account Type"></asp:Label>

    </td>
        <td>
            <asp:Label ID="lblAccountType" runat="server" Text="Savings"></asp:Label>

            </td>
            </tr>
            <tr>

            <td style="width:50%">
                <asp:Label ID="Label3" runat="server" Text="User Name"></asp:Label>


            </td>
                <td>
                          <asp:TextBox ID="txtUsername" runat="server" Height="28px" Width="200px" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Minimum username length must be 6 characters (alphanumeric)" ValidationExpression="^[a-zA-Z0-9\s]{6,15}$"></asp:RegularExpressionValidator>

                </td>

                </tr>
               <tr>
                   <td style=""width:50%">
                       <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                   </td>
                   <td>
                       
                       
                 <asp:TextBox ID="txtPassword" runat="server" Height="28px" Width="200px" TextMode="Password" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum password length must be 6 characters" ControlToValidate="txtPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$"></asp:RegularExpressionValidator>
                       </td>
                   </tr>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label5" runat="server" Text="ConfirmPassword"></asp:Label>
                </td> 
            <td>
                
<<asp:TextBox ID="txtConfirmPassword" runat="server" Height="28px" Width="200px" TextMode="Password" OnTextChanged="txtConfirmPassword_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Minimum password length must be 6 characters" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$"></asp:RegularExpressionValidator>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Password not matched" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToCompare="txtPassword"></asp:CompareValidator>
   </td>
            </tr>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>

            </td>
            <td>

                <asp:DropDownList ID="ddlGender" runat="server"  Height="28px" Width="208px" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                    <asp:ListItem>Male</asp:ListItem>
                     <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
  
                 </tr>
                   <tr>
                       <td style="width:50%">
                            <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>

                       </td>
                       <td>
                           <asp:TextBox ID="txtEmail" runat="server" Height="28px" Width="200px" TextMode="Email"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail" ErrorMessage="Amount length must be be 1 to 5 digits" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>



                       </td>

                       </tr>
                    <tr>

                        <td style="width:50%">
                            <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>

                           

                        </td>
                        <td><asp:TextBox ID="txtAddress" runat="server" Height="28px" Width="200px" TextMode="MultiLine"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                        </td>
                        </tr>
                      <tr>
                          <td style =""width:50%">
                              <asp:Label ID="Label9" runat="server" Text="Security Question"></asp:Label>
                          </td>

                          <td>
                                  <asp:DropDownList ID="ddlSecurityQuestion" runat="server"  Height="28px" Width="208px" DataSourceID="SqlDataSource1" DataTextField="SecurityQuestionName" DataValueField="SecurityQuestionId" OnSelectedIndexChanged="ddlSecurityQuestion_SelectedIndexChanged">
                                   </asp:DropDownList>
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BankingTransactionDBConnectionString %>" ProviderName="<%$ ConnectionStrings:BankingTransactionDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [SecurityQuestion]"></asp:SqlDataSource>


</td>
                          </tr>
        <tr>

                      <td style="width:50%">
                     <asp:Label ID="Label10" runat="server" Text="Answer"></asp:Label>
                         </td>
                         <td>
                <asp:TextBox ID="txtAnswer" runat="server" Height="28px" Width="200px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAnswer" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAnswer"
                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

    </td>
          </tr>
                <tr>

                          <td style="width:50%">
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

            <td></td>
            <td></td>


            </tr>
        <tr>

            <td align="center">
                <asp:Button ID="btnRegister" runat="server" Text="Register" Height="28px" OnClick="btnRegister_Click"/>
                </td>
               <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false"  />
               
                </td>
            </tr>
        <tr>

        

      <td colspan="2">
     <div id="error"  runat="server"  style="color:red">

     </div>

      </td>

        

        



                     </table>
    </asp:Content>