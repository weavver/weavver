<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IT_Downloads.aspx.cs" Inherits="Company_Logistics_Downloads" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <h2>Downloads</h2><br />
     This page shows a report on your software downloads.<br />
     <br />
     <asp:DataGrid ID="List" runat="server"></asp:DataGrid>
</asp:Content>

