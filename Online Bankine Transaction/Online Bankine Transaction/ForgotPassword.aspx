<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Online_Bankine_Transaction.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>


            <td colspan="2"  align="center">
                <h4>Forgot Password</h4>
                 </td>
                 </tr>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>

            </td>
             <td>
                 <asp:Label ID="lblUsername" runat="server" ></asp:Label>
           
             </td>
       
           
        </tr>
        <tr>

            <td style="width:160px;">

                <asp:Label ID="Label2" runat="server" Text="Security Question "></asp:Label>

               
                </td>
              <td>
                  <asp:Label ID="lblSecurityQuestion" runat="server" ></asp:Label>

                   </td>
            </tr>
          <tr>

      <td style="width:160px;">

          <asp:Label ID="Label3" runat="server" Text="Answer"></asp:Label>
          </td>
              <td>         
                                    <asp:TextBox ID="txtAnswer" runat="server" OnTextChanged="txtAnswer_TextChanged" ></asp:TextBox>
                  <asp:HiddenField ID="hdnAnswer" runat="server" />
                  </td>
              <td class="auto-style1">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer" ErrorMessage="*"  ForeColor="Red" ContolToValidate="txtAnswer"
                            SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
          </td>
      </tr>
        <tr>
            <td align="center">

                <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" Height="28px" OnClick="btnForgotPassword_Click1" />
            </td>
            <td>

                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="28px" OnClick="btnCancel_Click" CausesValidation="false" />
                <asp:LinkButton ID="lbChange" runat="server"  Height="28px"   CausesValidation="false" OnClick ="LinkButton1_Click">Change</asp:LinkButton>
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
