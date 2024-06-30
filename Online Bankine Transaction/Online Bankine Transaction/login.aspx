<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Online_Bankine_Transaction.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table align="center">
    <tr>
        <td colspan="4" align="center">
            <h4>Login</h4>
            
            
        </td>
    </tr>
     <tr>
     <td>
         <asp:Label ID="Label1" runat="server" Text="User Name"> </asp:Label>
        </td>
         <td>
             <asp:TextBox ID="txtUsername" runat="server" Height="28px" Width="200px" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtUsername"
                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
     </td>
          <td style="padding-right:40px;">
    </td>
     <td>

         <asp:Button ID="btnRegister" runat="server" Text="Register"  Height="28px" OnClick="btnRegister_Click" CausesValidation="false"/>
 </td>
 </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>

    </td>
    <td>
         <asp:TextBox ID="txtPassword" runat="server" Height="28px" Width="200px" TextMode="Password" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtPassword"
    SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

    </td>
    <td></td>
    <td></td>
        </tr>
    <tr>
            <td colspan="4" style="padding-left:77px;">
            <asp:Button ID="btnLogin" runat="server" Text="Login" Height="28px" Onclick="btnLogin_Click"/>

          </td>
    </tr>
    <tr>
        <td colspan="3">
            <div id="error"  runat="server"  style="color:red">

            </div>

        </td>
        <td>
            <asp:LinkButton ID="lbForgetPassword" runat="server" Height="28px" CausesValidation="false" OnClick="lbForgotPassword">ForgotPassword</asp:LinkButton>

        </td>
        <td></td>
        <td></td>
    </tr>

</table>


</asp:Content>
