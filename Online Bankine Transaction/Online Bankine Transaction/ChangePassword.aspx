<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Online_Bankine_Transaction.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>

            <td colspn="2" align="center">


                <h4>ChangePassword</h4>


            </td>
                  </tr>
                     <tr>

                    <td style="width:160px;">

                 <asp:Label ID="Label3" runat="server" Text="New Password"></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                     <td>         
                              <asp:TextBox ID="txtAnswer" runat="server" OnTextChanged="txtAnswer_TextChanged" ></asp:TextBox>
                              <asp:HiddenField ID="hdnAnswer" runat="server" />
                          </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server"  Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAnswer"
                      SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                           <div>

                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>       
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Minimum password length must be 6 characters" ControlToValidate="txtNewPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$"></asp:RegularExpressionValidator>


                            </div>
                                                       </td>
                   </tr>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label5" runat="server" Text="ConfirmPassword"></asp:Label>
                </td> 
            <td>
                
                            <asp:TextBox ID="txtConfirmPassword" runat="server" Height="28px" Width="200px" TextMode="Password" OnTextChanged="txtConfirmPassword_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                <div>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Minimum password length must be 6 characters" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,15}$"></asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Password not matched" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToCompare="txtNewPassword"></asp:CompareValidator>
                                    </div>
                     </td>
                </tr>
                     <tr>
                        
                    <td align="center">

                      <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Height="28px" OnClick="btnChangePassword_Click"/>
                 </td>
                 <td>

                   <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false" />
                     </td>
                            </tr>

                         <tr>
 
                          <td colspan="2">
                         <div id="error"  runat="server"  style="color:red">

                        </div>
                              </td>


        </tr>




    </table>


</asp:Content>
