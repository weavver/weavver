<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Install_Default" Title="Weavver :: Installer" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right; width: 300px;">
          <h3>Connection Information</h3><br />
          To update these settings please modify your web.config file.
          <br />
          <br />
          <table style="width: 300px;" cellpadding="0" cellspacing="0">
          <tr>
               <td width="120px">Host:</td>
               <td>
                    <asp:Label ID="DatabaseHost" runat="server"></asp:Label>
               </td>
          </tr>
          <tr>
               <td width="120px">Username:</td>
               <td>
                    <asp:Label ID="DatabaseUsername" runat="server"></asp:Label>
               </td>
          </tr>
          <tr>
               <td width="120px">Pass:</td>
               <td>
                    <i>censored</i>
               </td>
          </tr>
          <tr>
               <td width="120px">Database Name:</td>
               <td>
                    <asp:Label ID="DatabaseName" runat="server"></asp:Label>
               </td>
          </tr>
          </table><br />
          <asp:Button ID="TestConnection" runat="server" Text="Test Connection" Height="30px" OnClick="TestConnection_Click" />
     </div>
     Installing Weavver is a simple process. Update the web.config file to match your network settings
     and point Weavver to your database server (only MSSQL is supported for now).<br />
     <br />
     <h3>Set-up your first org:</h3><br />
     <table>
     <tr>
          <td width="150px">Name:</td>
          <td>
               <asp:TextBox ID="Company" runat="server"></asp:TextBox>
          </td>
     </tr>
     </table><br />
     Create admin account:
     <table>
     <tr>
          <td width="150px">Username:</td>
          <td><asp:TextBox ID="Username" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Password:</td>
          <td>
               <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
          </td>
     </tr>
     <tr>
          <td></td>
          <td>
               <span style="color:Red;">Warning! Deploying the schema into a database with existing tables will result in a loss of data.</span><br />
               <br />
               <asp:Button id="Create" runat="server" OnClick="Create_Click" Text="Deploy Schema" Height="30px" /></td>
     </tr>
     </table>
     <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
     <br />
     <br />
     Notes: Once the schema is deployed change "install_mode" to false in your web.config file.
     <br />
     You may also wish to delete this /install/ folder to improve security.
     <br />
     <asp:TextBox ID="Log" runat="server" TextMode="MultiLine" Height="400px" Width="800" Visible=false></asp:TextBox>
</asp:Content>