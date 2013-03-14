<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="JSONTest.aspx.cs" Inherits="System_Tests_JSONTest" Title="JSON Test" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     <h2>JSON Test</h2>
     <br />
     This tool will test whether or not the input in the box below is valid JSON.<br />
     <br />
     <asp:TextBox ID="JSONText" runat="server" TextMode="MultiLine" Height="300" Width="800"></asp:TextBox><br />
     <br />
     <asp:Button ID="Test" runat="server" Text="Test" OnClick="Test_Click" Width="100" Height="30" />&nbsp;
     <asp:Label ID="TestResult" runat="server"></asp:Label>
</asp:Content>

