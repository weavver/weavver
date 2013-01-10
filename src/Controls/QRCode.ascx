<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QRCode.ascx.cs" Inherits="Controls_QRCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:LinkButton ID="QRCodeGen" runat="server" Text="Show QR Code" />
<cc1:ModalPopupExtender ID="MPE" runat="server" PopupControlID="QRPanel" CancelControlID="QROK" TargetControlID="QRCodeGen" BackgroundCssClass="modalPopup" />

<asp:Panel ID="QRPanel" runat="server" BackColor="#f0f0f0" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Width="225px" style="display:none;">
     <div style="padding: 10px;">
          You can access this page with the following QR Code:<br />
          <div style="max-height: 250px; text-align: center; margin-top: 10px; margin-bottom: 10px; border: solid 1px black; background-color: #FFFFFF;">
               <img id="QRURL" runat="server" alt="QR Code" src="" />
          </div>
          <div style="text-align: center; padding-bottom: 0px;">
               <asp:Button ID="QROK" runat="server" Text="OK" Width="100%" Height="30px" /><br />
          </div>
     </div>
</asp:Panel>