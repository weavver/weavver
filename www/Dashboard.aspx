<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding: 15px;">
          <div id="AccountLinks" runat="server" visible="false" style="float:right;">
               Accounting:
               <a id="ReceivablesLink" runat="server" href='#'>Receivables</a> | 
               <a id="PayablesLink" runat="server" href='#'>Payables</a>
          </div>
          <div id="SearchBox" runat="server" style="float:right; clear: right;" visible="false">
               <asp:TextBox ID="Query" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
          </div>
          <asp:Literal ID="AccountContent" runat="server" />
          <br />
          
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

          <h3></h3>
          <br />
          <a id="TasksLink" runat="server" href='#'>My Tasks</a>
          <br />
          <br />
          <h3>Customer Service:</h3><br />
          Tickets:<br />
          Open: <asp:Label ID="OpenTickets" runat="server"></asp:Label><br />
          Total: <asp:Label ID="TotalTickets" runat="server"></asp:Label>
     <%--
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ApplicationsView" runat="server">
                              <br />
                              Your applications:<br />
                              <asp:ListView ID="ApplicationList" runat="server" HorizontalAlign="Center">
                              <LayoutTemplate>
                                   <table runat="server" id="table1">
                                        <tr runat="server" id="groupPlaceholder">
                                        </tr>
                                   </table>
                              </LayoutTemplate>
                              <GroupTemplate>
                                   <tr runat="server" id="tableRow">
                                        <td runat="server" id="itemPlaceholder" />
                                   </tr>
                              </GroupTemplate>
                              <ItemTemplate>
                                   <td id="Td1" runat="server">
                                        <a href="<%# Eval("AdminURL") %>"><asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' /></a>
                                   </td>
                              </ItemTemplate>
                              </asp:ListView>
                    </asp:View>
                    </asp:MultiView>
               </ContentTemplate>
               </asp:UpdatePanel>
     --%>
     <asp:Panel ID="SiteOverview" runat="server" Visible="false">
               <b>Weavver Internal Control Panel</b><br />
               <br />
               How many users signed up today: <asp:Label ID="UsersToday" runat="server"></asp:Label><br />
               <br />
               How many per week: <asp:Label ID="UsersWeek" runat="server"></asp:Label><br />
               <br />
               <a href="Users.aspx">Users</a><br />
               <br />

               Actions:<br />
               <br />
               <a href="NewsAdd.aspx">Add news item</a><br />
               <br />
               <a href="http://ec2.weavver.com/voicescribe/tests/queue.php">Queue @ ec2.weavver.com</a><br />
          </asp:Panel>
          <br />
          <asp:Panel ID="Intranet" runat="server" Visible="false">
               <br />
               You can share this web site with others on your network by linking them to one of the following: <asp:Label ID="Self_URL" runat="server"></asp:Label><br />
          </asp:Panel>
          <br />
     </div>
</asp:Content>

