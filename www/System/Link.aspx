<%@ Page Title="Weavver :: System :: Link" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="System_Link" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Controls/Address.ascx" tagname="Address" tagprefix="wvvr" %>
<%@ Register src="~/Controls/PhoneNumber.ascx" tagname="PhoneNumber" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right;font-size: 10pt;">
          <asp:Panel ID="LinkExisting" runat="server">
               <br />
               <h3>Advanced Users:</h3>
               <br />
               <table>
               <tr>
                    <td>Object Id:</td>
                    <td><asp:Label ID="LinkTo" runat="server"></asp:Label></td>
               </tr>
               <tr>
                    <td>of entity type:</td>
                    <td><asp:Label ID="LinkToType" runat="server"></asp:Label></td>
               </tr>
               <tr>
                    <td>in table:</td>
                    <td><asp:Label ID="LinkToTable" runat="server"></asp:Label></td>
               </tr>
               </table><br />
               <br />
              <asp:UpdatePanel ID="GetInfoUpdatePanel" runat="server">
              <ContentTemplate>
                   <h3>to
                   <asp:TextBox ID="ObjectB" runat="server" Width="100px"></asp:TextBox>
                   <asp:Button ID="GetInfo" runat="server" Text="Get Info" OnClick="GetInfo_Click" /></h3>
                   <asp:Label ID="ErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                   <br />
                   <table>
                   <tr>
                        <td>Object Id:</td>
                        <td><asp:Label ID="ObjectBId" runat="server"></asp:Label></td>
                   </tr>
                   <tr>
                        <td>of entity type:</td>
                        <td><asp:Label ID="ObjectBClassType" runat="server"></asp:Label></td>
                   </tr>
                   <tr>
                        <td>in table:</td>
                        <td><asp:Label ID="ObjectBTableName" runat="server"></asp:Label></td>
                   </tr>
                   </table>
               </ContentTemplate>
               </asp:UpdatePanel>
              <br />
              <br />
              <br />
              <asp:Button ID="CreateLink" runat="server" Text="Create Link" OnClick="Link_Click" Height="30px" />
          </asp:Panel>
     </div>
     What data would you like to link to?<br />
     <br />
     <asp:DataGrid ID="DataTypes" AutoPostBack="true" AutoGenerateColumns="false" runat="server" Width="500px" HeaderStyle-BackColor="#deb887" HeaderStyle-HorizontalAlign="Center">
     <Columns>
          <asp:BoundColumn DataField="DisplayName"></asp:BoundColumn>
          <asp:TemplateColumn HeaderText="New" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <a href="~/<%# DataBinder.Eval(Container.DataItem, "Name")%>/Insert.aspx?linkto=<%# Request["linkto"] %>">Create</a>
               </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Existing" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center">
               <ItemTemplate>
                    <a href="#entitypicker">Choose</a>
               </ItemTemplate>
          </asp:TemplateColumn>
     </Columns>
     </asp:DataGrid><br />
     <asp:Panel ID="Link2DataObjects" runat="server" Visible="false">
          <h2>Link 2 Data Objects Together:</h2><br />
          <table>
          <tr>
               <td>
                    Object 1:
               </td>
               <td colspan="2">
                    <asp:TextBox ID="Object1" runat="server"></asp:TextBox>
               </td>
          </tr>
          <tr>
               <td>Object 2:</td>
               <td>
                    <asp:TextBox ID="Object2" runat="server"></asp:TextBox>
               </td>
               <td>
                    <asp:Button ID="Link" runat="server" Text="Create Link" Height="30px" Width="120px" />
               </td>
          </tr>
          <tr>
               <td colspan="2">
               </td>
          </tr>
          </table>
     </asp:Panel>
</asp:Content>