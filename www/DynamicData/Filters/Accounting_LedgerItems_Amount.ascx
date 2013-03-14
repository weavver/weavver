<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_LedgerItems_Amount.ascx.cs" Inherits="DynamicData_Filters_Accounting_RecurringBillables" %>

<asp:RadioButtonList ID="Filter" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true">
     <asp:ListItem Text="All" Value="Revenue"></asp:ListItem>
     <asp:ListItem Text="Credit" Value="Credit"></asp:ListItem>
     <asp:ListItem Text="Debit" Value="Debit"></asp:ListItem>
</asp:RadioButtonList>