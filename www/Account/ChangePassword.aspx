<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Account_Change_Password" Title="Weavver :: Account :: Change Password" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div style="margin: auto; width: 400px; clear: both; margin-top: 15px;">
          <asp:ChangePassword ID="ChangePassword1" runat="server" ContinueDestinationPageUrl="/account/" ChangePasswordTitleText="" CancelDestinationPageUrl="/Account/Default.aspx"></asp:ChangePassword>
     </div>
     <br />
     <div style="padding: 10px;">
          Notice: If you change your password and are using one of our SIP or XMPP services please remember
          to update your respective clients or you will experience a loss of connectivity.
     </div>
</asp:Content>