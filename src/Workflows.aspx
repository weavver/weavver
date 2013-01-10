<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Workflows.aspx.cs" Inherits="Workflows" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:DataGrid ID="List" runat="server" AutoGenerateColumns="false">
     <Columns>
          <asp:BoundColumn DataField="CreationTime" HeaderText="Creation Time"></asp:BoundColumn>
          <asp:BoundColumn DataField="BlockingBookmarks" HeaderText="Blocking Bookmarks"></asp:BoundColumn>
          <asp:TemplateColumn>
               <ItemTemplate>Approve</ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn>
               <ItemTemplate>Deny</ItemTemplate>
          </asp:TemplateColumn>
     </Columns>
     </asp:DataGrid>
</asp:Content>

