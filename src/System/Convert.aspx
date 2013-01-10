<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Convert.aspx.cs" Inherits="System_Convert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <h2>Convert</h2><br />
     Use this form to move an object from one ID to another.<br />
     <br />
     <table>
     <tr>
          <td>Old ID:</td>
          <td><asp:TextBox ID="OldId" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>New ID:</td>
          <td><asp:TextBox ID="NewId" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td></td>
          <td>
               <asp:Button ID="Change" runat="server" OnClick="Change_Click" Text="Change" Width="75" Height="30px"></asp:Button>
          </td>
     </tr>
     </table>
     <br />
     <asp:Button ID="Button1" runat="server" OnClick="ChangeType_Click" Text="Change Type" Width="75" Height="30px"></asp:Button><br />
     <br />
     <asp:DataGrid ID="List" runat="server"></asp:DataGrid>
</asp:Content>

