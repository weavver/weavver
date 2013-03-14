<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_MakePayment.aspx.cs" Inherits="Company_Accounting_Payment" Title="Weavver :: Accounting :: Payment" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <style type="text/css">
          .row1
          {
               background-color: #CCCCCC;
               padding: 5px;
          }
          .row2
          {
               padding: 5px;
          }
     </style>
     <table width="100%" cellpadding="0" cellspacing="0" style="border: solid 1px grey;">
     <tr>
          <td class="row1">Last Statement Balance</td>
          <td class="row1">Minimum Payment Due</td>
          <td class="row1">Current Balance</td>
     </tr>
     <tr>
          <td class="row2">N/A</td>
          <td class="row2"><asp:Label ID="MinimumPaymentDue" runat="server" Text="$0.00"></asp:Label></td>
          <td class="row2"><asp:Label ID="Balance" runat="server" Text="$0.00"></asp:Label></td>
     </tr>
     </table><br />
     <br />
     <table width="500px">
     <tr>
          <td style="height: 60px;">Funding source:</td>
          <td style="height: 60px;">
               <asp:DropDownList ID="CreditCards" runat="server" Width="200px"></asp:DropDownList>
               &nbsp;&nbsp;<a href="~/Accounting_CreditCards/Insert.aspx?RedirectURL=/workflows/accounting_makepayment">Add another Credit Card</a>
          </td>
     </tr>
     <tr>
          <td style="height: 30px;" valign="baseline">
               <asp:RadioButton ID="PayBalance" runat="server" GroupName="PaymentOptions" Text="Balance:" Checked="true" />
          </td>
          <td style="height: 30px;" valign="baseline">
               <asp:Label ID="PayBalanceAmount" runat="server" Text="$0.00"></asp:Label><br />
          </td>
     </tr>
     <tr>
          <td style="height: 30px;" valign="baseline">
               <asp:RadioButton ID="rb2" runat="server" GroupName="PaymentOptions" Text="Other amount:" />
          </td>
          <td style="height: 30px;" valign="baseline">
               <asp:TextBox ID="PayOtherAmount" runat="server"></asp:TextBox><br />
          </td>
     </tr>
     <tr>
          <td></td>
          <td><asp:Button ID="PaymentSubmit" runat="server" OnClick="Payment_Click" Text="Submit Payment" Height="30px" Width="130px" /></td>
     </tr>
     </table><br />
     Account credit/over payment is applied towards future balances. We do not provide refunds at this time.<br />
     <br />
</asp:Content>