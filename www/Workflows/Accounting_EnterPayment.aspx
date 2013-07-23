<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_EnterPayment.aspx.cs" Inherits="Workflows_Accounting_EnterPayment" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <br />
     <table cellpadding="0" cellspacing="0">
     <td colspan="2" style="padding-bottom: 20px;">
          This form automatically enters a credit into your bank/financial account and a credit into the client account.
     </td>
     <tr>
          <td>Post At:</td>
          <td><asp:TextBox id="PostAt" runat="server" Width="100px"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Check #:</td>
          <td><asp:TextBox id="CheckNum" runat="server" Width="100px"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Amount:</td>
          <td><asp:TextBox id="Amount" runat="server" Width="100px"></asp:TextBox></td>
     </tr>
     <tr>
          <td style="width: 250px">Received from:</td>
          <td><asp:DropDownList id="FromAccount" runat="server" Width="200px"></asp:DropDownList><br />
     </tr>
     <tr>
          <td>Deposited to:</td>
          <td><asp:DropDownList ID="ToAccount" runat="server" Width="200px"></asp:DropDownList></td>
     </tr>
     <tr>
          <td></td>
          <td style="height:50px"><asp:Button ID="MakePayment" runat="server" Height="30px" Width="150px" Text="Enter Payment" OnClick="MakePayment_Click" /></td>
     </tr>
     </table>
</asp:Content>

