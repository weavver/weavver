<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Wall.aspx.cs" Inherits="Company_Wall" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:TextBox ID="Body" runat="server" Width="600px"></asp:TextBox><asp:Button ID="Post" runat="server" Text="Say" Height="30px" OnClick="Share_Click" /><br />
     <br />
     <asp:DataList ID="List" runat="server">
     <ItemTemplate>
        <%--<a href="#"><%# DatabaseHelper.GetName((Guid)DataBinder.Eval(Container.DataItem, "CreatedBy"))%></a><br />
        <%# DataBinder.Eval(Container.DataItem, "Body") %><br />
        <br />--%>
     </ItemTemplate>
     </asp:DataList>
</asp:Content>