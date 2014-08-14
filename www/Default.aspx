<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="False" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WeavverDefault" Title="Weavver :: Abre Los Ojos." Trace="false" Debug="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register src="Navigation.ascx" tagname="Navigation" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/Controls/Register.ascx" tagname="RegisterUser" tagprefix="wvvr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Banner" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
     <div style="text-align: center;">
          <br />
          <img id="Logo" runat="server" style="margin-bottom: 10px; border: outset 1px lightgrey; width: 100%; max-width: 550px;" alt="The photography of Michael Magoski." src="~/images/art/burningman.png" />
          <div style="display:inline-block; width: 25px;">
               &nbsp;
          </div>
          <asp:LoginView ID="LoginView1" runat="server" Visible="true">
          <AnonymousTemplate>
               <div style="width: 100%; max-width: 350px; display:inline-block; vertical-align: top;margin-bottom: 10px;">
                    <wvvr:RegisterUser id="RegisterUser" runat="server"></wvvr:RegisterUser>
               </div>
          </AnonymousTemplate>
          </asp:LoginView>
          <div style="margin-bottom: 10px; display: inline-block; max-width: 350px; text-align:left;padding: 0px; vertical-align: top; min-width: 30px;">
               &nbsp;
          </div>
     </div>
</asp:Content>