<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Debug.aspx.cs" Inherits="System_Debug" Title="System :: Debug" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding: 10px;">
          Selected Organization<br />
          <div style="padding-left: 10px;">
               Id: <asp:Label ID="SelectedOrgId" runat="server"></asp:Label><br />
               Name: <asp:Label ID="OrgName" runat="server"></asp:Label><br />
          </div>
          <br />
          Application Name: <asp:Label ID="RoleApplicationName" runat="server"></asp:Label><br />
          MembershipProvider: <asp:Label ID="Provider" runat="server"></asp:Label><br />
          Authentication Method: <asp:Label ID="AuthenticationType" runat="server"></asp:Label><br />
          <br />
          Logged In User<br />
          <div style="padding-left: 10px;">
               Http Identity: <asp:Label ID="HttpIdentity" runat="server"></asp:Label><br />
               Username: <asp:Label ID="Username" runat="server"></asp:Label><br />
               Id: <asp:Label ID="SelectedUserId" runat="server"></asp:Label><br />
               Organization Id: <asp:Label ID="SelectedUserOrganizationId" runat="server"></asp:Label><br />
               In Roles: <asp:Label ID="InRoles" runat="server"></asp:Label><br />
          </div>
          <br />
          Bitness: <asp:Literal ID="Is64bit" runat="server" Text="Unknown"></asp:Literal>
     </div>
</asp:Content>

