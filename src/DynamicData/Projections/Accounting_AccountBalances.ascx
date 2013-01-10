<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_AccountBalances.ascx.cs" Inherits="DynamicData_Projections_Accounting_Accounts" %>
<div style="float:right; text-align: right;">
     <table>
     <tr>
          <td>Receivables:</td>
          <td style="min-width: 120px;">+ <asp:Label ID="ReceivableTotal" runat="server" Text="0"></asp:Label></td>
     </tr>
     <tr>
          <td>Payables:</td>
          <td style="min-width: 120px;">- <asp:Label ID="PayableTotal" runat="server" Text="0"></asp:Label></td>
     </tr>
     <tr>
          <td>Net:</td>
          <td style="min-width: 120px;">= <asp:Label ID="Net" runat="server" Text="0"></asp:Label></td>
     </tr>
     </table>
</div>