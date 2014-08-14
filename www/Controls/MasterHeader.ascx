<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MasterHeader.ascx.cs" Inherits="Controls_MasterHeader" %>
<%@ Register src="~/Controls/WebMenu.ascx" tagname="WebMenu" tagprefix="wvvr" %>
<%@ Register src="~/Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register src="~/Controls/LogIn.ascx" tagname="LogIn" tagprefix="wvvr" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="topbar" style='background-color: #59b8ee; border-bottom: 0px solid black; z-index: 100000; clear: both;'>
     <wvvr:WebMenu ID="Toolbar" runat="server" />
     <div style='clear: both;'></div>
</div>
<div style="margin: auto; text-align: right;">
     <asp:DropDownList ID="OrganizationsList" runat="server" AutoPostBack="true" Width="150px" Visible="true" CssClass="orgList"></asp:DropDownList>&nbsp;&nbsp;
     <div id="SignInArea" runat="server" class="sign-in" style="color: #000000;display:inline-block;">
          <asp:UpdatePanel ID="RegisterLogInPanel" runat="server">
          <ContentTemplate>
               <asp:LoginView ID="LoginView1" runat="server">
               <AnonymousTemplate>
                    <a id="SignInLink" runat="server" href="javascript:LoginOpen(this);">Log In</a>
                    <asp:PlaceHolder ID="RegisterLink" runat="server">
                         or <a id="RegisterLinkAnchor" href="<%= Page.ResolveUrl("~/account/register.aspx") %>">Register</a>
                    </asp:PlaceHolder>
               </AnonymousTemplate>
               <LoggedInTemplate>
                    <a class="account-link" style="color: #000000;" href="<%= Page.ResolveUrl("~/account/") %>"><asp:Label ID="UsernameLabel" runat="server"></asp:Label></a>&nbsp;|&nbsp;
                    <a class="sign-out-link" style="color: #000000;" href="<%= Page.ResolveUrl("~/account/logout.aspx") %>">Sign Out</a>
               </LoggedInTemplate>
               </asp:LoginView>
          </ContentTemplate>
          </asp:UpdatePanel>
     </div>
     <div style="float:right; height:10px;width: auto; color: Black; padding-bottom: 5px;">
          <div style='clear: both;'></div>
     </div>
     <wvvr:LogIn ID="LogIn" runat="server" />
     <div style="float:left; max-width: 300px; vertical-align: middle; height: 63px; margin-top: 5px; margin-bottom: 5px;">
          <a id="HeaderLogoLink" runat="server" style="vertical-align: middle;" href="~/">
               <img alt="" id="HeaderLogo" runat="server" src="~/images/logo.png" style="border: none; display:block; float:left; max-width: 100%;" />
          </a>
     </div>
     <div id="NavigationBox" runat="server" style="float:right; padding-bottom: 0px; padding-right: 15px; text-align: center; clear: right;">
          <uc1:Navigation ID="Navigation1" runat="server" />
     </div>
</div>
<div style="clear: both;"></div>