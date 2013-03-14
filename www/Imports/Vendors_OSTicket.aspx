<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vendors_OSTicket.aspx.cs" Inherits="Company_Support_Import" Title="Weavver :: Company :: Support :: Import" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <h2>Import</h2>
     <br />
     Host: <asp:TextBox ID="Host" runat="server" Text="192.168.10.111"></asp:TextBox><br />
     Username: <asp:TextBox ID="Username" runat="server" Text="mitchel"></asp:TextBox><br />
     Password: <asp:TextBox ID="Password" runat="server"></asp:TextBox><br />
     <asp:Button ID="ImportOSTicket" runat="server" OnClick="ImportOSTicket_Click" text="Import Issues From OSTicket" Height="30" /><br />
     <br />
     <asp:DataList ID="List" runat="server">
     <ItemTemplate>
          <asp:LinkButton ID="Subject" runat="server" Text="Unknown"></asp:LinkButton></a><br />
     </ItemTemplate>
     </asp:DataList>
     
     
     <asp:DataList ID="DataList1" runat="server">
     <ItemTemplate>
          <div style="border: solid 1px black; padding: 10px; background-color: lightyellow; width: 90%; margin-bottom: 10px;">
               From: <%# Eval("headers") %>
               <%# CleanUp(Eval("message").ToString()) %>
          </div>
     </ItemTemplate>
     </asp:DataList>
     <br />
     Responses:<br />
     <br />
     <asp:DataList ID="Responses" runat="server">
     <ItemTemplate>
          <div style="border: solid 1px black; padding: 10px; background-color: lightyellow; width: 90%; margin-bottom: 10px;">
               From <%# Eval("staff_name") %>:<br />
               <%# CleanUp(Eval("response").ToString()) %>
          </div>
     </ItemTemplate>
     </asp:DataList>
     <br />
     Notes:<br />
     <br />
     <asp:DataList ID="Notes" runat="server">
     <ItemTemplate>
          <div style="border: solid 1px black; padding: 10px; background-color: lightyellow; width: 90%; margin-bottom: 10px;">
               <%# CleanUp(Eval("note").ToString()) %>
          </div>
     </ItemTemplate>
     </asp:DataList>
</asp:Content>

