<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteObject.aspx.cs" Inherits="System_DeleteObject" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <asp:Panel ID="Objects" runat="server"></asp:Panel><br/>
     <br/>
     <asp:Button runat="server" ID="Delete" Text="Delete Object(s)" Height="30px" OnClick="Delete_Click" Width="150px" ForeColor="DarkRed" Font-Bold="True" />
</asp:Content>