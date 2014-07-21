<%@ Page Title="Weavver :: Account :: Register" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" EnableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="text-align: center; vertical-align: top;">
          <div style="text-align: left; padding: 20px; display: inline-block; max-width: 200px; vertical-align: top;">
               <asp:PlaceHolder ID="RegisterInfo" runat="server">
                    Creating your account consists of two simple steps:<br />
                    <br />
                    1. The first step is to create your user account. This will be used to log in to various Weavver&reg;
                    services.<br />
                    <br />
                    2. The next step is to create a database for yourself or organization. This will be used store
                    and manage your data.
               </asp:PlaceHolder>
               <asp:PlaceHolder ID="CheckOut" runat="server" Visible="false">
                    To continue checking out please create a Weavver ID or <a id="CheckOutLink" runat="server" href="javascript:LoginOpen(this);">log in</a>.
               </asp:PlaceHolder>
          </div>
          <div style="padding: 20px 20px 20px 20px; text-align: center; display: inline-block; max-width: 650px;">
               <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
          </div>
     </div>
</asp:Content>