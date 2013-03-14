<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="Weavver :: Search" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <div style="text-align: center; background-color: Gray; padding: 3px;">
          <asp:TextBox ID="SearchBox" runat="server" Width="300px" Height="20px"></asp:TextBox> <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Search" />
     </div>
     <br />
     <table style="width: 100%">
     <tr>
          <td valign="top" style="padding-right: 20px;" width="190px">
               Sums:<br />
               <br />
               <asp:DataList ID="FoundTypes" runat="server">
               <ItemTemplate>
                    <nobr><%# DataBinder.Eval(Container.DataItem, "Type") %><span style="color:#CCCCCC">
                    (<%# DataBinder.Eval(Container.DataItem, "Count") %>)</span></nobr>
               </ItemTemplate>
               </asp:DataList>
          </td>
          <td>
               Results:<br />
               <br />
               <asp:DataList ID="List" runat="server" AutoGenerateColumns="false">
               <ItemTemplate>
                    <div style="width: 700px">
                         <div style="float:right;">
                              <%# DataBinder.Eval(Container.DataItem, "TableName") %>
                         </div>
                         <%--<a href="#">--%>
                              <%# DataBinder.Eval(Container.DataItem, "ColumnValue") %> (<%# Trim(DataBinder.Eval(Container.DataItem, "ColumnName")) %>)...<br />
                         <%--</a>--%>
                    </div>
               </ItemTemplate>
               </asp:DataList>
          </td>
     </tr>
     </table>
     <%--
     <asp:DataList ID="List" runat="server">
     <ItemTemplate>
          <a href="#"><%# GetItemName(Container.DataItem) %></a><br />
          <%# GetSummary(Container.DataItem) %>
          <br />
          <%# GetCouchDBLink(Container.DataItem) %>
          <br />
     </ItemTemplate>
     </asp:DataList>--%><br />
     <br />
     <br />
</asp:Content>