<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Controls_Contact" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="border-right: solid 1px #CCCCCC; height: 280px; width: 100%;" cellpadding="0" cellspacing="0">
<tr style="background-color: #d4e2e2; text-align: left; padding: 5px; margin-bottom: 5px; color: #000000; height: 25px;">
     <td style="padding-left: 8px;">
          <h3><asp:Literal ID="lTitle" runat="server"></asp:Literal></h3>
     </td>
     <td>
          <div style="float:right;">
               <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="">
               <ProgressTemplate><span style="font-style: italic;">Refreshing..&nbsp;</span></ProgressTemplate>
               </asp:UpdateProgress>
          </div>
     </td>
</tr>
<tr>
<td colspan="2" style="background-color: #FFFFFF; width: 280px; border: none 1px; padding: 8px;" valign="top">
     <table style="width: 280px; margin-top: 0px;">
     <tr>
          <td style="width:120px;">
               <asp:TextBox ID="tbFirstName" runat="server" Width="110px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbFirstName" ErrorMessage="*" ToolTip="First name is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator><br />
               <cc1:FilteredTextBoxExtender ID="filteredFirstName" runat="server" TargetControlID="tbFirstName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" />
               <cc1:TextBoxWatermarkExtender ID="FirstNameWatermark" runat="server" TargetControlID="tbFirstName" WatermarkText="first name" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
          <td style="">
               <asp:TextBox ID="tbLastName" runat="server" Width="130px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbLastName" ErrorMessage="*" ToolTip="Last name is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator><br />
               <cc1:FilteredTextBoxExtender ID="filteredLastName" runat="server" TargetControlID="tbLastName" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="tbLastName" WatermarkText="last name" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td colspan="2">
               <asp:TextBox ID="tbOrganization" runat="server" Width="230px"></asp:TextBox>
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="tbOrganization" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@.-+_0123456789 " />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server" TargetControlID="tbOrganization" WatermarkText="company or non-profit name" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td colspan="2">
               <asp:TextBox ID="tbEmailAddress" runat="server" Width="230px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmailAddress" ErrorMessage="*" ToolTip="E-mail address is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator><br />
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbEmailAddress" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@.-+_0123456789" />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="tbEmailAddress" WatermarkText="e-mail address" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td colspan="2">
               <asp:TextBox ID="tbAddressLine1" runat="server" Width="200"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbAddressLine1" ErrorMessage="*" ToolTip="Address is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator><br />
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="tbAddressLine1" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 0123456789.#-+," />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="tbAddressLine1" WatermarkText="address line 1" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td colspan="2">
               <asp:TextBox ID="tbAddressLine2" runat="server" Width="200"></asp:TextBox><br />
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="tbAddressLine2" ValidChars="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 0123456789.#-+," />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="tbAddressLine2" WatermarkText="address line 2" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td colspan="2">
               <asp:TextBox ID="tbZipCode" runat="server" Width="75"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbZipCode" ErrorMessage="*" ToolTip="First name is required." ValidationGroup="OrderForm"></asp:RequiredFieldValidator><br />
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="tbZipCode" ValidChars="0123456789-" />
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="tbZipCode" WatermarkText="zip code" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     <tr>
          <td>
               <asp:TextBox ID="tbPhoneNumber" runat="server" Width="120"></asp:TextBox> <asp:TextBox ID="tbPhoneExtension" runat="server" Width="40"></asp:TextBox>
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="tbPhoneNumber" WatermarkText="phone number" WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
               <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="tbPhoneExtension" WatermarkText="ext." WatermarkCssClass="WatermarkedField"></cc1:TextBoxWatermarkExtender>
          </td>
     </tr>
     </table>
     </td>
</tr>
</table>