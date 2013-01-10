<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="System_Links" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:DataGrid ID="List" runat="server" Width="100%" HeaderStyle-BackColor="BurlyWood" AutoGenerateColumns="false">
     <Columns>
          <asp:BoundColumn DataField="Id" HeaderText="Id" Visible="false"></asp:BoundColumn>
          <asp:BoundColumn DataField="Rev" HeaderText="Rev" Visible="false"></asp:BoundColumn>
          <asp:BoundColumn DataField="Object1" HeaderText="Object 1"></asp:BoundColumn>
          <asp:BoundColumn DataField="Object1Type" HeaderText="Type"></asp:BoundColumn>
          <asp:BoundColumn DataField="Object2" HeaderText="Object 2"></asp:BoundColumn>
          <asp:BoundColumn DataField="Object2Type" HeaderText="Type"></asp:BoundColumn>
          <asp:BoundColumn DataField="CreatedAt" HeaderText="CreatedAt"></asp:BoundColumn>
     </Columns>
     </asp:DataGrid>
</asp:Content>

