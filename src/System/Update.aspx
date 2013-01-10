<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="System_Update" Title="Weavver :: System :: Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <h2>Update</h2><br />
     You are currently running version <asp:Label ID="Version" runat="server"></asp:Label>.<br />
     <br />
     <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
</asp:Content>