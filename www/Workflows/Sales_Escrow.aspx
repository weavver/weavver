<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_Escrow.aspx.cs" Inherits="Source_Escrow" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     Use this form to escrow funds.<br />
     <br />
     <br />
     To begin the escrow process please fill out the following payment form:<br />
     <br />
     Choose a funding source:
     <asp:DropDownList ID="PaymentMethods" runat="server" Width="150"></asp:DropDownList> or <a href="~/accounting_paymentmethods">Add a Payment</a> method.<br />
     <br />
     <asp:Button ID="Escrow" runat="server" Text="Escrow Funds" Height="30px" />
</asp:Content>

