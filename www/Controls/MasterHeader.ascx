<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MasterHeader.ascx.cs" Inherits="Controls_MasterHeader" %>
<%@ Register src="~/Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register src="~/Controls/Log In.ascx" tagname="LogIn" tagprefix="wvvr" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div id="SignInArea" runat="server" class="sign-in">
     <asp:UpdatePanel ID="RegisterLogInPanel" runat="server">
     <ContentTemplate>
          <asp:LoginView ID="LoginView1" runat="server">
          <AnonymousTemplate>
               <a id="SignInLink" runat="server" href="javascript:LoginOpen(this);">Log In</a>
               <asp:Literal ID="RegisterLink" runat="server">
                    or <a id="RegisterLink" href="~/account/register">Register</a>
               </asp:Literal>
          </AnonymousTemplate>
          <LoggedInTemplate>
               <a class="account-link" style="color: #000000;" href="~/account/"><asp:Label ID="UsernameLabel" runat="server"></asp:Label></a>&nbsp;|&nbsp;
               <a class="sign-out-link" style="color: #000000;" href="~/account/logout">Sign Out</a>
          </LoggedInTemplate>
          </asp:LoginView>
     </ContentTemplate>
     </asp:UpdatePanel>
     <asp:DropDownList ID="OrganizationsList" runat="server" AutoPostBack="true" Width="150px" Visible="false">
     </asp:DropDownList>
</div>
<div style="float:right; height:10px;width: auto; color: Black; padding-bottom: 5px;">
     <wvvr:LogIn ID="LogIn" runat="server" />
</div>
<div style="float:left; max-width: 300px; vertical-align: middle; height: 63px; margin-top: 10px;">
     <a style="vertical-align: middle;" href="~/">
          <img alt="" id="HeaderLogo" runat="server" src="~/images/logo.png" style="border: none; display:block; float:left; max-width: 100%;" />
     </a>
</div>
<div id="NavigationBox" runat="server" style="float:right; padding-bottom: 0px; padding-right: 15px; text-align: center; clear: right; max-width: 500px;">
     <uc1:Navigation ID="Navigation1" runat="server" />
</div>
<div style="clear: both;"></div>