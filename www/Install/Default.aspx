<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Install_Default" Title="Weavver :: Installer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div id="ConnectionInformation" style="float:right; width: 300px; border: 2px solid #dcdcdc; padding: 10px; margin: 5px;">
          <h3>Connection Information</h3><br />
          To update these settings please modify your Web.config file.
          <br />
          <br />
          <table style="width: 300px;" cellpadding="0" cellspacing="0">
          <tr>
               <td width="120px">Host:</td>
               <td>
                    <asp:Label ID="DatabaseHost" runat="server" Text="[not set]"></asp:Label>
               </td>
          </tr>
          <tr>
               <td width="120px">Username:</td>
               <td>
                    <asp:Label ID="DatabaseUsername" runat="server" Text="[not set]"></asp:Label>
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
          <asp:Button ID="TestConnection" runat="server" Text="Test Connection" Height="30px" OnClick="TestConnection_Click" /><br />
          <br />
          <asp:Label ID="DBStatus" runat="server" Text=""></asp:Label>
     </div>
     Installing Weavver is a simple process. Update the web.config file to match your network settings
     and point Weavver to your database server. Check Readme.txt or the <a href="http://www.weavver.com/KnowledgeBases/KnowledgeBase.aspx?ParentId=d8e82e3b-d87d-4c7b-9f13-9934afd46824">online documentation</a> for more information.<br />
     <br />
     <table cellpadding="0" cellspacing="0" style="border: 2px solid #dcdcdc; padding: 10px; width: 400px;">
     <tr>
          <td colspan="2" style="padding-bottom: 5px; font-weight: bold;">
               <h3>Set-up your first org:</h3>
          </td>
     </tr>
     <tr>
          <td width="150px">Organization:</td>
          <td>
               <asp:TextBox ID="Organization" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="OrganizationValidator" runat="server" ControlToValidate="Organization" ErrorMessage="*" ToolTip="Organization required!" ValidationGroup="SetUpInfo">*</asp:RequiredFieldValidator>
          </td>
     </tr>
     <tr>
          <td colspan="2" style="padding-top: 15px; padding-bottom: 5px; font-weight: bold;">
               Admin account:
          </td>
     </tr>
     <tr>
          <td width="150px">Username:</td>
          <td>
               <asp:TextBox ID="Username" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="UsernameValidator" runat="server" ControlToValidate="Username" ErrorMessage="*" ToolTip="Username required!" ValidationGroup="SetUpInfo">*</asp:RequiredFieldValidator>
          </td>
     </tr>
     <tr>
          <td>Password:</td>
          <td>
               <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
               <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ControlToValidate="Password" ErrorMessage="*" ToolTip="Password required!" ValidationGroup="SetUpInfo">*</asp:RequiredFieldValidator>
          </td>
     </tr>
     <tr>
          <td colspan="2" style="padding-top: 15px; padding-bottom: 5px;">
               <span style="color:Red;">Warning! Deploying the schema into a database with existing tables will result in a loss of data.</span><br />
          </td>
     </tr>
     <tr>
          <td></td>
          <td style="text-align:right;">
               <asp:Button id="Create" runat="server" OnClick="Create_Click" Text="Deploy Schema" Height="30px" ValidationGroup="SetUpInfo" />
          </td>
     </tr>
     </table>
     <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
     <br />
     <br />
     Note: Once the schema is deployed change "install_mode" to false in your Web.config file.
     <br />
     You may also wish to delete this "/install/" folder to improve security.
     <br />
     <asp:TextBox ID="Log" runat="server" TextMode="MultiLine" Height="400px" Width="800" Visible=false></asp:TextBox>
</asp:Content>