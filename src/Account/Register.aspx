<%@ Page Title="Weavver :: Account :: Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register"
         EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="float:left;">
          <asp:Panel ID="RegisterInfo" runat="server">
               Creating your Weavver&reg; Account consists of two simple steps:<br />
               <br />
               1. The first step is to create your user account. This will be used to log in to various Weavver&reg;
               services.<br />
               <br />
               2. The next step is to create a database for yourself or organization. This will be used store
               and manage your data.<br />
               <br />
          </asp:Panel>
          <asp:Panel ID="CheckOut" runat="server" Visible="false">
               To continue checking out please create a Weavver ID or <a href="~/account/login?ReturnURL=/company/sales/placeorder.aspx">log in</a>.
          </asp:Panel>
     </div>
     <div style="float:right;max-width: 450px;">
          <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
     </div>
</asp:Content>