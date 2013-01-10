<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_Accounts.ascx.cs" Inherits="DynamicData_Projections_Accounting_Accounts" %>
<style type="text/css">
     .projectionLabel
     {
          clear: left;
          float:left;
     }

     .projectionData
     {
          float:right;
          text-align: right;
     }
</style>
<br />
<div style="float:right;max-width: 275px;">
     <div style="color: #004F00">
          <div class="projectionLabel">Receivables:</div>
          <div class="projectionData" style="min-width: 120px; text-align: right;">+ <asp:Label ID="ReceivableTotal" runat="server" Text="0"></asp:Label></div>
     </div>
     <div style="clear: both;color: #FF0000;">
          <div class="projectionLabel">Payables:</div>
          <div class="projectionData">- <asp:Label ID="PayableTotal" runat="server" Text="0"></asp:Label></div>
     </div>
     <div style="clear: both;border-bottom: 1px solid black;">
          <div class="projectionLabel">Net (AR-AP):</div>
          <div class="projectionData"><asp:Label ID="Net" runat="server" Text="$0.00"></asp:Label></div>
     </div>
     <div style="clear: both; padding-top: 15px;">
          <div style="clear: both;">
               <div class="projectionLabel">Cash Balance:</div>
               <div class="projectionData" style="min-width: 120px; text-align: right;"><asp:Label ID="Balance" runat="server" Text="$0.00"></asp:Label></div>
          </div>
          <div style="clear: both;">
               <div class="projectionLabel">Projected Balance:</div>
               <div class="projectionData"><asp:Label ID="ProjectedBalance" runat="server" Text="0"></asp:Label></div>
          </div>
     </div>
</div>