<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="False" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WeavverDefault" Title="Weavver :: Abre Los Ojos." Trace="false" Debug="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div id="Notice" runat="server" class="banner" style="margin: 0px 0px 5px 0px; padding: 5px;">
               Weavver® is an open and transparent company and free software platform built on <a href="~/source/" style="text-decoration: underline;">open source</a> principles. The software platform is a business management system that integrates together business modules like Accounting, Sales, etc with communications systems to help provide a central and flexible platform for running your business. <a href='~/products/weavver/'>Learn more</a>
          <div style='clear: both;'></div>
     </div>
     <div style="text-align: center;">
          <img style="margin-bottom: 10px; border: outset 1px lightgrey; width: 100%; max-width: 550px;" alt="The photography of Michael Magoski." src="/images/art/burningman.png" />
          <asp:LoginView ID="LoginView1" runat="server">
          <AnonymousTemplate>
               <div style="width: 100%; max-width: 350px; display:inline-block; vertical-align: top;margin-bottom: 10px;">
                    <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
               </div>
          </AnonymousTemplate>
          </asp:LoginView>
          <div style="width: 100%; margin-bottom: 10px; display: inline-block; max-width: 350px; text-align:left;border: 1px solid lightgrey; padding: 0px; vertical-align: top">
               <asp:ListView ID="NewsList" runat="server" AllowPaging="True" AllowSorting="True" EnableViewState="False" PageSize="1">
               <ItemTemplate>
                    <div title="<%# Eval("PublishAt") %>" style="padding-top: 5px; cursor: pointer" onclick="window.location = '~/Marketing_PressReleases/PressRoll.aspx'">
                         <img style="vertical-align: middle; height: 20px;" alt="" src="/images/right-arrow.png" />&nbsp;&nbsp;
                         <a href="~/Marketing_PressReleases/Details.aspx?Id=<%# Eval("Id") %>" style="color: Blue;"><%# Eval("Title") %></a>
                         <div style='text-align: right; font-style: italic; color: Gray;margin-right: 5px;'>
                              posted <%# Weavver.Utilities.DateTimeHelper.GetHumanFriendlyTimeString((DateTime.Now.Subtract((DateTime) Eval("PublishAt")).TotalSeconds)) %>
                         </div>
                    </div>
               </ItemTemplate>
               <EmptyDataTemplate>
                    <div style="clear: both;">No news is available.</div>
               </EmptyDataTemplate>
               <LayoutTemplate>
                    <div style='font-size: 14pt; border-bottom: 1px solid black;margin: 5px;'>
                         NOTICES
                    </div>
                    <div ID="itemPlaceholderContainer" runat="server" style='padding-left: 10px;'>
                         <span ID="itemPlaceholder" runat="server" />
                    </div>
                    <div style='text-align: right; margin-right: 5px;'>
                         <a href='~/marketing_pressreleases/pressroll'>view all</a>
                    </div>
               </LayoutTemplate>
               </asp:ListView>
          </div>
     </div>
</asp:Content>