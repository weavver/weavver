<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_RecurringBillables.ascx.cs" Inherits="DynamicData_Filters_Accounting_RecurringBillables" %>

<div style="float:right; padding-bottom: 15px;">
     Filter: <asp:RadioButtonList ID="Filter" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true">
               <asp:ListItem Text="Both" Value="Both" Selected="True"></asp:ListItem>
               <asp:ListItem Text="Revenue" Value="Revenue"></asp:ListItem>
               <asp:ListItem Text="Expenses" Value="Expenses"></asp:ListItem>
             </asp:RadioButtonList>
</div>