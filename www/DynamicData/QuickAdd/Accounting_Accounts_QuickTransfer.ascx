<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Accounting_Accounts_QuickTransfer.ascx.cs" Inherits="DynamicData_QuickAdd_Accounting_Accounts_QuickTransfer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
     .quickLabel
     {
          clear: left;
          float:left;
          padding-right: 15px;
          font-size: 11pt;
     }
     
     .quickData
     {
          clear: left;
          float:left;
          padding-right: 15px;
          margin-bottom: 15px;
          font-size: 11pt;
     }
     
     #QuickAdd
     {
          max-width: 1025px;
          background-color: lightyellow;
          border: solid 1px gray;
          margin-bottom: 0px;
          padding-left: 0px;
          padding: 0px;
          padding: 5px;
          display: none;
          font-size: 11pt;     
     }
</style>

<script type="text/javascript">

     $(document).ready(function () {
          $("#QuickAdd").dialog({
               autoOpen: false,
               modal: true,
               open: function () {
                    $('input', this).blur();
               }
          });
     }
     );

</script>

<a href="javascript:$('#QuickAdd').dialog('open')" class="attachmentLink">Quick Transfer</a>

<div id="QuickAdd" title="Quick Transfer">
     <div class="quickLabel">
          Post At:
     </div>
     <div class="quickData">
          <asp:TextBox ID="PostAt" runat="server" Width="100%"></asp:TextBox>
          <cc1:CalendarExtender ID="PostAtExtender" runat="server" TargetControlID="PostAt"></cc1:CalendarExtender>
     </div>
     <div class="quickLabel">
          From:
     </div>
     <div class="quickData">
          <asp:DropDownList id="FromAccount" runat="server" Width="100%"></asp:DropDownList>
     </div>
     <div class="quickLabel">
          To:
     </div>
     <div class="quickData">
          <asp:DropDownList ID="ToAccount" runat="server" Width="100%"></asp:DropDownList>
     </div>
     <div class="quickLabel">
          Amount:
     </div>
     <div class="quickData">
          <asp:TextBox ID="Amount" runat="server" Width="100%"></asp:TextBox>
     </div>
     <div style="clear: both; float:right;text-align: right;">
          <asp:Button ID="TransferFunds" runat="server" Text="Post" Height="30px" Width="100px" OnClick="TransferFunds_Click" />
          <asp:LinkButton ID="LedgerItemCancel" runat="server" Text="[cancel]" ForeColor="Blue" Visible="false" OnClick="LedgerItemCancel_Click"></asp:LinkButton>
     </div>
</div>