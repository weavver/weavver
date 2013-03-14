<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NotSupported.aspx.cs" Inherits="NotSupported" Title="Untitled Page" %>
<%@ MasterType VirtualPath="MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    We are sorry but we do not support your browser yet. Please try one of the following:<br />
    Internet Explorer 6 & 7<br />
    <a href="http://www.mozilla.com/firefox/">Firefox<br />
    <a href="http://www.google.com/chrome">Chrome</a><br />
    <br />
    You are using: <asp:Label ID="UserAgent" runat="server"></asp:Label><br />
    <br />
</asp:Content>