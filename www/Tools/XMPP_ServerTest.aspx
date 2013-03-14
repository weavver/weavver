<%@ Page Title="Weavver :: XMPP Testing Tool" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="XMPP_ServerTest.aspx.cs" Inherits="Company_Services_XMPP_Tests_Default" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:right"><a href="~/company/services/chat/">Chat</a></div>
     The following tool checks only the SRV records and related TCP ports for your domain name and can help you diagnose what needs to be fixed. If the A record for the SRV target
     also has multiple IP addresses they will be checked.<br />
     <br />
     Domain:&nbsp;<asp:TextBox ID="Domain" runat="server" Text=""></asp:TextBox><asp:Button ID="DomainLookup" runat="server" OnClick="DomainLookup_Click" Text="Check" /> (example: weavver.com, jabber.org, gmail.com)<br />
     <asp:Literal id="Results" runat="server"></asp:Literal>
     <br />
     A properly configured domain name will have the following SRV records pointing to the servers and ports hosting the XMPP services:<br />
      ---->    _xmpp-client._tcp.domain.com<br />
      ---->    _xmpp-server._tcp.domain.com<br />
      <br />
      <br />
     This tool will not test the A record for the domain name.<br /><br /><br /><br />
</asp:Content>