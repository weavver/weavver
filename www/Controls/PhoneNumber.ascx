<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhoneNumber.ascx.cs" Inherits="Controls_PhoneNumber" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="PhoneNumber_ModalPopupExtender" runat="server" DropShadow="True" CancelControlID="PhoneNumberCancel" BackgroundCssClass="modalPopup" DynamicServicePath="" Enabled="True" PopupControlID="EditorPanel" TargetControlID="EditorAdd"></cc1:ModalPopupExtender>
<asp:LinkButton ID="EditorAdd" runat="server" Text="Add Phone Number"></asp:LinkButton>
<asp:Panel ID="EditorPanel" runat="server" BackColor="#FFFFFF" CssClass="ModalPopupPanel" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
     <table id="PhoneNumberEditor" runat="server" cellpadding="2" cellspacing="2" style="border: solid 1px grey;">
     <tr>
          <td colspan="2" style="background-color: burlywood;"><h3>Phone Number</h3></td>
     </tr>
     <tr>
          <td>Type</td>
          <td><asp:DropDownList ID="PhoneNumberType" runat="server">
          <asp:ListItem>Home</asp:ListItem>
          <asp:ListItem>Mobile</asp:ListItem>
          <asp:ListItem>Work</asp:ListItem>
          <asp:ListItem>Other</asp:ListItem>
          </asp:DropDownList></td>
     </tr>
     <tr>
          <td>Number</td>
          <td><asp:TextBox ID="PhoneNumberNumber" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>Notes</td>
          <td><asp:TextBox ID="PhoneNumberNotes" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td><asp:Button ID="PhoneNumberCancel" runat="server" Text="Cancel"></asp:Button></td>
          <td style="text-align:right;"><asp:Button ID="PhoneNumberSave" runat="server" Text="Save" OnClick="Save_Click"></asp:Button></td>
     </tr>
     </table>
</asp:Panel>