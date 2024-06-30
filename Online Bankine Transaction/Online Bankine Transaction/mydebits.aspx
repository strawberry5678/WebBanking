<%@ Page Title="" Language="C#" MasterPageFile="~/MenuHeader.master" AutoEventWireup="true" CodeBehind="mydebits.aspx.cs" Inherits="Online_Bankine_Transaction.mydebits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">


    <div  align="center">

        <div>

            <h4>My Debits</h4>

        </div>
        <asp:GridView ID="gvMyDebits" runat="server"   AutoGenerateColumns="false">


             <Columns>

     
                 <asp:TemplateField  HeaderText="To Account">
                     <ItemTemplate>

                         <asp:Label ID="accNum" runat="server" Text='<%# Eval("AccountNumber"); %>'></asp:Label>
                  

                     </ItemTemplate>

                     <ItemStyle HorizontalAlign="Center"/>


                 </asp:TemplateField>


                 
                 <asp:TemplateField  HeaderText="Payee Name">
                     <ItemTemplate>

                         <asp:Label ID="payeeName" runat="server" Text='<%# Eval("Username"); %>'></asp:Label>
                  

                     </ItemTemplate>

                     <ItemStyle HorizontalAlign="Center"/>


                 </asp:TemplateField>


                 
                 <asp:TemplateField  HeaderText="amount">
                     <ItemTemplate>

                         <asp:Label ID="amount" runat="server" Text='<%# Eval("Amount"); %>'></asp:Label>
                  

                     </ItemTemplate>

                     <ItemStyle HorizontalAlign="Center"/>


                 </asp:TemplateField>

                 
                 <asp:TemplateField  HeaderText="Remarks">
                     <ItemTemplate>

                         <asp:Label ID="remark" runat="server" Text='<%# Eval("Remarks"); %>'></asp:Label>
                  

                     </ItemTemplate>

                     <ItemStyle HorizontalAlign="Center"/>




                 </asp:TemplateField>



            </Columns>


        </asp:GridView>
       

        <div id="error"    runat="server"  style="color:purple"></div>


    </div>







</asp:Content>
