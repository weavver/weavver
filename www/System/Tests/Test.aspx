<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="System_Test" Title="Untitled Page" %>
<%@ Register src="~/System/Navigation.ascx" tagname="Navigation" tagprefix="wvvr" %>
<form runat="server">
     <wvvr:Navigation ID="Nav" runat="server" />
     <asp:Button runat="server" Text="XMLRPC TEST" onclick="Send_Click" />
     <br />
     <br />
     <asp:TextBox id="AutoTest" runat="server"></asp:TextBox>
</form>
