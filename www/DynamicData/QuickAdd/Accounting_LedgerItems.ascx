<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_LedgerItems.ascx.cs" Inherits="DynamicData_QuickAdd_Accounting_LedgerItems" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table align="right" cellpadding="2" cellspacing="0" style="background-color: lightyellow; border: solid 1px gray; margin-bottom: 0px; padding-left: 0px; margin: 5px; padding: 3px;">
<tr>
     <td>Post At:
          <asp:TextBox ID="LedgerItemPostAt" runat="server" Width="100px"></asp:TextBox>
          <cc1:CalendarExtender ID="PostAtExtender" runat="server" TargetControlID="LedgerItemPostAt"></cc1:CalendarExtender>
     </td>
     <td>Code:
          <asp:DropDownList ID="CodeTypeList" runat="server"></asp:DropDownList>
     </td>
     <td>Memo:
          <asp:TextBox ID="LedgerItemName" runat="server" Width="250px"></asp:TextBox>
     </td>
     <td>
          Amount:
          <asp:TextBox ID="LedgerItemAmount" runat="server" Width="75px"></asp:TextBox>
     </td>
     <td>
          <asp:Label ID="ErrorMsg" runat="server" ForeColor="Red"></asp:Label>
     </td>
     <td style="text-align: right;">
          <asp:Button ID="LedgerItemAdd" runat="server" Text="Post" Height="30px" Width="100px" OnClick="LedgerItemAdd_Click" />
          <asp:LinkButton ID="LedgerItemCancel" runat="server" Text="[cancel]" ForeColor="Blue" Visible="false" OnClick="LedgerItemCancel_Click"></asp:LinkButton>
     </td>
</tr>
</table>