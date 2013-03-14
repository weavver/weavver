<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_ResellerAgreement.aspx.cs" Inherits="Company_Sales_Reseller_Agreement" Title="Weavver :: Reseller Agreement" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" Runat="Server">
     Thank you for your interest in our reseller program. We have approved your application. Following your agreement to join our reseller services
     <br />
     <br />
     In order to procede please review the Weavver Reseller Agreement below and digitally sign it.<br />
     <br />
     <div id="Agreement" runat="server" style="width:90%; height: 350px; overflow: scroll; border: 1px solid black; padding: 10px;">
     </div><br />
     <br />
     Your Digital Signature:<br />
     <br />
     <table cellpadding="5" cellspacing="0" width="500px">
     <tr>
          <td>First Name:</td>
          <td><asp:TextBox ID="NameFirst" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Last Name:</td>
          <td><asp:TextBox ID="NameLast" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Title:</td>
          <td><asp:TextBox ID="OrganizationTitle" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Organization Name:</td>
          <td><asp:TextBox ID="OrganizationName" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td></td>
          <td><asp:Button ID="Agree" runat="server" Text="I agree to the Reseller Terms & Conditions" Height="30" OnClick="Agree_Click" /></td>
     </tr>
     </table>
</asp:Content>