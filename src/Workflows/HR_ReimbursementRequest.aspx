<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HR_ReimbursementRequest.aspx.cs" Inherits="Company_Accounting_ReimbursementRequests" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">

     <asp:DataGrid ID="List" runat="server">
     
     </asp:DataGrid>
     <asp:Button ID="Button1" runat="server" Text="New Workflow" OnClick="NewWF_Click" />
     <asp:Button ID="Approve" runat="server" Text="Approve" OnClick="Approve_Click" />
</asp:Content>

