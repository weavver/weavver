<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" Title="Weavver :: Account Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Account/Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="padding: 10px; padding-bottom: 20px;">
          <uc1:Navigation id="Nav" runat="server"></uc1:Navigation>
          <br />
     </div>
</asp:Content>