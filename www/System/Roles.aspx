﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="System_Roles" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <table cellpadding="10">
     <tr>
          <td valign="top">
               Roles:<br />
               <br />
               <asp:ListBox ID="RolesList" runat="server" Width="150px" Height="300px" AutoPostBack="true"></asp:ListBox><br />
               <asp:Button ID="DeleteRole" runat="server" Text="Remove Role" OnClick="RemoveRole_Click" Height="30" />
          </td>
          <td valign="top">
               Users in role:<br />
               <br />
               <asp:ListBox ID="UserList" runat="server" Width="150px" Height="300px"></asp:ListBox><br />
               <asp:Button ID="DeleteUser" runat="server" Text="Remove User from Role" OnClick="RemoveUserFromRole_Click" Height="30" />
          </td>
          <td valign="top">
               <br />
               <br />
               Add Role:<br />
               <asp:TextBox id="RoleName" runat="server"></asp:TextBox>
               <asp:Button ID="AddRoll" runat="server" Text="Add Role" OnClick="AddRole_Click" Height="30" /><br />
               <br />
               <br />
               Add User:<br />
               <asp:TextBox id="Username" runat="server"></asp:TextBox>
               <asp:Button ID="AddUserToRole" runat="server" Text="Add User" OnClick="AddUserToRole_Click" Height="30" />
          </td>
     </tr>
     </table>
</asp:Content>