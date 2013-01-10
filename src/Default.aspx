<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="False" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WeavverDefault" Title="Weavver :: Abre Los Ojos." Trace="false" Debug="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <script language="javascript">
//          function doSomething(e)
//          {
//	          var posx = 0;
//	          var posy = 0;
//	          if (!e) var e = window.event;
//	          if (e.pageX || e.pageY) 	{
//		          posx = e.pageX;
//		          posy = e.pageY;
//	          }
//	          else if (e.clientX || e.clientY) 	{
//		          posx = e.clientX + document.body.scrollLeft
//			          + document.documentElement.scrollLeft;
//		          posy = e.clientY + document.body.scrollTop
//			          + document.documentElement.scrollTop;
//	          }
//	          
//	          alert(posy + ": " + posx);
//          }
     </script>
     <div id="DefaultHeader">
          <div style="float: left; text-align:left;">
               <div style="max-width: 319px; margin-top: 5px;">
                    <img id="Logo" runat="server" src="/images/logo.png" style="width: 100%; max-height: 100px;" alt="Logo" title="Logo" /><br />
                    <asp:ListView ID="NewsList" runat="server" AllowPaging="True" AllowSorting="True" EnableViewState="False" PageSize="1">
                    <ItemTemplate>
                         <div title="<%# Eval("PublishAt") %>" style="padding-top: 5px; margin-left: 140px; cursor: pointer" onclick="window.location = '~/Marketing_PressReleases/PressRoll.aspx'">
                              <img style="vertical-align: middle;" alt="" src="/images/right-arrow.png" />&nbsp;&nbsp;
                              <a href="~/Marketing_PressReleases/Details.aspx?Id=<%# Eval("Id") %>" style="color: Blue;"><%# Eval("Title") %></a>
                         </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                         <div style="clear: both;">No news is available.</div>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                         <div ID="itemPlaceholderContainer" runat="server">
                              <span ID="itemPlaceholder" runat="server" />
                         </div>
                    </LayoutTemplate>
                    </asp:ListView>
               </div>
          </div>
          <div id="Notice" runat="server" class="banner" style="max-width: 300px; min-height: 70px; margin-top: 5px;float:right; padding: 5px; margin-bottom: 10px;">
               Weavver&reg; is an open and transparent company and software platform built on
               <a href="~/source/" style="text-decoration: underline;">open source</a>
               principles.
          </div>
     </div>
     <div style="clear: both; text-align: center; vertical-align: top;">
          <div style="display: inline-block; text-align: center; margin-bottom: 10px; width: 100%; max-width: 550px;">
               <asp:LoginView ID="LoginView1" runat="server">
               <AnonymousTemplate>
                    <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
               </AnonymousTemplate>
               <LoggedInTemplate>
                    <img style="margin: auto; border: outset 1px black; width: 100%;" alt="The photography of Michael Magoski." src="/images/art/burningman.png" />
               </LoggedInTemplate>
               </asp:LoginView>
          </div>
          <div style="display:inline-block; text-align: center; vertical-align: top; padding-top: 10px;">
               <div style="display: inline-block; margin-bottom: 10px;">
                    <div id="Products" runat="server" visible="true"><a class="button" href="~/Logistics_Products/Showcase.aspx" onclick="this.blur();"><span>Products</span></a></div>
                    <div><a id="Projects" class="button" href="~/Logistics_Projects/Showcase.aspx" onclick="this.blur();"><span>Projects</span></a></div>
               </div>
               <div style="margin-bottom: 15px;"><a id="Forum" runat="server" class="button" href="~/forum/" onclick="this.blur();"><span>Forum</span></a></div>
               <div style="margin-bottom: 10px;">
                    <div style=""><a id="A1" runat="server" class="button" href="~/KnowledgeBases/KnowledgeBase.aspx" onclick="this.blur();"><span>Knowledge Base</span></a></div>
                    <div style=""><a id="AboutUs" runat="server" class="button" href="~/about/" onclick="this.blur();"><span>About Us</span></a></div>
               </div>
          </div>
     </div><%--
     <div style="margin: auto; text-align: center;">
          <img id="HeaderLogo" runat="server" visible="true" border="0" src="/images/powered-by-weavver.png" style="height: 30px; border: display:block;" />
     </div>--%>
</asp:Content>