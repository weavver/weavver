<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_LedgerItems.ascx.cs" Inherits="DynamicData_Projections_Accounting_LedgerItems" %>

<table cellpadding="0" cellspacing="0" valign="top">
<tr>
     <td id="FilteredTotals" runat="server" visible="false">
          <h4>Filtered Totals</h4>
          <table style="width: 250px; border-top: solid 1px black; margin-right: 25px;" cellpadding="0" cellspacing="0">
          <tr>
               <td>Starting Balance:</td>
               <td style="text-align:right;"><asp:Label ID="VisibleStartingBalance" runat="server"></asp:Label></td>
          </tr>
          <tr style="color: #004F00">
               <td>Credits:</td>
               <td style="text-align:right;">+ <asp:Label ID="VisibleCredits" runat="server"></asp:Label></td>
          </tr>
          <tr style="color: #FF0000">
               <td>Debits:</td>
               <td style="text-align:right;">- <asp:Label ID="VisibleDebits" runat="server"></asp:Label></td>
          </tr>
          <tr title="Balance">
               <td>Credits - Debits:</td>
               <td style="text-align:right;"><asp:Label ID="VisibleBalance" runat="server"></asp:Label></td>
          </tr>
          <tr title="Projected Balance">
               <td>Projected Balance:</td>
               <td style="text-align:right;"><asp:Label ID="VisibleAvailableBalance" runat="server"></asp:Label></td>
          </tr>
          <tr>
               <td>Ending Balance:</td>
               <td style="text-align:right;"><asp:Label ID="VisibleEndingBalance" runat="server"></asp:Label></td>
          </tr>
          </table>
     </td>
     <td valign="top">
          <h4>Account Totals</h4>
          <table style="width: 250px; border-top: solid 1px black;" cellpadding="0" cellspacing="0">
          <tr style="color: #004F00">
               <td><span>Credits:</span></td>
               <td style="text-align:right;">+ <asp:Label ID="FundsIn" runat="server"></asp:Label></td>
          </tr>
          <tr style="color: #FF0000; border-bottom: 1px solid black;">
               <td><span>Debits:</span></td>
               <td style="text-align:right;">- <asp:Label ID="FundsOut" runat="server"></asp:Label></td>
          </tr>
          <tr title="Balance">
               <td>Balance:</td>
               <td style="text-align:right;">= <asp:Label ID="Balance" runat="server"></asp:Label></td>
          </tr>
          <tr title="Projected Balance">
               <td>Projected Balance:</td>
               <td style="text-align:right;">~ <asp:Label ID="AvailableBalance" runat="server"></asp:Label></td>
          </tr>
          </table>
     </td>
</tr>
</table>