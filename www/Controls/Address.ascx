<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Address.ascx.cs" Inherits="Controls_Address" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<cc1:ModalPopupExtender ID="Address_ModalPopupExtender" runat="server" Drag="True" DropShadow="True" CancelControlID="AddressCancel" BackgroundCssClass="modalPopup" DynamicServicePath="" Enabled="True" PopupControlID="AddressPanel" TargetControlID="AddressAdd"></cc1:ModalPopupExtender>
<asp:LinkButton ID="AddressAdd" runat="server" Text="Add Address"></asp:LinkButton>
<asp:Panel ID="AddressPanel" runat="server" BackColor="#FFFFFF" CssClass="ModalPopupPanel" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
     <table id="AddressEditor" runat="server" cellpadding="2" cellspacing="2" style="border: solid 1px grey;">
     <tr id="AddressHeader" runat="server">
          <td colspan="2" style="background-color: burlywood;"><h3>Address</h3></td>
     </tr>
     <tr>
          <td style="width:150px">Display Name</td>
          <td>
               <asp:TextBox ID="DisplayName" runat="server" Width="200px"></asp:TextBox><br />
          </td>
     </tr>
     <tr>
          <td style="width:150px">Line 1</td>
          <td>
               <asp:TextBox ID="AddressLine1" runat="server" Width="200px"></asp:TextBox><br />
          </td>
     </tr>
     <tr>
          <td>Line 2</td>
          <td>
               <asp:TextBox ID="AddressLine2" runat="server" Width="200px"></asp:TextBox><br />
          </td>
     </tr>
     <tr>
          <td>City</td>
          <td>
               <asp:TextBox ID="City" runat="server" Width="200px"></asp:TextBox>
          </td>
     </tr>
     <tr>
          <td>State</td>
          <td>
               <asp:TextBox ID="State" runat="server" Width="200px"></asp:TextBox>
          </td>
     </tr>
     <tr>
          <td>Zip Code</td>
          <td>
               <asp:TextBox ID="ZipCode" runat="server" Width="200px"></asp:TextBox>
          </td>
     </tr>
     <tr>
          <td>
               <asp:Button ID="AddressCancel" runat="server" Text="Cancel" OnClick="Submit_Click" Height="30px"></asp:Button>
          </td>
          <td style="text-align:right;">
               <asp:Button ID="Submit" runat="server" Text="Add Address" OnClick="Submit_Click" Height="30px"></asp:Button>
          </td>
     </tr>  
     </table>
</asp:Panel>