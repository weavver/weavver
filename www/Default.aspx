<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="False" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WeavverDefault" Title="Weavver :: Abre Los Ojos." Trace="false" Debug="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="text-align: center;">
          <br />
          <img id="Logo" runat="server" border="0" style="margin-bottom: 10px; border: outset 1px lightgrey; margin: 10px; width: 100%; max-width: 550px;" alt="The photography of Michael Magoski." src="/images/art/burningman.png" />
          <asp:LoginView ID="LoginView1" runat="server">
          <AnonymousTemplate>
               <div style="width: 100%; max-width: 350px; display:inline-block; vertical-align: top;margin-bottom: 10px;">
                    <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
               </div>
          </AnonymousTemplate>
          </asp:LoginView>
          <div style="margin-bottom: 10px; display: inline-block; max-width: 350px; text-align:left;padding: 0px; vertical-align: top; min-width: 30px;">
               &nbsp;
          </div>
          <div style="width: 100%; margin-bottom: 10px; display: inline-block; max-width: 350px; text-align:left;border: 0px solid lightgrey; padding: 0px; vertical-align: top">
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
                         RECENT BLOGS
                    </div>
                    <div ID="itemPlaceholderContainer" runat="server" style='padding-left: 10px;'>
                         <span ID="itemPlaceholder" runat="server" />
                    </div>
                    <div style='text-align: right; margin-right: 5px;'>
                         <a href='~/Marketing_PressReleases/Details.aspx?Id=31d5a275-e44a-478a-87ef-f67c8a70f09c'>view all</a>
                    </div>
               </LayoutTemplate>
               </asp:ListView>
          </div>
     </div>
</asp:Content>