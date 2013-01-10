<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vendors_PayPal.aspx.cs" Inherits="Company_Accounting_Import_PayPal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     Imported data:
     <asp:DataGrid ID="fdata" runat="server"></asp:DataGrid>
     <asp:Literal ID="FileData" runat="server"></asp:Literal>
     <br />
     <br />
     <div style="width: 300px; float:right;">
          <asp:Literal ID="Fees" runat="server"></asp:Literal>
          <br />
          <br />
          <asp:Literal ID="Totals" runat="server"></asp:Literal>
          <br />
          <br />
          <asp:Literal ID="Net" runat="server"></asp:Literal>
     </div>
</asp:Content>

