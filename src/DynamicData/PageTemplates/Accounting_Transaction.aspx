<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accounting_Transaction.aspx.cs" Inherits="Company_Accounting_Transaction" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">

     
     <table>
     <tr>
          <td>Account:<br />
               <asp:DropDownList ID="Accounts" runat="server" Width="150px"></asp:DropDownList>
          </td>
          <td>
               Code:<br />
               <asp:DropDownList ID="Code" runat="server" Width="150px"></asp:DropDownList>
          </td>
          <td>
               Memo:<br />
               <asp:TextBox ID="Memo" runat="server"></asp:TextBox>
          </td>
          <td>
               Amount:<br />
               <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
          </td>
          <td>
               EntryType:<br />
               <asp:DropDownList ID="EntryType" runat="server"><asp:ListItem>Credit</asp:ListItem><asp:ListItem>Debit</asp:ListItem></asp:DropDownList>
          </td>
          <td>
               <br /><asp:LinkButton ID="Delete" runat="server" Text="Delete"></asp:LinkButton>
               <br /><asp:LinkButton ID="DeleteLink" runat="server" Text="Delete Link"></asp:LinkButton>
          </td>
     </tr><tr>
          <td>Account:<br />
               <asp:DropDownList ID="DropDownList1" runat="server" Width="150px"></asp:DropDownList>
          </td>
          <td>
               Code:<br />
               <asp:DropDownList ID="DropDownList2" runat="server" Width="150px"></asp:DropDownList>
          </td>
          <td>
               Memo:<br />
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
          <td>
               Amount:<br />
               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          </td>
          <td>
               EntryType:<br />
               <asp:DropDownList ID="DropDownList3" runat="server"><asp:ListItem>Credit</asp:ListItem><asp:ListItem>Debit</asp:ListItem></asp:DropDownList>
          </td>
     </tr>
     <tr>
          <td colspan="5" style="text-align:right;">
               <asp:LinkButton ID="AddTransaction" runat="server" Text="Add Transaction"></asp:LinkButton>
          </td>
     </tr>
     </table>
     
     <table>
     <tr>
          <td></td>
          <td><asp:Button ID="Save" runat="server" Text="Save" Height="30px" Width="75px" /></td>
     </tr>
     <tr>
          <td></td>
          <td>
               <br />
               <br />
               <asp:TextBox ID="LedgerItemId" runat="server" Text=""></asp:TextBox>
               <asp:Button ID="TransactionLink" runat="server" Text="Add By Id" />
          </td>
     </tr>
     </table>
     <br />
     Linked Items:<br />
     <br />
     <asp:DataGrid ID="List" runat="server"></asp:DataGrid>
</asp:Content>