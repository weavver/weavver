<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" Title="Weavver :: Account Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Account/Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding: 10px;">
          <uc1:Navigation id="Nav" runat="server"></uc1:Navigation>
          <div style="float:right; max-width: 200px; clear: both; padding: 20px;">
               <asp:Panel ID="Voicemail" runat="server">
                    <div style="float:right;">
                         <asp:DropDownList ID="VoicemailFolders" runat="server">
                         <asp:ListItem>Inbox</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    Recent voicemails:<br />
                    <br />
                    <asp:ListView ID="VoicemailList" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="BurlyWood">
                    <ItemTemplate>
                         <%--<%# DataBinder.Eval(Container.DataItem, "uuid") %><br />--%>
                         <span title="Tel Address: <%# DataBinder.Eval(Container.DataItem, "cid_number")%>"><%# DataBinder.Eval(Container.DataItem, "cid_name")%> </span>
                         <%--<%# DataBinder.Eval(Container.DataItem, "uuid") %><br />--%><br />
                    </ItemTemplate>
                    </asp:ListView>
     <%--
                         <asp:BoundColumn DataField="uuid" Visible="false"></asp:BoundColumn>
                         <asp:BoundColumn DataField="cid_name" HeaderText="Name"></asp:BoundColumn>
                         <asp:BoundColumn DataField="cid_number" HeaderText="Number" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                         <asp:BoundColumn DataField="created_epoch" HeaderText="Received" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150"></asp:BoundColumn>
                    </Columns>
                    </asp:DataGrid>--%>
                    <asp:Literal ID="NoVoicemails" runat="server" Visible="false">No voicemails.</asp:Literal>
               </asp:Panel>
          </div>
          <div id="SearchBox" runat="server" style="float:right; clear: right;" visible="false">
               <asp:TextBox ID="Query" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" />
          </div>
          <asp:Literal ID="AccountContent" runat="server" />
          <br />
          <h3></h3>
          <a id="ReceivablesLink" runat="server" href='#'>Receivable Ledger</a><br />
          <a id="PayablesLink" runat="server" href='#'>Payable Ledger</a><br />
          <br />
          <a id="TasksLink" runat="server" href='#'>My Tasks</a>
          <br />
          <br />
          <h3>Customer Service:</h3><br />
          Open Tickets: <asp:Label ID="OpenTickets" runat="server"></asp:Label><br />
          Total Tickets: <asp:Label ID="TotalTickets" runat="server"></asp:Label>
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